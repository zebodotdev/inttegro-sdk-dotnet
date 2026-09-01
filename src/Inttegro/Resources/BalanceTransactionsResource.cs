using Inttegro.Http;
using Inttegro.Responses;

namespace Inttegro.Resources;

public class BalanceTransactionsResource
{
    private readonly ApiClient _client;

    internal BalanceTransactionsResource(ApiClient client) => _client = client;

    public Task<InttegroResponse> LookupAsync(string transactionId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/balance_transactions/lookup", new { transaction_id = transactionId }, cancellationToken);

    public Task<InttegroResponse> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/balance_transactions/page", payload ?? new { }, cancellationToken);
}
