using System.Text.Json.Serialization;
using Inttegro.Money;

namespace Inttegro;

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
    public Amount? Nominal { get; set; }

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
    public Amount? Nominal { get; set; }
}

public sealed class ProductAttribute
{
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("value")] public string? Value { get; set; }
}

public sealed class ProductPhysicalDimensions
{
    [JsonPropertyName("weight_unit")] public string? WeightUnit { get; set; }
    [JsonPropertyName("weight")] public decimal? Weight { get; set; }
    [JsonPropertyName("size")] public decimal? Size { get; set; }
    [JsonPropertyName("volume_unit")] public string? VolumeUnit { get; set; }
    [JsonPropertyName("volume")] public decimal? Volume { get; set; }
    [JsonPropertyName("length")] public decimal? Length { get; set; }
    [JsonPropertyName("height")] public decimal? Height { get; set; }
    [JsonPropertyName("width")] public decimal? Width { get; set; }
}

public sealed class ProductDigitalDimensions
{
    [JsonPropertyName("bytes")] public decimal? Bytes { get; set; }
    [JsonPropertyName("size_unit")] public string? SizeUnit { get; set; }
    [JsonPropertyName("size")] public decimal? Size { get; set; }
}

public sealed class ProductCustomDimensions
{
    [JsonPropertyName("size_unit")] public string? SizeUnit { get; set; }
    [JsonPropertyName("size")] public decimal? Size { get; set; }
    [JsonPropertyName("details")] public ProductDimensionDetails? Details { get; set; }
}

public sealed class ProductDimensions
{
    [JsonPropertyName("physical")] public ProductPhysicalDimensions? Physical { get; set; }
    [JsonPropertyName("digital")] public ProductDigitalDimensions? Digital { get; set; }
    [JsonPropertyName("custom")] public ProductCustomDimensions? Custom { get; set; }
}

public sealed class ProductMedia
{
    [JsonPropertyName("hero_image")] public string? HeroImage { get; set; }
    [JsonPropertyName("thumbnail")] public string? Thumbnail { get; set; }
    [JsonPropertyName("web_page_url")] public string? WebPageUrl { get; set; }
    [JsonPropertyName("brand_logo")] public string? BrandLogo { get; set; }
    [JsonPropertyName("infographic")] public string? Infographic { get; set; }
    [JsonPropertyName("promo_video")] public string? PromoVideo { get; set; }
    [JsonPropertyName("demo_video")] public string? DemoVideo { get; set; }
    [JsonPropertyName("gallery")] public List<string>? Gallery { get; set; }
    [JsonPropertyName("downloads")] public List<string>? Downloads { get; set; }
}

public sealed class ProductShipment
{
    [JsonPropertyName("type")] public string? Type { get; set; }
    [JsonPropertyName("delivery")] public JsonData? Delivery { get; set; }
    [JsonPropertyName("download")] public JsonData? Download { get; set; }
    [JsonPropertyName("render")] public JsonData? Render { get; set; }
    [JsonPropertyName("service")] public JsonData? Service { get; set; }
    [JsonPropertyName("stream")] public JsonData? Stream { get; set; }
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
    public string? Category { get; set; }

    [JsonPropertyName("shipment")]
    public ProductShipment? Shipment { get; set; }

    [JsonPropertyName("dimensions")]
    public ProductDimensions? Dimensions { get; set; }

    [JsonPropertyName("unit_dimension")]
    public string? UnitDimension { get; set; }

    [JsonPropertyName("media")]
    public ProductMedia? Media { get; set; }

    [JsonPropertyName("attributes")]
    public List<ProductAttribute>? Attributes { get; set; }

    [JsonPropertyName("publish")]
    public bool? Publish { get; set; }

    [JsonPropertyName("custom_data")]
    public CustomData? CustomData { get; set; }
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

    [JsonPropertyName("type")]
    public ProductType? Type { get; set; }

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
    public string? Category { get; set; }

    [JsonPropertyName("shipment")]
    public ProductShipment? Shipment { get; set; }

    [JsonPropertyName("dimensions")]
    public ProductDimensions? Dimensions { get; set; }

    [JsonPropertyName("unit_dimension")]
    public string? UnitDimension { get; set; }

    [JsonPropertyName("media")]
    public ProductMedia? Media { get; set; }

    [JsonPropertyName("attributes")]
    public List<ProductAttribute>? Attributes { get; set; }

    [JsonPropertyName("custom_data")]
    public CustomData? CustomData { get; set; }
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
    public AmountParams? Amount { get; set; }

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
    public string? Category { get; set; }

    [JsonPropertyName("default_unit_price")]
    public ProductDefaultUnitPrice? DefaultUnitPrice { get; set; }

    [JsonPropertyName("prices")]
    public List<ProductPriceSummary>? Prices { get; set; }

    [JsonPropertyName("shipment")]
    public ProductShipment? Shipment { get; set; }

    [JsonPropertyName("dimensions")]
    public ProductDimensions? Dimensions { get; set; }

    [JsonPropertyName("unit_dimension")]
    public string? UnitDimension { get; set; }

    [JsonPropertyName("media")]
    public ProductMedia? Media { get; set; }

    [JsonPropertyName("attributes")]
    public List<ProductAttribute>? Attributes { get; set; }

    [JsonPropertyName("custom_data")]
    public CustomData? CustomData { get; set; }

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

public sealed class ProductPage
{
    [JsonPropertyName("number")]
    public int? Number { get; set; }

    [JsonPropertyName("size")]
    public int? Size { get; set; }

    [JsonPropertyName("products")]
    public List<Product>? Products { get; set; }
}
