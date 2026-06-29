using Commerce.Http;
using Commerce.Responses;

namespace Commerce.Resources;

public class SpecResource
{
    private readonly ApiClient _client;

    public SpecResource(ApiClient client) => _client = client;

    public Task<CommerceResponse> CountriesAsync(CancellationToken cancellationToken = default) =>
        _client.PostAsync("/spec/countries", new { }, cancellationToken);
}
