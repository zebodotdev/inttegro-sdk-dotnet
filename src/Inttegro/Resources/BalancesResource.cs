using Inttegro.Http;

namespace Inttegro.Resources;

public class BalancesResource
{
    private readonly ApiClient _client;

    internal BalancesResource(ApiClient client) => _client = client;

    public Task<BalanceSnapshot> GetAsync(CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<BalanceSnapshot>("/balances", "balances", new { }, cancellationToken);
}
