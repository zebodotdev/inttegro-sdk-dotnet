using Commerce.Http;
using Commerce.Responses;

namespace Commerce.Resources;

public class KeysResource
{
    private readonly ApiClient _client;

    internal KeysResource(ApiClient client) => _client = client;

    public Task<CommerceResponse> GenerateAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/keys/generate", payload ?? new { }, cancellationToken);

    public Task<CommerceResponse> LookupAsync(string secretKeyId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/keys/lookup", new { secret_key_id = secretKeyId }, cancellationToken);

    public Task<CommerceResponse> LookupAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/keys/lookup", payload, cancellationToken);

    public Task<CommerceResponse> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/keys/page", payload ?? new { }, cancellationToken);

    public Task<CommerceResponse> UpdateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/keys/update", payload, cancellationToken);

    public Task<CommerceResponse> DestroyAsync(string secretKeyId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/keys/destroy", new { secret_key_id = secretKeyId }, cancellationToken);

    public Task<CommerceResponse> DestroyAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/keys/destroy", payload, cancellationToken);

    public Task<CommerceResponse> UsageAsync(string secretKeyId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/keys/usage", new { secret_key_id = secretKeyId }, cancellationToken);

    public Task<CommerceResponse> UsageAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/keys/usage", payload, cancellationToken);
}
