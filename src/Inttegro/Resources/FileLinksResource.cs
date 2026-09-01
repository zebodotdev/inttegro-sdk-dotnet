using Inttegro.Http;
using Inttegro.Responses;

namespace Inttegro.Resources;

public sealed class FileLinksResource
{
    private readonly ApiClient _client;

    internal FileLinksResource(ApiClient client) => _client = client;

    public Task<InttegroResponse> CreateAsync(object payload, string? idempotencyKey = null, CancellationToken cancellationToken = default) =>
        _client.PostWithHeadersAsync("/file_links/create", payload, Headers(idempotencyKey), cancellationToken);

    public Task<InttegroResponse> LookupAsync(string id, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/file_links/lookup", new { id }, cancellationToken);

    public Task<InttegroResponse> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/file_links/page", payload ?? new { }, cancellationToken);

    public Task<InttegroResponse> RevokeAsync(object payload, string? idempotencyKey = null, CancellationToken cancellationToken = default) =>
        _client.PostWithHeadersAsync("/file_links/revoke", payload, Headers(idempotencyKey), cancellationToken);

    public async Task<FileDownload> OpenAsync(string url, string? saveTo = null, CancellationToken cancellationToken = default)
    {
        var download = await _client.GetBinaryPublicAsync(url, cancellationToken);
        if (saveTo != null)
        {
            await download.SaveToAsync(saveTo, cancellationToken);
        }
        return download;
    }

    private static IDictionary<string, string> Headers(string? idempotencyKey) =>
        idempotencyKey == null ? new Dictionary<string, string>() : new Dictionary<string, string> { ["Idempotency-Key"] = idempotencyKey };
}
