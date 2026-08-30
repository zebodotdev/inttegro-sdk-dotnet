using Commerce.Http;
using Commerce.Responses;

namespace Commerce.Resources;

public class BalanceTransactionsResource
{
    private readonly ApiClient _client;

    internal BalanceTransactionsResource(ApiClient client) => _client = client;

    public Task<CommerceResponse> LookupAsync(string transactionId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/balance_transactions/lookup", new { transaction_id = transactionId }, cancellationToken);

    public Task<CommerceResponse> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/balance_transactions/page", payload ?? new { }, cancellationToken);
}
