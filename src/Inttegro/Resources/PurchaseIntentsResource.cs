using Inttegro.Http;
using Inttegro.Responses;

namespace Inttegro.Resources;

public class PurchaseIntentsResource
{
    private readonly ApiClient _client;

    internal PurchaseIntentsResource(ApiClient client) => _client = client;

    public Task<InttegroResponse> CreateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/purchase_intents/create", payload, cancellationToken);

    public Task<InttegroResponse> LookupAsync(string id, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/purchase_intents/lookup", new { id }, cancellationToken);

    public Task<InttegroResponse> LookupAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/purchase_intents/lookup", payload, cancellationToken);

    public Task<InttegroResponse> PageAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/purchase_intents/page", payload, cancellationToken);

    public Task<InttegroResponse> UpdateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/purchase_intents/update", payload, cancellationToken);

    public Task<InttegroResponse> CancelAsync(string id, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/purchase_intents/cancel", new { id }, cancellationToken);

    public Task<InttegroResponse> CancelAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/purchase_intents/cancel", payload, cancellationToken);
}
