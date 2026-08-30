using Commerce.Http;
using Commerce.Responses;

namespace Commerce.Resources;

public class PurchaseIntentsResource
{
    private readonly ApiClient _client;

    internal PurchaseIntentsResource(ApiClient client) => _client = client;

    public Task<CommerceResponse> CreateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/purchase_intents/create", payload, cancellationToken);

    public Task<CommerceResponse> LookupAsync(string id, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/purchase_intents/lookup", new { id }, cancellationToken);

    public Task<CommerceResponse> LookupAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/purchase_intents/lookup", payload, cancellationToken);

    public Task<CommerceResponse> PageAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/purchase_intents/page", payload, cancellationToken);

    public Task<CommerceResponse> UpdateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/purchase_intents/update", payload, cancellationToken);

    public Task<CommerceResponse> CancelAsync(string id, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/purchase_intents/cancel", new { id }, cancellationToken);

    public Task<CommerceResponse> CancelAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/purchase_intents/cancel", payload, cancellationToken);
}
