using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Inttegro;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum FinancialAccountType
{
    [EnumMember(Value = "wallet")]
    Wallet,
    [EnumMember(Value = "bank_account")]
    BankAccount,
    [EnumMember(Value = "dosh_account")]
    DoshAccount
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum WalletType
{
    [EnumMember(Value = "mobile_money")]
    MobileMoney
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BankAccountType
{
    [EnumMember(Value = "ghana_bank_account")]
    GhanaBankAccount
}

public sealed class PullPushConfig
{
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("enabled_at")]
    public string? EnabledAt { get; set; }

    [JsonPropertyName("mandate")]
    public JsonObject? Mandate { get; set; }
}

public sealed class WalletMobileMoney
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("account_number")]
    public string? AccountNumber { get; set; }

    [JsonPropertyName("network")]
    public string? Network { get; set; }
}

public sealed class WalletConfig
{
    [JsonPropertyName("type")]
    public WalletType Type { get; set; }

    [JsonPropertyName("mobile_money")]
    public WalletMobileMoney? MobileMoney { get; set; }
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

public sealed class FinancialAccountCreateRequest
{
    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("type")]
    public FinancialAccountType Type { get; set; }

    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("pull_configuration")]
    public PullPushConfig? PullConfiguration { get; set; }

    [JsonPropertyName("push_configuration")]
    public PullPushConfig? PushConfiguration { get; set; }

    [JsonPropertyName("wallet")]
    public WalletConfig? Wallet { get; set; }

    [JsonPropertyName("bank_account")]
    public BankAccountConfig? BankAccount { get; set; }

    [JsonPropertyName("dosh_account")]
    public JsonObject? DoshAccount { get; set; }

    [JsonPropertyName("custom_data")]
    public Dictionary<string, string>? CustomData { get; set; }

    [JsonPropertyName("owner")]
    public BankAccountOwner? Owner { get; set; }
}

public sealed class FinancialAccount
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("verification")]
    public JsonObject? Verification { get; set; }

    [JsonPropertyName("push_configuration")]
    public PullPushConfig? PushConfiguration { get; set; }

    [JsonPropertyName("pull_configuration")]
    public PullPushConfig? PullConfiguration { get; set; }

    [JsonPropertyName("archived_at")]
    public string? ArchivedAt { get; set; }

    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    [JsonPropertyName("disconnected_at")]
    public string? DisconnectedAt { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("type")]
    public FinancialAccountType Type { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    [JsonPropertyName("wallet")]
    public WalletConfig? Wallet { get; set; }

    [JsonPropertyName("bank_account")]
    public BankAccountConfig? BankAccount { get; set; }

    [JsonPropertyName("dosh_account")]
    public JsonObject? DoshAccount { get; set; }

    [JsonPropertyName("custom_data")]
    public Dictionary<string, string>? CustomData { get; set; }

    [JsonPropertyName("owner")]
    public BankAccountOwner? Owner { get; set; }
}

public sealed class FinancialAccountUpdateRequest
{
    [JsonPropertyName("account_id")]
    public string? AccountId { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    [JsonPropertyName("custom_data")]
    public Dictionary<string, string?>? CustomData { get; set; }

    [JsonPropertyName("owner")]
    public BankAccountOwner? Owner { get; set; }
}

public sealed class FinancialAccountToggleRequest
{
    [JsonPropertyName("account_id")]
    public string? AccountId { get; set; }

    [JsonPropertyName("unset_as_payout_destination")]
    public bool? UnsetAsPayoutDestination { get; set; }
}

public sealed class FinancialAccountResponse
{
    [JsonPropertyName("account")]
    public FinancialAccount? Account { get; set; }
}

public sealed class FinancialAccountLookupRequest
{
    [JsonPropertyName("account_id")]
    public string? AccountId { get; set; }
}

public sealed class FinancialAccountArchiveRequest
{
    [JsonPropertyName("account_id")]
    public string? AccountId { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? Extra { get; set; }
}

public sealed class FinancialAccountPageRequest
{
    [JsonPropertyName("page_number")]
    public int? PageNumber { get; set; }

    [JsonPropertyName("page_size")]
    public int? PageSize { get; set; }
}

public sealed class FinancialAccountPageResponse
{
    [JsonPropertyName("page")]
    public FinancialAccountPage? Page { get; set; }
}

public sealed class FinancialAccountPage
{
    [JsonPropertyName("number")]
    public int? Number { get; set; }

    [JsonPropertyName("size")]
    public int? Size { get; set; }

    [JsonPropertyName("accounts")]
    public List<FinancialAccount>? Accounts { get; set; }
}

public sealed class FinancialAccountVerifyRequest
{
    [JsonPropertyName("account_id")]
    public string? AccountId { get; set; }

    [JsonPropertyName("token")]
    public string? Token { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? Extra { get; set; }
}
