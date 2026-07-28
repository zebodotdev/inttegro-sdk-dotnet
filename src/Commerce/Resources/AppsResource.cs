using Commerce.Http;
using Commerce.Responses;

namespace Commerce.Resources;

public class AppsResource
{
    private readonly ApiClient _client;

    public AppsResource(ApiClient client) => _client = client;

    public Task<CommerceResponse> CreateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/apps/create", payload, cancellationToken);

    public Task<CommerceResponse> LookupAsync(CancellationToken cancellationToken = default) =>
        _client.PostAsync("/apps/lookup", new { }, cancellationToken);

    public Task<CommerceResponse> UpdateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/apps/update", payload, cancellationToken);
}
