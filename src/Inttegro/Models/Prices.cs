using System.Text.Json.Serialization;

namespace Inttegro.Models;

public sealed class CreatePriceRequest
{
    [JsonPropertyName("product_id")]
    public string? ProductId { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("about")]
    public string? About { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("amount")]
    public long? Amount { get; set; }
}

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

public sealed class PriceNominal
{
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("value")]
    public long? Value { get; set; }

    [JsonPropertyName("sign")]
    public int? Sign { get; set; }
}

public sealed class Price
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
    public PriceNominal? Nominal { get; set; }

    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    [JsonPropertyName("archived_at")]
    public string? ArchivedAt { get; set; }
}

public sealed class PriceResponse
{
    [JsonPropertyName("price")]
    public Price? Price { get; set; }

    [JsonPropertyName("error")]
    public ApiError? Error { get; set; }
}
