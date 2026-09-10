using System.Text.Json.Serialization;
using Inttegro.Money;

namespace Inttegro;

public sealed class PurchaseIntent
{
    [JsonPropertyName("activity")] public PurchaseIntentActivityLog? Activity { get; set; }
    [JsonPropertyName("allow_variants")] public bool AllowVariants { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset CreatedAt { get; set; }
    [JsonPropertyName("expires_at")] public DateTimeOffset? ExpiresAt { get; set; }
    [JsonPropertyName("id")] public string Id { get; set; } = null!;
    [JsonPropertyName("inactive_at")] public DateTimeOffset? InactiveAt { get; set; }
    [JsonPropertyName("merchant")] public PurchaseIntentMerchant? Merchant { get; set; }
    [JsonPropertyName("price")] public PurchaseIntentPrice? Price { get; set; }
    [JsonPropertyName("product")] public PurchaseIntentProduct? Product { get; set; }
    [JsonPropertyName("quantity")] public PurchaseIntentQuantity Quantity { get; set; } = null!;
    [JsonPropertyName("status")] public PurchaseIntentStatus Status { get; set; }
    [JsonPropertyName("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
    [JsonPropertyName("usage")] public PurchaseIntentUsage Usage { get; set; } = null!;
    [JsonPropertyName("variant_set")] public PurchaseIntentVariantSet? VariantSet { get; set; }
}

public sealed class PurchaseIntentActivityLog
{
    [JsonPropertyName("recent")] public List<PurchaseIntentActivity>? Recent { get; set; }
}

public sealed class PurchaseIntentActivity
{
    [JsonPropertyName("amount")] public Amount? Amount { get; set; }
    [JsonPropertyName("attribution")] public PurchaseIntentActivityAttribution? Attribution { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset CreatedAt { get; set; }
    [JsonPropertyName("error_code")] public string? ErrorCode { get; set; }
    [JsonPropertyName("id")] public string Id { get; set; } = null!;
    [JsonPropertyName("order_id")] public string? OrderId { get; set; }
    [JsonPropertyName("payment_id")] public string? PaymentId { get; set; }
    [JsonPropertyName("product_id")] public string? ProductId { get; set; }
    [JsonPropertyName("purchase_intent_id")] public string PurchaseIntentId { get; set; } = null!;
    [JsonPropertyName("quantity")] public int? Quantity { get; set; }
    [JsonPropertyName("source")] public string? Source { get; set; }
    [JsonPropertyName("type")] public PurchaseIntentActivityType Type { get; set; }
    [JsonPropertyName("variant_product_id")] public string? VariantProductId { get; set; }
    [JsonPropertyName("visitor")] public PurchaseIntentActivityVisitor? Visitor { get; set; }
}

public sealed class PurchaseIntentActivityAttribution
{
    [JsonPropertyName("campaign")] public string? Campaign { get; set; }
    [JsonPropertyName("channel")] public string? Channel { get; set; }
    [JsonPropertyName("content")] public string? Content { get; set; }
    [JsonPropertyName("landing_url")] public string? LandingUrl { get; set; }
    [JsonPropertyName("medium")] public string? Medium { get; set; }
    [JsonPropertyName("referrer")] public string? Referrer { get; set; }
    [JsonPropertyName("referrer_host")] public string? ReferrerHost { get; set; }
    [JsonPropertyName("source")] public string? Source { get; set; }
    [JsonPropertyName("term")] public string? Term { get; set; }
}

public sealed class PurchaseIntentActivityVisitor
{
    [JsonPropertyName("browser")] public string? Browser { get; set; }
    [JsonPropertyName("city")] public string? City { get; set; }
    [JsonPropertyName("country")] public string? Country { get; set; }
    [JsonPropertyName("device")] public string? Device { get; set; }
    [JsonPropertyName("ip_address")] public string? IpAddress { get; set; }
    [JsonPropertyName("os")] public string? Os { get; set; }
    [JsonPropertyName("region")] public string? Region { get; set; }
    [JsonPropertyName("session_id")] public string? SessionId { get; set; }
    [JsonPropertyName("timezone")] public string? Timezone { get; set; }
    [JsonPropertyName("user_agent")] public string? UserAgent { get; set; }
    [JsonPropertyName("visitor_id")] public string? VisitorId { get; set; }
}

public sealed class PurchaseIntentMerchant
{
    [JsonPropertyName("app_name")] public string? AppName { get; set; }
    [JsonPropertyName("organization_id")] public string? OrganizationId { get; set; }
    [JsonPropertyName("organization_name")] public string? OrganizationName { get; set; }
}

public sealed class PurchaseIntentProduct
{
    [JsonPropertyName("id")] public string Id { get; set; } = null!;
    [JsonPropertyName("about")] public string? About { get; set; }
    [JsonPropertyName("active")] public bool Active { get; set; }
    [JsonPropertyName("archived_at")] public DateTimeOffset? ArchivedAt { get; set; }
    [JsonPropertyName("attributes")] public List<ProductAttribute>? Attributes { get; set; }
    [JsonPropertyName("category")] public string? Category { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset CreatedAt { get; set; }
    [JsonPropertyName("custom_data")] public CustomData? CustomData { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("dimensions")] public ProductDimensions? Dimensions { get; set; }
    [JsonPropertyName("media")] public ProductMedia? Media { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; } = null!;
    [JsonPropertyName("prices")] public List<ProductPriceSummary>? Prices { get; set; }
    [JsonPropertyName("published_at")] public DateTimeOffset? PublishedAt { get; set; }
    [JsonPropertyName("reference")] public string? Reference { get; set; }
    [JsonPropertyName("shipment")] public ProductShipment? Shipment { get; set; }
    [JsonPropertyName("tax_code")] public string? TaxCode { get; set; }
    [JsonPropertyName("type")] public ProductType Type { get; set; }
    [JsonPropertyName("unit_dim")] public string? UnitDim { get; set; }
    [JsonPropertyName("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
    [JsonPropertyName("variant_set_id")] public string? VariantSetId { get; set; }
}

public sealed class PurchaseIntentUsageOrder
{
    [JsonPropertyName("created_at")] public DateTimeOffset CreatedAt { get; set; }
    [JsonPropertyName("id")] public string Id { get; set; } = null!;
}

public sealed class PurchaseIntentVariantAxis
{
    [JsonPropertyName("key")] public string Key { get; set; } = null!;
    [JsonPropertyName("label")] public string Label { get; set; } = null!;
    [JsonPropertyName("position")] public int Position { get; set; }
}

public sealed class PurchaseIntentVariant
{
    [JsonPropertyName("active")] public bool Active { get; set; }
    [JsonPropertyName("position")] public int? Position { get; set; }
    [JsonPropertyName("price")] public PurchaseIntentPrice? Price { get; set; }
    [JsonPropertyName("product")] public PurchaseIntentProduct? Product { get; set; }
    [JsonPropertyName("product_id")] public string ProductId { get; set; } = null!;
    [JsonPropertyName("variant_values")] public Dictionary<string, string> VariantValues { get; set; } = null!;
}

public sealed class PurchaseIntentVariantSet
{
    [JsonPropertyName("active")] public bool Active { get; set; }
    [JsonPropertyName("default_product_id")] public string? DefaultProductId { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("id")] public string Id { get; set; } = null!;
    [JsonPropertyName("name")] public string Name { get; set; } = null!;
    [JsonPropertyName("reference")] public string? Reference { get; set; }
    [JsonPropertyName("variant_axes")] public List<PurchaseIntentVariantAxis> VariantAxes { get; set; } = null!;
    [JsonPropertyName("variants")] public List<PurchaseIntentVariant> Variants { get; set; } = null!;
}

public sealed class PurchaseIntentPage
{
    [JsonPropertyName("number")] public int Number { get; set; }
    [JsonPropertyName("size")] public int Size { get; set; }
    [JsonPropertyName("purchase_intents")] public List<PurchaseIntent> PurchaseIntents { get; set; } = null!;
}
