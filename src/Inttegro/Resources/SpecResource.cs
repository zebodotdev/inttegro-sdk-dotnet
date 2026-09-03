using Inttegro.Http;

namespace Inttegro.Resources;

public class SpecResource
{
    private readonly ApiClient _client;

    internal SpecResource(ApiClient client) => _client = client;

    public Task<CountrySpecifications> CountriesAsync(CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<CountrySpecifications>("/spec/countries", "countries", new { }, cancellationToken);
}
