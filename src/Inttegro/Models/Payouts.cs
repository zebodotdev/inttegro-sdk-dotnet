using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Inttegro.Models;

public sealed class PayoutSetDestinationsRequest
{
    [JsonPropertyName("destinations")]
    public Dictionary<string, string>? Destinations { get; set; }
}

public sealed class PayoutSettings
{
    [JsonPropertyName("fx_enabled")]
    public bool? FxEnabled { get; set; }

    [JsonPropertyName("destinations")]
    public Dictionary<string, string>? Destinations { get; set; }

    [JsonPropertyName("schedule")]
    public PayoutSchedule? Schedule { get; set; }
}

public sealed class PayoutSchedule
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("interval")]
    public string? Interval { get; set; }

    [JsonPropertyName("schedule_on")]
    public string? ScheduleOn { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("aging_spec")]
    public PayoutAgingSpec? AgingSpec { get; set; }
}

public sealed class PayoutAgingSpec
{
    [JsonPropertyName("t_plus")]
    public string? TPlus { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("abide")]
    public string? Abide { get; set; }
}

public sealed class PayoutSettingsResponse
{
    [JsonPropertyName("settings")]
    public PayoutSettings? Settings { get; set; }
}

public sealed class PayoutPageRequest
{
    [JsonPropertyName("page_number")]
    public int? PageNumber { get; set; }

    [JsonPropertyName("page_size")]
    public int? PageSize { get; set; }
}

public sealed class PayoutPageResponse
{
    [JsonPropertyName("page")]
    public PayoutPage? Page { get; set; }
}

public sealed class SchedulePayoutRequest
{
    [JsonPropertyName("destination_id")]
    public string? DestinationId { get; set; }

    [JsonPropertyName("execute_after")]
    public string? ExecuteAfter { get; set; }

    [JsonPropertyName("max_amount")]
    public long? MaxAmount { get; set; }

    [JsonPropertyName("reference")]
    public string? Reference { get; set; }
}

public sealed class CancelPayoutRequest
{
    [JsonPropertyName("payout_id")]
    public string? PayoutId { get; set; }
}

public sealed class CancelPayoutResponse
{
    [JsonPropertyName("payout")]
    public PayoutSummary? Payout { get; set; }
}

public sealed class PayoutPage
{
    [JsonPropertyName("number")]
    public int? Number { get; set; }

    [JsonPropertyName("size")]
    public int? Size { get; set; }

    [JsonPropertyName("payouts")]
    public List<PayoutSummary>? Payouts { get; set; }
}

public sealed class PayoutSummary
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("application_id")]
    public string? ApplicationId { get; set; }

    [JsonPropertyName("destination_id")]
    public string? DestinationId { get; set; }

    [JsonPropertyName("amount")]
    public Money? Amount { get; set; }

    [JsonPropertyName("max_amount")]
    public Money? MaxAmount { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("initiated_by")]
    public string? InitiatedBy { get; set; }

    [JsonPropertyName("latest_attempt_id")]
    public string? LatestAttemptId { get; set; }

    [JsonPropertyName("latest_error")]
    public JsonObject? LatestError { get; set; }

    [JsonPropertyName("initiated_at")]
    public string? InitiatedAt { get; set; }

    [JsonPropertyName("execute_after")]
    public string? ExecuteAfter { get; set; }

    [JsonPropertyName("scheduled_at")]
    public string? ScheduledAt { get; set; }

    [JsonPropertyName("canceled_at")]
    public string? CanceledAt { get; set; }

    [JsonPropertyName("executed_at")]
    public string? ExecutedAt { get; set; }

    [JsonPropertyName("expected_at")]
    public string? ExpectedAt { get; set; }

    [JsonPropertyName("succeeded_at")]
    public string? SucceededAt { get; set; }

    [JsonPropertyName("balance_transaction_ids")]
    public List<string>? BalanceTransactionIds { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? Extra { get; set; }
}
