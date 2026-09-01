using Inttegro.Http;
using Inttegro.Responses;

namespace Inttegro.Resources;

public class BalancesResource
{
    private readonly ApiClient _client;

    internal BalancesResource(ApiClient client) => _client = client;

    public Task<InttegroResponse> GetAsync(CancellationToken cancellationToken = default) =>
        _client.PostAsync("/balances", new { }, cancellationToken);
}
