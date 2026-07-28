using Commerce.Http;
using Commerce.Models;
using Commerce.Responses;
using Commerce.Validation;

namespace Commerce.Resources;

public class ProductsResource
{
    private readonly ApiClient _client;

    internal ProductsResource(ApiClient client) => _client = client;

    public Task<CommerceResponse> CreateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/products/create", payload, cancellationToken);

    public Task<CommerceResponse> CreateAsync(CreateProductRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.Type, "type");
        RequestValidator.Require(payload.Name, "name");
        return _client.PostAsync("/products/create", payload, cancellationToken);
    }

    public Task<CommerceResponse> AddPriceAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/products/add_price", payload, cancellationToken);

    public Task<CommerceResponse> AddPriceAsync(AddProductPriceRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.ProductId, "product_id");
        RequestValidator.Require(payload.Amount, "amount");
        return _client.PostAsync("/products/add_price", payload, cancellationToken);
    }

    public Task<CommerceResponse> SetDefaultUnitPriceAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/products/set_default_unit_price", payload, cancellationToken);

    public Task<CommerceResponse> SetDefaultUnitPriceAsync(SetDefaultUnitPriceRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.ProductId, "product_id");
        RequestValidator.Require(payload.PriceId, "price_id");
        return _client.PostAsync("/products/set_default_unit_price", payload, cancellationToken);
    }

    public Task<CommerceResponse> LookupAsync(string productId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/products/lookup", new { product_id = productId }, cancellationToken);

    public Task<CommerceResponse> LookupAsync(LookupProductRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.ProductId, "product_id");
        return _client.PostAsync("/products/lookup", payload, cancellationToken);
    }

    public Task<CommerceResponse> UpdateAsync(UpdateProductRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.ProductId, "product_id");
        return _client.PostAsync("/products/update", payload, cancellationToken);
    }

    public Task<CommerceResponse> PublishAsync(ProductActionRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.ProductId, "product_id");
        return _client.PostAsync("/products/publish", payload, cancellationToken);
    }

    public Task<CommerceResponse> UnpublishAsync(ProductActionRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.ProductId, "product_id");
        return _client.PostAsync("/products/unpublish", payload, cancellationToken);
    }

    public Task<CommerceResponse> ArchiveAsync(ProductActionRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.ProductId, "product_id");
        return _client.PostAsync("/products/archive", payload, cancellationToken);
    }

    public Task<CommerceResponse> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/products/page", payload ?? new { }, cancellationToken);

    public Task<CommerceResponse> PageAsync(PageProductsRequest payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/products/page", payload, cancellationToken);
}
