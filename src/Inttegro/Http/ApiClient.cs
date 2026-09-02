using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Inttegro;
using Inttegro.Errors;
using Inttegro.Responses;

namespace Inttegro.Http;

internal class ApiClient : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly bool _ownsHttpClient;
    private readonly JsonSerializerOptions _serializerOptions;

    public ApiClient(string apiKey, string baseUrl, TimeSpan timeout, HttpClient? httpClient = null)
    {
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new ArgumentException("apiKey is required", nameof(apiKey));
        }

        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = null,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };

        if (httpClient != null)
        {
            _httpClient = httpClient;
            _ownsHttpClient = false;
        }
        else
        {
            _httpClient = new HttpClient { Timeout = timeout };
            _ownsHttpClient = true;
        }

        _httpClient.BaseAddress = new Uri(baseUrl.TrimEnd('/'));
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("inttegro-sdk-dotnet/2.0.0");
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<InttegroResponse> PostAsync(string path, object? payload = null, CancellationToken cancellationToken = default)
    {
        var requestUri = path.StartsWith('/') ? path : "/" + path;
        var json = SerializeRequestPayload(requestUri, payload, generateIdempotencyKey: true);
        using var content = new StringContent(json, Encoding.UTF8, "application/json");

        HttpResponseMessage response;
        try
        {
            response = await _httpClient.PostAsync(requestUri, content, cancellationToken);
        }
        catch (TaskCanceledException ex) when (!cancellationToken.IsCancellationRequested)
        {
            throw new InttegroTimeoutException("Request timed out", ex);
        }
        catch (Exception ex) when (ex is HttpRequestException or TaskCanceledException)
        {
            throw new InttegroNetworkException("Network request failed", ex);
        }

        var body = await response.Content.ReadAsStringAsync(cancellationToken);
        var parsed = ParseJson(body);

        if (!response.IsSuccessStatusCode)
        {
            HandleError(response, body, parsed);
        }

        return new InttegroResponse(parsed);
    }

    public async Task<T> PostAsync<T>(string path, object? payload = null, CancellationToken cancellationToken = default)
        where T : class
    {
        var response = await PostAsync(path, payload, cancellationToken);
        return response.Deserialize<T>()
            ?? throw new InvalidOperationException($"Inttegro returned an invalid response for {path}");
    }

    public async Task<T> PostResourceAsync<T>(
        string path,
        string field,
        object? payload = null,
        CancellationToken cancellationToken = default
    ) where T : class
    {
        var response = await PostAsync(path, payload, cancellationToken);
        return response[field]?.Deserialize<T>()
            ?? throw new InvalidOperationException($"Inttegro returned an invalid {field} response for {path}");
    }

    public async Task<InttegroResponse> PostWithHeadersAsync(
        string path,
        object? payload = null,
        IDictionary<string, string>? headers = null,
        CancellationToken cancellationToken = default
    )
    {
        var requestUri = path.StartsWith('/') ? path : "/" + path;
        var headerMap = headers ?? new Dictionary<string, string>();
        var json = SerializeRequestPayload(requestUri, payload, generateIdempotencyKey: !HasHeader(headerMap, "Idempotency-Key"));
        using var request = new HttpRequestMessage(HttpMethod.Post, requestUri)
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };
        foreach (var header in headerMap)
        {
            request.Headers.TryAddWithoutValidation(header.Key, header.Value);
        }
        return await SendForJsonAsync(request, cancellationToken);
    }

    public async Task<T> PostResourceWithHeadersAsync<T>(
        string path,
        string field,
        object? payload = null,
        IDictionary<string, string>? headers = null,
        CancellationToken cancellationToken = default
    ) where T : class
    {
        var response = await PostWithHeadersAsync(path, payload, headers, cancellationToken);
        return response[field]?.Deserialize<T>()
            ?? throw new InvalidOperationException($"Inttegro returned an invalid {field} response for {path}");
    }

    public async Task<InttegroResponse> PostMultipartAsync(
        string pathOrUrl,
        IDictionary<string, object?> fields,
        IDictionary<string, string> files,
        IDictionary<string, string>? headers = null,
        CancellationToken cancellationToken = default
    )
    {
        using var content = new MultipartFormDataContent();
        foreach (var field in fields)
        {
            if (field.Value == null) continue;
            var value = field.Value is string s ? s : JsonSerializer.Serialize(field.Value, _serializerOptions);
            content.Add(new StringContent(value), field.Key);
        }
        foreach (var file in files)
        {
            var stream = File.OpenRead(file.Value);
            var fileContent = new StreamContent(stream);
            content.Add(fileContent, file.Key, Path.GetFileName(file.Value));
        }

        using var request = new HttpRequestMessage(HttpMethod.Post, RequestUri(pathOrUrl))
        {
            Content = content
        };
        var headerMap = headers == null ? new Dictionary<string, string>() : new Dictionary<string, string>(headers);
        if (!IsAbsoluteUrl(pathOrUrl) && IsIdempotentMutationPath(pathOrUrl) && !HasHeader(headerMap, "Idempotency-Key"))
        {
            headerMap["Idempotency-Key"] = GenerateIdempotencyKey();
        }
        foreach (var header in headerMap)
        {
            request.Headers.TryAddWithoutValidation(header.Key, header.Value);
        }
        return await SendForJsonAsync(request, cancellationToken);
    }

    public async Task<FileDownload> PostBinaryJsonAsync(string path, object payload, CancellationToken cancellationToken = default)
    {
        var json = SerializeRequestPayload(path, payload, generateIdempotencyKey: false);
        using var request = new HttpRequestMessage(HttpMethod.Post, RequestUri(path))
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };
        request.Headers.Accept.Clear();
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/octet-stream"));
        return await SendForDownloadAsync(request, cancellationToken);
    }

    public async Task<FileDownload> GetBinaryPublicAsync(string url, CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        return await SendForDownloadAsync(request, cancellationToken);
    }

    private Uri RequestUri(string pathOrUrl)
    {
        if (pathOrUrl.StartsWith("http://") || pathOrUrl.StartsWith("https://"))
        {
            return new Uri(pathOrUrl);
        }
        return new Uri(pathOrUrl.StartsWith('/') ? pathOrUrl : "/" + pathOrUrl, UriKind.Relative);
    }

    private string SerializeRequestPayload(string path, object? payload, bool generateIdempotencyKey)
    {
        var json = JsonSerializer.Serialize(payload ?? new { }, _serializerOptions);
        var node = ParseJson(json);
        if (node is not JsonObject obj)
        {
            return json;
        }

        obj.Remove("idempotency_key");
        if (!generateIdempotencyKey || !IsIdempotentMutationPath(path))
        {
            return obj.ToJsonString(_serializerOptions);
        }

        var requestMeta = obj["request_meta"] as JsonObject;
        if (requestMeta == null)
        {
            requestMeta = new JsonObject();
            obj["request_meta"] = requestMeta;
        }

        var existing = requestMeta["idempotency_key"]?.ToString();
        if (string.IsNullOrWhiteSpace(existing))
        {
            requestMeta["idempotency_key"] = GenerateIdempotencyKey();
        }
        return obj.ToJsonString(_serializerOptions);
    }

    private static bool IsIdempotentMutationPath(string pathOrUrl)
    {
        var path = pathOrUrl;
        if (IsAbsoluteUrl(pathOrUrl))
        {
            if (!Uri.TryCreate(pathOrUrl, UriKind.Absolute, out var uri))
            {
                return false;
            }
            path = uri.AbsolutePath;
        }

        if (path.StartsWith("/keys/", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        var action = path.Trim('/').Split('/', StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
        return action is not null and not "lookup" and not "page" and not "settings" and not "countries" and not "contents" and not "balances" and not "render_preview";
    }

    private static bool IsAbsoluteUrl(string pathOrUrl) =>
        pathOrUrl.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || pathOrUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase);

    private static bool HasHeader(IDictionary<string, string> headers, string name) =>
        headers.Any(header => string.Equals(header.Key, name, StringComparison.OrdinalIgnoreCase) && !string.IsNullOrWhiteSpace(header.Value));

    private static string GenerateIdempotencyKey()
    {
        Span<byte> bytes = stackalloc byte[16];
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() & 0xffffffffffffL;
        bytes[0] = (byte)(timestamp >> 40);
        bytes[1] = (byte)(timestamp >> 32);
        bytes[2] = (byte)(timestamp >> 24);
        bytes[3] = (byte)(timestamp >> 16);
        bytes[4] = (byte)(timestamp >> 8);
        bytes[5] = (byte)timestamp;
        RandomNumberGenerator.Fill(bytes[6..]);
        bytes[6] = (byte)((bytes[6] & 0x0f) | 0x70);
        bytes[8] = (byte)((bytes[8] & 0x3f) | 0x80);
        var hex = Convert.ToHexString(bytes).ToLowerInvariant();
        return $"{hex[..8]}-{hex[8..12]}-{hex[12..16]}-{hex[16..20]}-{hex[20..]}";
    }

    private async Task<InttegroResponse> SendForJsonAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        HttpResponseMessage response;
        try
        {
            response = await _httpClient.SendAsync(request, cancellationToken);
        }
        catch (TaskCanceledException ex) when (!cancellationToken.IsCancellationRequested)
        {
            throw new InttegroTimeoutException("Request timed out", ex);
        }
        catch (Exception ex) when (ex is HttpRequestException or TaskCanceledException)
        {
            throw new InttegroNetworkException("Network request failed", ex);
        }

        var body = await response.Content.ReadAsStringAsync(cancellationToken);
        var parsed = ParseJson(body);
        if (!response.IsSuccessStatusCode)
        {
            HandleError(response, body, parsed);
        }
        return new InttegroResponse(parsed);
    }

    private async Task<FileDownload> SendForDownloadAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = await _httpClient.SendAsync(request, cancellationToken);
        var bytes = await response.Content.ReadAsByteArrayAsync(cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var body = Encoding.UTF8.GetString(bytes);
            HandleError(response, body, ParseJson(body));
        }
        return new FileDownload(bytes, response.Content.Headers.ContentType?.MediaType);
    }

    private JsonNode? ParseJson(string body)
    {
        if (string.IsNullOrWhiteSpace(body)) return null;
        try
        {
            return JsonNode.Parse(body);
        }
        catch
        {
            return null;
        }
    }

    private void HandleError(HttpResponseMessage response, string rawBody, JsonNode? parsed)
    {
        var status = (int)response.StatusCode;
        var message = $"HTTP {status}";
        JsonObject? payload = null;
        if (parsed is JsonObject obj)
        {
            payload = obj["error"] as JsonObject ?? obj;
        }

        if (payload != null)
        {
            message = payload["message"]?.GetValue<string>() ??
                      payload["detail"]?.GetValue<string>() ??
                      (parsed as JsonObject)?["message"]?.GetValue<string>() ??
                      message;
        }

        var code = payload?["code"]?.GetValue<string>();
        var type = payload?["type"]?.GetValue<string>();
        var url = payload?["url"]?.GetValue<string>();
        var detail = payload?["detail"]?.GetValue<string>();
        var fixCode = payload?["fix_code"]?.GetValue<string>();
        var cause = payload?["cause"]?.GetValue<string>();

        if (status == 401)
        {
            throw new InttegroAuthenticationException(
                message,
                status,
                code,
                type,
                url,
                detail,
                fixCode,
                cause,
                rawBody,
                parsed
            );
        }

        if (status == 429)
        {
            int? retryAfter = null;
            if (response.Headers.TryGetValues("Retry-After", out var values))
            {
                var value = values.FirstOrDefault();
                if (int.TryParse(value, out var parsedRetry))
                {
                    retryAfter = parsedRetry;
                }
            }

            throw new InttegroRateLimitException(
                message,
                status,
                code,
                type,
                url,
                detail,
                fixCode,
                cause,
                rawBody,
                parsed,
                retryAfter
            );
        }

        throw new InttegroApiException(
            message,
            status,
            code,
            type,
            url,
            detail,
            fixCode,
            cause,
            rawBody,
            parsed
        );
    }

    public void Dispose()
    {
        if (_ownsHttpClient)
        {
            _httpClient.Dispose();
        }
    }
}
