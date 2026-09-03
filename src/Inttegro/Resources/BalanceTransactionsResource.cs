using Inttegro.Http;

namespace Inttegro.Resources;

public class BalanceTransactionsResource
{
    private readonly ApiClient _client;

    internal BalanceTransactionsResource(ApiClient client) => _client = client;

    public Task<BalanceTransaction> LookupAsync(string transactionId, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<BalanceTransaction>("/balance_transactions/lookup", "transaction", new { transaction_id = transactionId }, cancellationToken);

    public Task<BalanceTransactionPage> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<BalanceTransactionPage>("/balance_transactions/page", "page", payload ?? new { }, cancellationToken);
}
