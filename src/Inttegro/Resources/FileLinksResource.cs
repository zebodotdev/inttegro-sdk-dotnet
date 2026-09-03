using Inttegro.Http;

namespace Inttegro.Resources;

public sealed class FileLinksResource
{
    private readonly ApiClient _client;

    internal FileLinksResource(ApiClient client) => _client = client;

    public Task<FileLinkCreation> CreateAsync(object payload, string? idempotencyKey = null, CancellationToken cancellationToken = default) =>
        _client.PostWithHeadersAsync<FileLinkCreation>("/file_links/create", payload, Headers(idempotencyKey), cancellationToken);

    public Task<FileLink> LookupAsync(string id, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<FileLink>("/file_links/lookup", "file_link", new { id }, cancellationToken);

    public Task<FileLinkPage> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<FileLinkPage>("/file_links/page", "page", payload ?? new { }, cancellationToken);

    public Task<FileLink> RevokeAsync(object payload, string? idempotencyKey = null, CancellationToken cancellationToken = default) =>
        _client.PostResourceWithHeadersAsync<FileLink>("/file_links/revoke", "file_link", payload, Headers(idempotencyKey), cancellationToken);

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
