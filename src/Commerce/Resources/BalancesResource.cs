using Commerce.Http;
using Commerce.Responses;

namespace Commerce.Resources;

public class BalancesResource
{
    private readonly ApiClient _client;

    internal BalancesResource(ApiClient client) => _client = client;

    public Task<CommerceResponse> GetAsync(CancellationToken cancellationToken = default) =>
        _client.PostAsync("/balances", new { }, cancellationToken);
}
