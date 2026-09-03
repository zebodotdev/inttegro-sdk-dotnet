using System.Text.Json.Serialization;
using System.Text.Json.Nodes;

namespace Inttegro;

public sealed class CreateCustomerRequest
{
    [JsonPropertyName("request_meta")]
    public RequestMeta? RequestMeta { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("suffix")]
    public string? Suffix { get; set; }

    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    [JsonPropertyName("email_address")]
    public string? EmailAddress { get; set; }

    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName("custom_data")]
    public Dictionary<string, string>? CustomData { get; set; }
}

public sealed class LookupCustomerRequest
{
    [JsonPropertyName("customer_id")]
    public string? CustomerId { get; set; }
}

public sealed class UpdateCustomerRequest
{
    [JsonPropertyName("billing_address")]
    public Address? BillingAddress { get; set; }

    [JsonPropertyName("custom_data")]
    public Dictionary<string, JsonNode?>? CustomData { get; set; }

    [JsonPropertyName("customer_id")]
    public string? CustomerId { get; set; }

    [JsonPropertyName("email_address")]
    public string? EmailAddress { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    [JsonPropertyName("shipping_address")]
    public Address? ShippingAddress { get; set; }

    [JsonPropertyName("suffix")]
    public string? Suffix { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }
}

public sealed class PageCustomersRequest
{
    [JsonPropertyName("page_number")]
    public int? PageNumber { get; set; }

    [JsonPropertyName("page_size")]
    public int? PageSize { get; set; }
}

public sealed class Customer
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("suffix")]
    public string? Suffix { get; set; }

    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    [JsonPropertyName("email_address")]
    public string? EmailAddress { get; set; }

    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName("custom_data")]
    public Dictionary<string, string>? CustomData { get; set; }

    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }
}

public sealed class CustomersPage
{
    [JsonPropertyName("number")]
    public int? Number { get; set; }

    [JsonPropertyName("size")]
    public int? Size { get; set; }

    [JsonPropertyName("customers")]
    public List<Customer>? Customers { get; set; }
}
