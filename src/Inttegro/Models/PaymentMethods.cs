using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Inttegro.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MobileMoneyNetwork
{
    [EnumMember(Value = "mtn")]
    Mtn,
    [EnumMember(Value = "vodafone")]
    Vodafone,
    [EnumMember(Value = "airteltigo")]
    AirtelTigo,
    [EnumMember(Value = "airtel")]
    Airtel,
    [EnumMember(Value = "telecel")]
    Telecel
}

public sealed class MobileMoney
{
    [JsonPropertyName("network")]
    public MobileMoneyNetwork Network { get; set; }

    [JsonPropertyName("account_number")]
    public string? AccountNumber { get; set; }
}

public sealed class PaymentMethodMobileMoney
{
    [JsonPropertyName("account_number")]
    public string? AccountNumber { get; set; }

    [JsonPropertyName("network")]
    public string? Network { get; set; }
}

public sealed class PaymentMethodBankAccountGhana
{
    [JsonPropertyName("branch")]
    public string? Branch { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("account_number")]
    public string? AccountNumber { get; set; }

    [JsonPropertyName("sort_code")]
    public string? SortCode { get; set; }

    [JsonPropertyName("swift_code")]
    public string? SwiftCode { get; set; }
}

public sealed class PaymentMethodBankAccount
{
    [JsonPropertyName("ghana_bank_account")]
    public PaymentMethodBankAccountGhana? GhanaBankAccount { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}

public sealed class PaymentMethodCardIssuer
{
    [JsonPropertyName("email_address")]
    public string? EmailAddress { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}

public sealed class PaymentMethodCardOwner
{
    [JsonPropertyName("email_address")]
    public string? EmailAddress { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }
}

public sealed class PaymentMethodCard
{
    [JsonPropertyName("brand")]
    public string? Brand { get; set; }

    [JsonPropertyName("expires_on")]
    public string? ExpiresOn { get; set; }

    [JsonPropertyName("issuer")]
    public PaymentMethodCardIssuer? Issuer { get; set; }

    [JsonPropertyName("owner")]
    public PaymentMethodCardOwner? Owner { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}

public sealed class PaymentMethodVerification
{
    [JsonPropertyName("completed_at")]
    public string? CompletedAt { get; set; }

    [JsonPropertyName("initiated_at")]
    public string? InitiatedAt { get; set; }

    [JsonPropertyName("mechanism")]
    public string? Mechanism { get; set; }

    [JsonPropertyName("request_id")]
    public string? RequestId { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}

public sealed class PaymentMethodData
{
    [JsonPropertyName("type")]
    public PaymentMethodType Type { get; set; }

    [JsonPropertyName("mobile_money")]
    public MobileMoney? MobileMoney { get; set; }
}

public sealed class PaymentMethodTokenizeRequest
{
    [JsonPropertyName("request_meta")]
    public RequestMeta? RequestMeta { get; set; }

    [JsonPropertyName("customer_id")]
    public string? CustomerId { get; set; }

    [JsonPropertyName("payment_method_data")]
    public PaymentMethodData? PaymentMethodData { get; set; }

    [JsonPropertyName("verify_immediately")]
    public bool? VerifyImmediately { get; set; }
}

public sealed class PaymentMethodVerifyRequest
{
    [JsonPropertyName("request_meta")]
    public RequestMeta? RequestMeta { get; set; }

    [JsonPropertyName("payment_method_id")]
    public string? PaymentMethodId { get; set; }
}

public sealed class PaymentMethodConfirmVerificationRequest
{
    [JsonPropertyName("payment_method_id")]
    public string? PaymentMethodId { get; set; }

    [JsonPropertyName("token")]
    public string? Token { get; set; }
}

public sealed class PaymentMethodLookupRequest
{
    [JsonPropertyName("payment_method_id")]
    public string? PaymentMethodId { get; set; }
}

public sealed class PaymentMethodPageRequest
{
    [JsonPropertyName("customer_id")]
    public string? CustomerId { get; set; }

    [JsonPropertyName("page_number")]
    public int? PageNumber { get; set; }

    [JsonPropertyName("page_size")]
    public int? PageSize { get; set; }
}

public sealed class PaymentMethodActionRequest
{
    [JsonPropertyName("request_meta")]
    public RequestMeta? RequestMeta { get; set; }

    [JsonPropertyName("payment_method_id")]
    public string? PaymentMethodId { get; set; }
}

public sealed class PaymentMethodUpdateRequest
{
    [JsonPropertyName("payment_method_id")]
    public string? PaymentMethodId { get; set; }

    [JsonPropertyName("custom_data")]
    public Dictionary<string, string?>? CustomData { get; set; }

    [JsonPropertyName("active")]
    public bool? Active { get; set; }

    [JsonPropertyName("archived")]
    public bool? Archived { get; set; }

    [JsonPropertyName("owner")]
    public JsonObject? Owner { get; set; }
}

public sealed class PaymentMethodDeleteRequest
{
    [JsonPropertyName("request_meta")]
    public RequestMeta? RequestMeta { get; set; }

    [JsonPropertyName("payment_method_id")]
    public string? PaymentMethodId { get; set; }
}

public sealed class PaymentMethodObject
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("customer_id")]
    public string? CustomerId { get; set; }

    [JsonPropertyName("type")]
    public PaymentMethodType Type { get; set; }

    [JsonPropertyName("mobile_money")]
    public PaymentMethodMobileMoney? MobileMoney { get; set; }

    [JsonPropertyName("bank_account")]
    public PaymentMethodBankAccount? BankAccount { get; set; }

    [JsonPropertyName("card")]
    public PaymentMethodCard? Card { get; set; }

    [JsonPropertyName("verification")]
    public PaymentMethodVerification? Verification { get; set; }

    [JsonPropertyName("custom_data")]
    public Dictionary<string, string>? CustomData { get; set; }

    [JsonPropertyName("expires_on")]
    public string? ExpiresOn { get; set; }

    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    [JsonPropertyName("verified")]
    public bool? Verified { get; set; }

    [JsonPropertyName("verified_at")]
    public string? VerifiedAt { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? Extra { get; set; }
}

public sealed class PaymentMethodResponse
{
    [JsonPropertyName("payment_method")]
    public PaymentMethodObject? PaymentMethod { get; set; }
}

public sealed class PaymentMethodTypeSetting
{
    [JsonPropertyName("type")]
    public PaymentMethodType Type { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("confirms_use")]
    public bool? ConfirmsUse { get; set; }
}

public sealed class PaymentMethodSettings
{
    [JsonPropertyName("mobile_money")]
    public PaymentMethodTypeSetting? MobileMoney { get; set; }

    [JsonPropertyName("bank_account")]
    public PaymentMethodTypeSetting? BankAccount { get; set; }

    [JsonPropertyName("card")]
    public PaymentMethodTypeSetting? Card { get; set; }

    [JsonPropertyName("motito")]
    public PaymentMethodTypeSetting? Motito { get; set; }
}

public sealed class PaymentMethodSettingsResponse
{
    [JsonPropertyName("settings")]
    public PaymentMethodSettings? Settings { get; set; }
}

public sealed class PaymentMethodVerificationResponse
{
    [JsonPropertyName("verification")]
    public JsonObject? Verification { get; set; }
}
