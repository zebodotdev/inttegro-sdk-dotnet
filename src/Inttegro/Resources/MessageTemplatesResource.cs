using Inttegro.Http;

namespace Inttegro.Resources;

public sealed class MessageTemplatesResource
{
    private readonly ApiClient _client;

    internal MessageTemplatesResource(ApiClient client) => _client = client;

    public Task<MessageTemplate> CreateAsync(object payload, string? idempotencyKey = null, CancellationToken cancellationToken = default) =>
        _client.PostResourceWithHeadersAsync<MessageTemplate>("/message_templates/create", "message_template", payload, Headers(idempotencyKey), cancellationToken);

    public Task<MessageTemplate> UpdateAsync(object payload, string? idempotencyKey = null, CancellationToken cancellationToken = default) =>
        _client.PostResourceWithHeadersAsync<MessageTemplate>("/message_templates/update", "message_template", payload, Headers(idempotencyKey), cancellationToken);

    public Task<MessageTemplate> PublishAsync(string templateId, string? idempotencyKey = null, CancellationToken cancellationToken = default) =>
        _client.PostResourceWithHeadersAsync<MessageTemplate>("/message_templates/publish", "message_template", new { id = templateId }, Headers(idempotencyKey), cancellationToken);

    public Task<MessageTemplate> ArchiveAsync(string templateId, string? idempotencyKey = null, CancellationToken cancellationToken = default) =>
        _client.PostResourceWithHeadersAsync<MessageTemplate>("/message_templates/archive", "message_template", new { id = templateId }, Headers(idempotencyKey), cancellationToken);

    public Task<MessageTemplate> LookupAsync(string templateId, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<MessageTemplate>("/message_templates/lookup", "message_template", new { id = templateId }, cancellationToken);

    public Task<MessageTemplatePage> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<MessageTemplatePage>("/message_templates/page", "page", payload ?? new { }, cancellationToken);

    public Task<MessageTemplatePreview> RenderPreviewAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync<MessageTemplatePreview>("/message_templates/render_preview", payload, cancellationToken);

    private static IDictionary<string, string> Headers(string? idempotencyKey) =>
        string.IsNullOrWhiteSpace(idempotencyKey)
            ? new Dictionary<string, string>()
            : new Dictionary<string, string> { ["Idempotency-Key"] = idempotencyKey };
}
