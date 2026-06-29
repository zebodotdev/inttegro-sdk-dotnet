using Commerce.Http;
using Commerce.Responses;

namespace Commerce.Resources;

public class BalanceTransactionsResource
{
    private readonly ApiClient _client;

    public BalanceTransactionsResource(ApiClient client) => _client = client;

    public Task<CommerceResponse> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/balance_transactions/page", payload ?? new { }, cancellationToken);
}
