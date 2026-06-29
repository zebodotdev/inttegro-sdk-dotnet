using Commerce.Http;
using Commerce.Responses;

namespace Commerce.Resources;

public sealed class FilesResource
{
    private readonly ApiClient _client;

    public FilesResource(ApiClient client) => _client = client;

    public Task<CommerceResponse> CreateAsync(object payload, CancellationToken cancellationToken = default) =>
        CreateAsync(payload, idempotencyKey: null, cancellationToken);

    public Task<CommerceResponse> CreateAsync(object payload, string? idempotencyKey, CancellationToken cancellationToken = default)
    {
        var values = ToDictionary(payload);
        var headers = Headers(idempotencyKey ?? values.GetValueOrDefault("idempotency_key")?.ToString());
        values.Remove("idempotency_key");
        var file = values["file"]?.ToString() ?? throw new ArgumentException("file is required");
        values.Remove("file");
        return _client.PostMultipartAsync("/files/create", values, new Dictionary<string, string> { ["file"] = file }, headers, cancellationToken);
    }

    public Task<CommerceResponse> LookupAsync(string fileId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/files/lookup", new { file_id = fileId }, cancellationToken);

    public Task<CommerceResponse> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/files/page", payload ?? new { }, cancellationToken);

    public Task<FileDownload> ContentsAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostBinaryJsonAsync("/files/contents", payload, cancellationToken);

    public Task<CommerceResponse> DeleteAsync(string fileId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/files/delete", new { file_id = fileId }, cancellationToken);

    private static Dictionary<string, object?> ToDictionary(object payload) =>
        payload.GetType().GetProperties().ToDictionary(p => p.Name, p => p.GetValue(payload));

    private static IDictionary<string, string> Headers(string? idempotencyKey) =>
        idempotencyKey == null ? new Dictionary<string, string>() : new Dictionary<string, string> { ["Idempotency-Key"] = idempotencyKey };
}
