using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Commerce.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BalanceTransactionType
{
    [EnumMember(Value = "payment")]
    Payment,
    [EnumMember(Value = "refund")]
    Refund
}

/// <summary>
/// A merchant balance entry caused by a payment or refund. Type identifies the
/// semantic source, not accounting direction, and exactly one matching source ID
/// is present.
/// </summary>
public class BalanceTransaction
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public BalanceTransactionType Type { get; set; }

    [JsonPropertyName("payment_id")]
    public string? PaymentId { get; set; }

    [JsonPropertyName("refund_id")]
    public string? RefundId { get; set; }

    [JsonPropertyName("payout_id")]
    public string? PayoutId { get; set; }

    [JsonPropertyName("order_id")]
    public string OrderId { get; set; } = string.Empty;

    [JsonPropertyName("amount")]
    public Money Amount { get; set; } = new();

    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; } = string.Empty;

    [JsonPropertyName("available_at")]
    public string? AvailableAt { get; set; }

    [JsonPropertyName("claimed_at")]
    public string? ClaimedAt { get; set; }

    [JsonPropertyName("paid_at")]
    public string? PaidAt { get; set; }

    [Obsolete("The reviewed API does not return payout_configuration on balance transactions.")]
    [JsonPropertyName("payout_configuration")]
    public OrderPayoutConfiguration? PayoutConfiguration { get; set; }

    [JsonIgnore]
    public string? SourceId => Type switch
    {
        BalanceTransactionType.Payment when !string.IsNullOrWhiteSpace(PaymentId) && RefundId is null => PaymentId,
        BalanceTransactionType.Refund when !string.IsNullOrWhiteSpace(RefundId) && PaymentId is null => RefundId,
        _ => null
    };
}

[Obsolete("Use BalanceTransaction. Order responses now reuse the canonical model.")]
public sealed class OrderBalanceTransaction : BalanceTransaction
{
}
