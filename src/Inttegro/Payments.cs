using System.Runtime.Serialization;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Inttegro.Money;

namespace Inttegro;

internal sealed class WireEnumJsonConverter<T> : JsonConverter<T> where T : struct, Enum
{
    private static readonly IReadOnlyDictionary<string, T> FromWire = Enum.GetValues<T>()
        .ToDictionary(value => WireValue(value), value => value, StringComparer.Ordinal);

    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (value is not null && FromWire.TryGetValue(value, out var parsed))
        {
            return parsed;
        }

        throw new JsonException($"{value ?? "null"} is not valid for {typeof(T).Name}");
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) =>
        writer.WriteStringValue(WireValue(value));

    private static string WireValue(T value)
    {
        var name = value.ToString();
        return typeof(T).GetField(name)?.GetCustomAttribute<EnumMemberAttribute>()?.Value ?? name;
    }
}

[JsonConverter(typeof(WireEnumJsonConverter<PaymentStatus>))]
public enum PaymentStatus
{
    [EnumMember(Value = "initiated")] Initiated,
    [EnumMember(Value = "requires_action")] RequiresAction,
    [EnumMember(Value = "overdue")] Overdue,
    [EnumMember(Value = "executed")] Executed,
    [EnumMember(Value = "paid")] Paid,
    [EnumMember(Value = "canceled")] Canceled,
    [EnumMember(Value = "expired")] Expired,
    [EnumMember(Value = "failed")] Failed,
    [EnumMember(Value = "unknown")] Unknown
}

[JsonConverter(typeof(WireEnumJsonConverter<PaymentAttemptStatus>))]
public enum PaymentAttemptStatus
{
    [EnumMember(Value = "initiated")] Initiated,
    [EnumMember(Value = "executed")] Executed,
    [EnumMember(Value = "succeeded")] Succeeded,
    [EnumMember(Value = "canceled")] Canceled,
    [EnumMember(Value = "expired")] Expired,
    [EnumMember(Value = "failed")] Failed,
    [EnumMember(Value = "unknown")] Unknown
}

[JsonConverter(typeof(WireEnumJsonConverter<PaymentNextActionType>))]
public enum PaymentNextActionType
{
    [EnumMember(Value = "confirm_payment")] ConfirmPayment,
    [EnumMember(Value = "execute")] Execute,
    [EnumMember(Value = "redirect")] Redirect,
    [EnumMember(Value = "authorize")] Authorize,
    [EnumMember(Value = "none")] None
}

[JsonConverter(typeof(WireEnumJsonConverter<PaymentConfirmationChannel>))]
public enum PaymentConfirmationChannel
{
    [EnumMember(Value = "sms")] Sms,
    [EnumMember(Value = "email")] Email,
    [EnumMember(Value = "push")] Push
}

[JsonConverter(typeof(WireEnumJsonConverter<CheckoutPaymentStatus>))]
public enum CheckoutPaymentStatus
{
    [EnumMember(Value = "requires_action")] RequiresAction,
    [EnumMember(Value = "processing")] Processing,
    [EnumMember(Value = "succeeded")] Succeeded,
    [EnumMember(Value = "failed")] Failed,
    [EnumMember(Value = "cancelled")] Cancelled
}

[JsonConverter(typeof(WireEnumJsonConverter<PaymentResultStatus>))]
public enum PaymentResultStatus
{
    [EnumMember(Value = "pending")] Pending,
    [EnumMember(Value = "requires_confirmation")] RequiresConfirmation,
    [EnumMember(Value = "processing")] Processing,
    [EnumMember(Value = "succeeded")] Succeeded,
    [EnumMember(Value = "failed")] Failed
}

public sealed class PayoutConfiguration
{
    [JsonPropertyName("destination")]
    public PayoutConfigurationDestination? Destination { get; set; }

    [JsonPropertyName("enable_fx")]
    public bool? EnableFx { get; set; }
}

public sealed class PayoutConfigurationDestination
{
    [JsonPropertyName("financial_account_id")]
    public string? FinancialAccountId { get; set; }
}

public sealed class PaymentAttempt
{
    [JsonPropertyName("payment_method_type")]
    public PaymentMethodType? PaymentMethodType { get; set; }

    [JsonPropertyName("payment_method_id")]
    public string? PaymentMethodId { get; set; }

    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    [JsonPropertyName("status")]
    public PaymentAttemptStatus? Status { get; set; }

    [JsonPropertyName("initiated_at")]
    public string? InitiatedAt { get; set; }

    [JsonPropertyName("succeeded_at")]
    public string? SucceededAt { get; set; }

    [JsonPropertyName("failed_at")]
    public string? FailedAt { get; set; }
}

public sealed class PaymentConfirmationRequest
{
    [JsonPropertyName("id")] public string? Id { get; set; }
    [JsonPropertyName("recipient")] public string? Recipient { get; set; }
    [JsonPropertyName("sent_via")] public PaymentConfirmationChannel? SentVia { get; set; }
    [JsonPropertyName("token_size")] public int? TokenSize { get; set; }
    [JsonPropertyName("sender_id")] public string? SenderId { get; set; }
}

public sealed class PaymentConfirmationAttempt
{
    [JsonPropertyName("status")] public string? Status { get; set; }
    [JsonPropertyName("confirmed")] public bool? Confirmed { get; set; }
    [JsonPropertyName("reason")] public string? Reason { get; set; }
    [JsonPropertyName("token")] public string? Token { get; set; }
    [JsonPropertyName("executed_at")] public string? ExecutedAt { get; set; }
    [JsonPropertyName("created_at")] public string? CreatedAt { get; set; }
}

public sealed class PaymentConfirmAction
{
    [JsonPropertyName("expires_at")] public string? ExpiresAt { get; set; }
    [JsonPropertyName("scheme")] public string? Scheme { get; set; }
    [JsonPropertyName("request")] public PaymentConfirmationRequest? Request { get; set; }
    [JsonPropertyName("attempt")] public PaymentConfirmationAttempt? Attempt { get; set; }
    [JsonPropertyName("confirmed")] public bool? Confirmed { get; set; }
    [JsonPropertyName("status")] public string? Status { get; set; }
}

public sealed class PaymentRedirectVisit
{
    [JsonPropertyName("user_agent")] public string? UserAgent { get; set; }
    [JsonPropertyName("ip_address")] public string? IpAddress { get; set; }
    [JsonPropertyName("at")] public string? At { get; set; }
}

public sealed class PaymentRedirectAction
{
    [JsonPropertyName("redirect_url")] public string? RedirectUrl { get; set; }
    [JsonPropertyName("valid_until")] public string? ValidUntil { get; set; }
    [JsonPropertyName("latest_visit")] public PaymentRedirectVisit? LatestVisit { get; set; }
}

public sealed class PaymentAuthorizeAction
{
    [JsonPropertyName("beneficiary")] public string? Beneficiary { get; set; }
    [JsonPropertyName("scheme")] public string? Scheme { get; set; }
    [JsonPropertyName("expires_at")] public string? ExpiresAt { get; set; }
}

public sealed class PaymentNextAction
{
    [JsonPropertyName("type")] public PaymentNextActionType? Type { get; set; }
    [JsonPropertyName("confirm_payment")] public PaymentConfirmAction? ConfirmPayment { get; set; }
    [JsonPropertyName("execute")] public JsonObject? Execute { get; set; }
    [JsonPropertyName("redirect")] public PaymentRedirectAction? Redirect { get; set; }
    [JsonPropertyName("authorize")] public PaymentAuthorizeAction? Authorize { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? Extra { get; set; }
}

public sealed class Payment
{
    [JsonPropertyName("id")] public string? Id { get; set; }
    [JsonPropertyName("status")] public PaymentStatus? Status { get; set; }
    [JsonPropertyName("statement_descriptor")] public string? StatementDescriptor { get; set; }
    [JsonPropertyName("amount")] public Amount? Amount { get; set; }
    [JsonPropertyName("payment_method")] public PaymentMethod? PaymentMethod { get; set; }
    [JsonPropertyName("latest_attempt")] public PaymentAttempt? LatestAttempt { get; set; }
    [JsonPropertyName("next_action")] public PaymentNextAction? NextAction { get; set; }
    [JsonPropertyName("payout_configuration")] public PayoutConfiguration? PayoutConfiguration { get; set; }
    [JsonPropertyName("initiated_at")] public string? InitiatedAt { get; set; }
    [JsonPropertyName("executed_at")] public string? ExecutedAt { get; set; }
    [JsonPropertyName("paid_at")] public string? PaidAt { get; set; }
    [JsonPropertyName("failed_at")] public string? FailedAt { get; set; }
    [JsonPropertyName("balance_transaction")] public BalanceTransaction? BalanceTransaction { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? Extra { get; set; }
}
