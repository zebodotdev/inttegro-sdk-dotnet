using System.Text.Json.Serialization;
using Inttegro.Money;

namespace Inttegro;

public sealed class CatalogPriceParams
{
    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("about")]
    public string? About { get; set; }

    [JsonPropertyName("amount")]
    public AmountParams? Amount { get; set; }
}

public sealed class PriceParams : AmountParams { }

public sealed class Price : Amount { }

public sealed class LookupPriceRequest
{
    [JsonPropertyName("price_id")]
    public string? PriceId { get; set; }
}

public sealed class UpdatePriceRequest
{
    [JsonPropertyName("price_id")]
    public string? PriceId { get; set; }

    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("about")]
    public string? About { get; set; }
}

public sealed class PricePageRequest
{
    [JsonPropertyName("page_number")]
    public int? PageNumber { get; set; }

    [JsonPropertyName("page_size")]
    public int? PageSize { get; set; }

    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }
}

public sealed class CatalogPrice
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("about")]
    public string? About { get; set; }

    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("nominal")]
    public Amount? Nominal { get; set; }

    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }

    [JsonPropertyName("product")]
    public Product? Product { get; set; }

    [JsonPropertyName("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }

    [JsonPropertyName("archived_at")]
    public DateTimeOffset? ArchivedAt { get; set; }
}

public sealed class PricePage
{
    [JsonPropertyName("number")]
    public int? Number { get; set; }

    [JsonPropertyName("size")]
    public int? Size { get; set; }

    [JsonPropertyName("prices")]
    public List<CatalogPrice>? Prices { get; set; }
}
