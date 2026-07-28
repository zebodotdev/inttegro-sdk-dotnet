using Commerce.Http;
using Commerce.Responses;

namespace Commerce.Resources;

public sealed class MessageTemplatesResource
{
    private readonly ApiClient _client;

    public MessageTemplatesResource(ApiClient client) => _client = client;

    public Task<CommerceResponse> CreateAsync(object payload, string? idempotencyKey = null, CancellationToken cancellationToken = default) =>
        _client.PostWithHeadersAsync("/message_templates/create", payload, Headers(idempotencyKey), cancellationToken);

    public Task<CommerceResponse> UpdateAsync(object payload, string? idempotencyKey = null, CancellationToken cancellationToken = default) =>
        _client.PostWithHeadersAsync("/message_templates/update", payload, Headers(idempotencyKey), cancellationToken);

    public Task<CommerceResponse> PublishAsync(string templateId, string? idempotencyKey = null, CancellationToken cancellationToken = default) =>
        _client.PostWithHeadersAsync("/message_templates/publish", new { id = templateId }, Headers(idempotencyKey), cancellationToken);

    public Task<CommerceResponse> ArchiveAsync(string templateId, string? idempotencyKey = null, CancellationToken cancellationToken = default) =>
        _client.PostWithHeadersAsync("/message_templates/archive", new { id = templateId }, Headers(idempotencyKey), cancellationToken);

    public Task<CommerceResponse> LookupAsync(string templateId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/message_templates/lookup", new { id = templateId }, cancellationToken);

    public Task<CommerceResponse> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/message_templates/page", payload ?? new { }, cancellationToken);

    public Task<CommerceResponse> RenderPreviewAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/message_templates/render_preview", payload, cancellationToken);

    private static IDictionary<string, string> Headers(string? idempotencyKey) =>
        string.IsNullOrWhiteSpace(idempotencyKey)
            ? new Dictionary<string, string>()
            : new Dictionary<string, string> { ["Idempotency-Key"] = idempotencyKey };
}
