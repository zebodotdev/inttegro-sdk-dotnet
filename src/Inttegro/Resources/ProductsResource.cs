using Inttegro.Http;
using Inttegro.Models;
using Inttegro.Responses;
using Inttegro.Validation;

namespace Inttegro.Resources;

public class ProductsResource
{
    private readonly ApiClient _client;

    internal ProductsResource(ApiClient client) => _client = client;

    public Task<InttegroResponse> CreateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/products/create", payload, cancellationToken);

    public Task<InttegroResponse> CreateAsync(CreateProductRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.Type, "type");
        RequestValidator.Require(payload.Name, "name");
        return _client.PostAsync("/products/create", payload, cancellationToken);
    }

    public Task<InttegroResponse> AddPriceAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/products/add_price", payload, cancellationToken);

    public Task<InttegroResponse> AddPriceAsync(AddProductPriceRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.ProductId, "product_id");
        RequestValidator.Require(payload.Amount, "amount");
        return _client.PostAsync("/products/add_price", payload, cancellationToken);
    }

    public Task<InttegroResponse> SetDefaultUnitPriceAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/products/set_default_unit_price", payload, cancellationToken);

    public Task<InttegroResponse> SetDefaultUnitPriceAsync(SetDefaultUnitPriceRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.ProductId, "product_id");
        RequestValidator.Require(payload.PriceId, "price_id");
        return _client.PostAsync("/products/set_default_unit_price", payload, cancellationToken);
    }

    public Task<InttegroResponse> LookupAsync(string productId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/products/lookup", new { product_id = productId }, cancellationToken);

    public Task<InttegroResponse> LookupAsync(LookupProductRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.ProductId, "product_id");
        return _client.PostAsync("/products/lookup", payload, cancellationToken);
    }

    public Task<InttegroResponse> UpdateAsync(UpdateProductRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.ProductId, "product_id");
        return _client.PostAsync("/products/update", payload, cancellationToken);
    }

    public Task<InttegroResponse> UpdateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/products/update", payload, cancellationToken);

    public Task<InttegroResponse> PublishAsync(ProductActionRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.ProductId, "product_id");
        return _client.PostAsync("/products/publish", payload, cancellationToken);
    }

    public Task<InttegroResponse> PublishAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/products/publish", payload, cancellationToken);

    public Task<InttegroResponse> UnpublishAsync(ProductActionRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.ProductId, "product_id");
        return _client.PostAsync("/products/unpublish", payload, cancellationToken);
    }

    public Task<InttegroResponse> UnpublishAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/products/unpublish", payload, cancellationToken);

    public Task<InttegroResponse> ArchiveAsync(ProductActionRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.ProductId, "product_id");
        return _client.PostAsync("/products/archive", payload, cancellationToken);
    }

    public Task<InttegroResponse> ArchiveAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/products/archive", payload, cancellationToken);

    public Task<InttegroResponse> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/products/page", payload ?? new { }, cancellationToken);

    public Task<InttegroResponse> PageAsync(PageProductsRequest payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/products/page", payload, cancellationToken);
}
