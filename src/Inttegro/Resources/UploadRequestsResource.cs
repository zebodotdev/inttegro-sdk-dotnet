using Inttegro.Http;
using Inttegro;
using Inttegro.Validation;

namespace Inttegro.Resources;

public sealed class UploadRequestsResource
{
    private readonly ApiClient _client;

    internal UploadRequestsResource(ApiClient client) => _client = client;

    public Task<UploadRequest> CreateAsync(object payload, string? idempotencyKey = null, CancellationToken cancellationToken = default) =>
        _client.PostResourceWithHeadersAsync<UploadRequest>("/upload_requests/create", "upload_request", payload, Headers(idempotencyKey), cancellationToken);

    public Task<UploadRequest> LookupAsync(string id, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<UploadRequest>("/upload_requests/lookup", "upload_request", new { id }, cancellationToken);

    public Task<UploadRequestPage> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<UploadRequestPage>("/upload_requests/page", "page", payload ?? new { }, cancellationToken);

    public Task<UploadRequest> CancelAsync(object payload, string? idempotencyKey = null, CancellationToken cancellationToken = default) =>
        _client.PostResourceWithHeadersAsync<UploadRequest>("/upload_requests/cancel", "upload_request", payload, Headers(idempotencyKey), cancellationToken);

    public Task<UploadRequest> ReviewAsync(
        ReviewUploadRequestAttemptByIdRequest payload,
        string? idempotencyKey = null,
        CancellationToken cancellationToken = default
    )
    {
        ValidateReview(payload.Id, payload.Decision, payload.AttemptId);
        return _client.PostResourceWithHeadersAsync<UploadRequest>("/upload_requests/review", "upload_request", payload, Headers(idempotencyKey), cancellationToken);
    }

    public Task<UploadRequest> ReviewAsync(
        ReviewUploadRequestAttemptByOrdinalRequest payload,
        string? idempotencyKey = null,
        CancellationToken cancellationToken = default
    )
    {
        ValidateReview(payload.Id, payload.Decision, payload.AttemptOrdinal);
        return _client.PostResourceWithHeadersAsync<UploadRequest>("/upload_requests/review", "upload_request", payload, Headers(idempotencyKey), cancellationToken);
    }

    public Task<UploadFulfillment> FulfillAsync(object payload, CancellationToken cancellationToken = default)
    {
        var values = payload.GetType().GetProperties().ToDictionary(p => p.Name, p => p.GetValue(payload));
        var uploadUrl = values["upload_url"]?.ToString() ?? throw new ArgumentException("upload_url is required");
        var file = values["file"]?.ToString() ?? throw new ArgumentException("file is required");
        return _client.PostMultipartAsync<UploadFulfillment>(uploadUrl, new Dictionary<string, object?>(), new Dictionary<string, string> { ["file"] = file }, cancellationToken: cancellationToken);
    }

    private static IDictionary<string, string> Headers(string? idempotencyKey) =>
        idempotencyKey == null ? new Dictionary<string, string>() : new Dictionary<string, string> { ["Idempotency-Key"] = idempotencyKey };

    private static void ValidateReview(string? id, string? decision, object? attempt)
    {
        RequestValidator.Require(id, "id");
        RequestValidator.Require(decision, "decision");
        RequestValidator.Require(attempt, "attempt_id or attempt_ordinal");
    }
}
