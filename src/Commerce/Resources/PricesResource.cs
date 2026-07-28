using Commerce.Http;
using Commerce.Models;
using Commerce.Responses;
using Commerce.Validation;

namespace Commerce.Resources;

public class PricesResource
{
    private readonly ApiClient _client;

    internal PricesResource(ApiClient client) => _client = client;

    public Task<CommerceResponse> CreateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/prices/create", payload, cancellationToken);

    public Task<CommerceResponse> CreateAsync(CreatePriceRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.Currency, "currency");
        RequestValidator.Require(payload.Amount, "amount");
        return _client.PostAsync("/prices/create", payload, cancellationToken);
    }

    public Task<CommerceResponse> LookupAsync(string priceId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/prices/lookup", new { price_id = priceId }, cancellationToken);

    public Task<CommerceResponse> LookupAsync(LookupPriceRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.PriceId, "price_id");
        return _client.PostAsync("/prices/lookup", payload, cancellationToken);
    }

    public Task<CommerceResponse> UpdateAsync(UpdatePriceRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.PriceId, "price_id");
        return _client.PostAsync("/prices/update", payload, cancellationToken);
    }
}
