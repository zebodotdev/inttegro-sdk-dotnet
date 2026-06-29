using Commerce.Http;
using Commerce.Responses;

namespace Commerce.Resources;

public class PlatformResource
{
    private readonly ApiClient _client;

    public PlatformResource(ApiClient client) => _client = client;

    public Task<CommerceResponse> CreateAppAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/apps/create", payload, cancellationToken);

    public Task<CommerceResponse> GenerateKeyAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/keys/generate", payload, cancellationToken);

    public Task<CommerceResponse> NewSessionAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/sessions/new", payload, cancellationToken);
}
