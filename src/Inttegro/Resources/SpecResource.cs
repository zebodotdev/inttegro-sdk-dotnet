using Inttegro.Http;
using Inttegro.Responses;

namespace Inttegro.Resources;

public class SpecResource
{
    private readonly ApiClient _client;

    internal SpecResource(ApiClient client) => _client = client;

    public Task<InttegroResponse> CountriesAsync(CancellationToken cancellationToken = default) =>
        _client.PostAsync("/spec/countries", new { }, cancellationToken);
}
