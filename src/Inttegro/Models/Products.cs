using System.Text.Json.Serialization;

namespace Inttegro.Models;

public sealed class ProductCategory
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("slug")]
    public string? Slug { get; set; }
}

public sealed class ProductPrice
{
    [JsonPropertyName("amount")]
    public long? Amount { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }
}

public sealed class ProductPriceAmount
{
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("value")]
    public long? Value { get; set; }
}

public sealed class ProductDefaultUnitPrice
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("about")]
    public string? About { get; set; }

    [JsonPropertyName("nominal")]
    public ProductPriceAmount? Nominal { get; set; }

    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    [JsonPropertyName("archived_at")]
    public string? ArchivedAt { get; set; }
}

public sealed class ProductPriceSummary
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("nominal")]
    public ProductPriceAmount? Nominal { get; set; }
}

public sealed class ProductShipmentDimensions
{
    [JsonPropertyName("length")]
    public decimal? Length { get; set; }

    [JsonPropertyName("width")]
    public decimal? Width { get; set; }

    [JsonPropertyName("height")]
    public decimal? Height { get; set; }

    [JsonPropertyName("weight")]
    public decimal? Weight { get; set; }
}

public sealed class ProductShipment
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("carrier")]
    public string? Carrier { get; set; }

    [JsonPropertyName("dimensions")]
    public ProductShipmentDimensions? Dimensions { get; set; }
}

public sealed class ProductMediaItem
{
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}

public sealed class CreateProductRequest
{
    [JsonPropertyName("type")]
    public ProductType Type { get; set; }

    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("about")]
    public string? About { get; set; }

    [JsonPropertyName("tax_code")]
    public string? TaxCode { get; set; }

    [JsonPropertyName("category")]
    public ProductCategory? Category { get; set; }

    [JsonPropertyName("price")]
    public ProductPrice? Price { get; set; }

    [JsonPropertyName("shipment")]
    public ProductShipment? Shipment { get; set; }

    [JsonPropertyName("media")]
    public List<ProductMediaItem>? Media { get; set; }

    [JsonPropertyName("attributes")]
    public Dictionary<string, string>? Attributes { get; set; }

    [JsonPropertyName("custom_data")]
    public Dictionary<string, string>? CustomData { get; set; }
}

public sealed class LookupProductRequest
{
    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }
}

public sealed class UpdateProductRequest
{
    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }

    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("about")]
    public string? About { get; set; }

    [JsonPropertyName("tax_code")]
    public string? TaxCode { get; set; }

    [JsonPropertyName("category")]
    public ProductCategory? Category { get; set; }

    [JsonPropertyName("price")]
    public ProductPrice? Price { get; set; }

    [JsonPropertyName("shipment")]
    public ProductShipment? Shipment { get; set; }

    [JsonPropertyName("media")]
    public List<ProductMediaItem>? Media { get; set; }

    [JsonPropertyName("attributes")]
    public Dictionary<string, string>? Attributes { get; set; }

    [JsonPropertyName("custom_data")]
    public Dictionary<string, string>? CustomData { get; set; }
}

public sealed class ProductActionRequest
{
    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }
}

public sealed class AddProductPriceRequest
{
    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("about")]
    public string? About { get; set; }

    [JsonPropertyName("amount")]
    public ProductPriceAmount? Amount { get; set; }

    [JsonPropertyName("set_as_default")]
    public bool? SetAsDefault { get; set; }
}

public sealed class SetDefaultUnitPriceRequest
{
    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }

    [JsonPropertyName("price_id")]
    public string? PriceId { get; set; }
}

public sealed class PageProductsRequest
{
    [JsonPropertyName("page_number")]
    public int? PageNumber { get; set; }

    [JsonPropertyName("page_size")]
    public int? PageSize { get; set; }
}

public sealed class Product
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("application_id")]
    public string? ApplicationId { get; set; }

    [JsonPropertyName("type")]
    public ProductType Type { get; set; }

    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("about")]
    public string? About { get; set; }

    [JsonPropertyName("tax_code")]
    public string? TaxCode { get; set; }

    [JsonPropertyName("category")]
    public ProductCategory? Category { get; set; }

    [JsonPropertyName("price")]
    public ProductPrice? Price { get; set; }

    [JsonPropertyName("default_unit_price")]
    public ProductDefaultUnitPrice? DefaultUnitPrice { get; set; }

    [JsonPropertyName("prices")]
    public List<ProductPriceSummary>? Prices { get; set; }

    [JsonPropertyName("shipment")]
    public ProductShipment? Shipment { get; set; }

    [JsonPropertyName("media")]
    public List<ProductMediaItem>? Media { get; set; }

    [JsonPropertyName("attributes")]
    public Dictionary<string, string>? Attributes { get; set; }

    [JsonPropertyName("custom_data")]
    public Dictionary<string, string>? CustomData { get; set; }

    [JsonPropertyName("active")]
    public bool? Active { get; set; }

    [JsonPropertyName("archived")]
    public bool? Archived { get; set; }

    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    [JsonPropertyName("archived_at")]
    public string? ArchivedAt { get; set; }
}

public sealed class ProductResponse
{
    [JsonPropertyName("product")]
    public Product? Product { get; set; }

    [JsonPropertyName("error")]
    public ApiError? Error { get; set; }
}

public sealed class AddProductPriceResponse
{
    [JsonPropertyName("price")]
    public ProductDefaultUnitPrice? Price { get; set; }

    [JsonPropertyName("error")]
    public ApiError? Error { get; set; }
}

public sealed class ProductPage
{
    [JsonPropertyName("number")]
    public int? Number { get; set; }

    [JsonPropertyName("size")]
    public int? Size { get; set; }

    [JsonPropertyName("products")]
    public List<Product>? Products { get; set; }
}

public sealed class PageProductsResponse
{
    [JsonPropertyName("page")]
    public ProductPage? Page { get; set; }

    [JsonPropertyName("error")]
    public ApiError? Error { get; set; }
}
