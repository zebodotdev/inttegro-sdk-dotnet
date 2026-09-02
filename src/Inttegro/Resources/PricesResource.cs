using Inttegro.Http;
using Inttegro;
using Inttegro.Responses;
using Inttegro.Validation;

namespace Inttegro.Resources;

public class PricesResource
{
    private readonly ApiClient _client;

    internal PricesResource(ApiClient client) => _client = client;

    public Task<InttegroResponse> CreateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/prices/create", payload, cancellationToken);

    public Task<InttegroResponse> CreateAsync(CreatePriceRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.Currency, "currency");
        RequestValidator.Require(payload.Amount, "amount");
        return _client.PostAsync("/prices/create", payload, cancellationToken);
    }

    public Task<InttegroResponse> LookupAsync(string priceId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/prices/lookup", new { price_id = priceId }, cancellationToken);

    public Task<InttegroResponse> LookupAsync(LookupPriceRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.PriceId, "price_id");
        return _client.PostAsync("/prices/lookup", payload, cancellationToken);
    }

    public Task<InttegroResponse> UpdateAsync(UpdatePriceRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.PriceId, "price_id");
        return _client.PostAsync("/prices/update", payload, cancellationToken);
    }

    public Task<InttegroResponse> ActivateAsync(string priceId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/prices/activate", new { price_id = priceId }, cancellationToken);

    public Task<InttegroResponse> DeactivateAsync(string priceId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/prices/deactivate", new { price_id = priceId }, cancellationToken);

    public Task<InttegroResponse> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/prices/page", payload ?? new { }, cancellationToken);

    public Task<InttegroResponse> PageAsync(PricePageRequest payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/prices/page", payload, cancellationToken);
}
