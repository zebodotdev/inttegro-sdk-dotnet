using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Inttegro.BankAccounts;

[JsonConverter(typeof(Inttegro.WireEnumJsonConverter<BankAccountType>))]
public enum BankAccountType
{
    [EnumMember(Value = "ghana_bank_account")]
    GhanaBankAccount
}

public sealed class BankAccountOwnerAddress
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("application_id")]
    public string? ApplicationId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("line_1")]
    public string? Line1 { get; set; }

    [JsonPropertyName("line_2")]
    public string? Line2 { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("region")]
    public string? Region { get; set; }

    [JsonPropertyName("post_code")]
    public string? PostCode { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }
}

public sealed class BankAccountOwner
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("address")]
    public BankAccountOwnerAddress? Address { get; set; }
}

public sealed class GhanaBankAccount
{
    [JsonPropertyName("bank_name")]
    public string? BankName { get; set; }

    [JsonPropertyName("branch")]
    public string? Branch { get; set; }

    [JsonPropertyName("number")]
    public string? Number { get; set; }

    [JsonPropertyName("sort_code")]
    public string? SortCode { get; set; }

    [JsonPropertyName("swift_code")]
    public string? SwiftCode { get; set; }

    [JsonPropertyName("holder")]
    public BankAccountOwner? Holder { get; set; }
}

public sealed class BankAccountConfig
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("type")]
    public BankAccountType Type { get; set; }

    [JsonPropertyName("ghana_bank_account")]
    public GhanaBankAccount? GhanaBankAccount { get; set; }
}
