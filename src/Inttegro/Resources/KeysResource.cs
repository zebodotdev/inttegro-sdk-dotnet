using Inttegro.Http;
using Inttegro.Responses;

namespace Inttegro.Resources;

public class KeysResource
{
    private readonly ApiClient _client;

    internal KeysResource(ApiClient client) => _client = client;

    public Task<InttegroResponse> GenerateAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/keys/generate", payload ?? new { }, cancellationToken);

    public Task<InttegroResponse> LookupAsync(string secretKeyId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/keys/lookup", new { secret_key_id = secretKeyId }, cancellationToken);

    public Task<InttegroResponse> LookupAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/keys/lookup", payload, cancellationToken);

    public Task<InttegroResponse> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/keys/page", payload ?? new { }, cancellationToken);

    public Task<InttegroResponse> UpdateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/keys/update", payload, cancellationToken);

    public Task<InttegroResponse> DestroyAsync(string secretKeyId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/keys/destroy", new { secret_key_id = secretKeyId }, cancellationToken);

    public Task<InttegroResponse> DestroyAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/keys/destroy", payload, cancellationToken);

    public Task<InttegroResponse> UsageAsync(string secretKeyId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/keys/usage", new { secret_key_id = secretKeyId }, cancellationToken);

    public Task<InttegroResponse> UsageAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/keys/usage", payload, cancellationToken);
}
