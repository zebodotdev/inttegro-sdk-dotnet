using Inttegro.Http;
using Inttegro.Responses;

namespace Inttegro.Resources;

public sealed class MessageTemplatesResource
{
    private readonly ApiClient _client;

    internal MessageTemplatesResource(ApiClient client) => _client = client;

    public Task<InttegroResponse> CreateAsync(object payload, string? idempotencyKey = null, CancellationToken cancellationToken = default) =>
        _client.PostWithHeadersAsync("/message_templates/create", payload, Headers(idempotencyKey), cancellationToken);

    public Task<InttegroResponse> UpdateAsync(object payload, string? idempotencyKey = null, CancellationToken cancellationToken = default) =>
        _client.PostWithHeadersAsync("/message_templates/update", payload, Headers(idempotencyKey), cancellationToken);

    public Task<InttegroResponse> PublishAsync(string templateId, string? idempotencyKey = null, CancellationToken cancellationToken = default) =>
        _client.PostWithHeadersAsync("/message_templates/publish", new { id = templateId }, Headers(idempotencyKey), cancellationToken);

    public Task<InttegroResponse> ArchiveAsync(string templateId, string? idempotencyKey = null, CancellationToken cancellationToken = default) =>
        _client.PostWithHeadersAsync("/message_templates/archive", new { id = templateId }, Headers(idempotencyKey), cancellationToken);

    public Task<InttegroResponse> LookupAsync(string templateId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/message_templates/lookup", new { id = templateId }, cancellationToken);

    public Task<InttegroResponse> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/message_templates/page", payload ?? new { }, cancellationToken);

    public Task<InttegroResponse> RenderPreviewAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/message_templates/render_preview", payload, cancellationToken);

    private static IDictionary<string, string> Headers(string? idempotencyKey) =>
        string.IsNullOrWhiteSpace(idempotencyKey)
            ? new Dictionary<string, string>()
            : new Dictionary<string, string> { ["Idempotency-Key"] = idempotencyKey };
}
