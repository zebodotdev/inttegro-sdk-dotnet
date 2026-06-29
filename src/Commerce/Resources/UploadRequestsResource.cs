using Commerce.Http;
using Commerce.Responses;

namespace Commerce.Resources;

public sealed class UploadRequestsResource
{
    private readonly ApiClient _client;

    public UploadRequestsResource(ApiClient client) => _client = client;

    public Task<CommerceResponse> CreateAsync(object payload, string? idempotencyKey = null, CancellationToken cancellationToken = default) =>
        _client.PostWithHeadersAsync("/upload_requests/create", payload, Headers(idempotencyKey), cancellationToken);

    public Task<CommerceResponse> LookupAsync(string id, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/upload_requests/lookup", new { id }, cancellationToken);

    public Task<CommerceResponse> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/upload_requests/page", payload ?? new { }, cancellationToken);

    public Task<CommerceResponse> CancelAsync(object payload, string? idempotencyKey = null, CancellationToken cancellationToken = default) =>
        _client.PostWithHeadersAsync("/upload_requests/cancel", payload, Headers(idempotencyKey), cancellationToken);

    public Task<CommerceResponse> FulfillAsync(object payload, CancellationToken cancellationToken = default)
    {
        var values = payload.GetType().GetProperties().ToDictionary(p => p.Name, p => p.GetValue(payload));
        var uploadUrl = values["upload_url"]?.ToString() ?? throw new ArgumentException("upload_url is required");
        var file = values["file"]?.ToString() ?? throw new ArgumentException("file is required");
        return _client.PostMultipartAsync(uploadUrl, new Dictionary<string, object?>(), new Dictionary<string, string> { ["file"] = file }, cancellationToken: cancellationToken);
    }

    private static IDictionary<string, string> Headers(string? idempotencyKey) =>
        idempotencyKey == null ? new Dictionary<string, string>() : new Dictionary<string, string> { ["Idempotency-Key"] = idempotencyKey };
}
