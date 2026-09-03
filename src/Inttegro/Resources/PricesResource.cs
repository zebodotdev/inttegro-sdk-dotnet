using Inttegro.Http;
using Inttegro;
using Inttegro.Validation;

namespace Inttegro.Resources;

public class PricesResource
{
    private readonly ApiClient _client;

    internal PricesResource(ApiClient client) => _client = client;

    public Task<Price> CreateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<Price>("/prices/create", "price", payload, cancellationToken);

    public Task<Price> CreateAsync(CreatePriceRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.Currency, "currency");
        RequestValidator.Require(payload.Amount, "amount");
        return _client.PostResourceAsync<Price>("/prices/create", "price", payload, cancellationToken);
    }

    public Task<Price> LookupAsync(string priceId, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<Price>("/prices/lookup", "price", new { price_id = priceId }, cancellationToken);

    public Task<Price> LookupAsync(LookupPriceRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.PriceId, "price_id");
        return _client.PostResourceAsync<Price>("/prices/lookup", "price", payload, cancellationToken);
    }

    public Task<Price> UpdateAsync(UpdatePriceRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.PriceId, "price_id");
        return _client.PostResourceAsync<Price>("/prices/update", "price", payload, cancellationToken);
    }

    public Task<Price> ActivateAsync(string priceId, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<Price>("/prices/activate", "price", new { price_id = priceId }, cancellationToken);

    public Task<Price> DeactivateAsync(string priceId, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<Price>("/prices/deactivate", "price", new { price_id = priceId }, cancellationToken);

    public Task<Price> ArchiveAsync(string priceId, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<Price>("/prices/archive", "price", new { price_id = priceId }, cancellationToken);

    public Task<PricePage> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<PricePage>("/prices/page", "page", payload ?? new { }, cancellationToken);

    public Task<PricePage> PageAsync(PricePageRequest payload, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<PricePage>("/prices/page", "page", payload, cancellationToken);
}
