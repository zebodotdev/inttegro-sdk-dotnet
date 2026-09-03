using Inttegro.Http;

namespace Inttegro.Resources;

public class KeysResource
{
    private readonly ApiClient _client;

    internal KeysResource(ApiClient client) => _client = client;

    public Task<GeneratedSecretKey> GenerateAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<GeneratedSecretKey>("/keys/generate", "key", payload ?? new { }, cancellationToken);

    public Task<SecretKey> LookupAsync(string secretKeyId, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<SecretKey>("/keys/lookup", "key", new { secret_key_id = secretKeyId }, cancellationToken);

    public Task<SecretKey> LookupAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<SecretKey>("/keys/lookup", "key", payload, cancellationToken);

    public Task<SecretKeyPage> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<SecretKeyPage>("/keys/page", "page", payload ?? new { }, cancellationToken);

    public Task<SecretKey> UpdateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<SecretKey>("/keys/update", "key", payload, cancellationToken);

    public Task<SecretKey> DestroyAsync(string secretKeyId, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<SecretKey>("/keys/destroy", "key", new { secret_key_id = secretKeyId }, cancellationToken);

    public Task<SecretKey> DestroyAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<SecretKey>("/keys/destroy", "key", payload, cancellationToken);

    public Task<SecretKeyUsage> UsageAsync(string secretKeyId, CancellationToken cancellationToken = default) =>
        _client.PostAsync<SecretKeyUsage>("/keys/usage", new { secret_key_id = secretKeyId }, cancellationToken);

    public Task<SecretKeyUsage> UsageAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync<SecretKeyUsage>("/keys/usage", payload, cancellationToken);
}
