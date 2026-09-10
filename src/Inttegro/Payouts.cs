using System.Text.Json;
using System.Text.Json.Serialization;
using Inttegro.Money;

namespace Inttegro;

public sealed class PayoutSetDestinationsRequest
{
    [JsonPropertyName("destinations")]
    public PayoutDestinations? Destinations { get; set; }
}

public sealed class PayoutSettings
{
    [JsonPropertyName("fx_enabled")]
    public bool? FxEnabled { get; set; }

    [JsonPropertyName("destinations")]
    public PayoutDestinations? Destinations { get; set; }

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

public sealed class PayoutPageRequest
{
    [JsonPropertyName("page_number")]
    public int? PageNumber { get; set; }

    [JsonPropertyName("page_size")]
    public int? PageSize { get; set; }
}

public sealed class SchedulePayoutRequest
{
    [JsonPropertyName("destination_id")]
    public string? DestinationId { get; set; }

    [JsonPropertyName("execute_after")]
    public DateTimeOffset? ExecuteAfter { get; set; }

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

public sealed class PayoutPage
{
    [JsonPropertyName("number")]
    public int? Number { get; set; }

    [JsonPropertyName("size")]
    public int? Size { get; set; }

    [JsonPropertyName("payouts")]
    public List<Payout>? Payouts { get; set; }
}

public sealed class Payout
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("application_id")]
    public string? ApplicationId { get; set; }

    [JsonPropertyName("destination_id")]
    public string? DestinationId { get; set; }

    [JsonPropertyName("amount")]
    public Amount? Amount { get; set; }

    [JsonPropertyName("max_amount")]
    public Amount? MaxAmount { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("initiated_by")]
    public string? InitiatedBy { get; set; }

    [JsonPropertyName("latest_attempt_id")]
    public string? LatestAttemptId { get; set; }

    [JsonPropertyName("latest_error")]
    public PayoutError? LatestError { get; set; }

    [JsonPropertyName("initiated_at")]
    public DateTimeOffset? InitiatedAt { get; set; }

    [JsonPropertyName("execute_after")]
    public DateTimeOffset? ExecuteAfter { get; set; }

    [JsonPropertyName("scheduled_at")]
    public DateTimeOffset? ScheduledAt { get; set; }

    [JsonPropertyName("canceled_at")]
    public DateTimeOffset? CanceledAt { get; set; }

    [JsonPropertyName("executed_at")]
    public DateTimeOffset? ExecutedAt { get; set; }

    [JsonPropertyName("expected_at")]
    public DateTimeOffset? ExpectedAt { get; set; }

    [JsonPropertyName("succeeded_at")]
    public DateTimeOffset? SucceededAt { get; set; }

    [JsonPropertyName("balance_transaction_ids")]
    public List<string>? BalanceTransactionIds { get; set; }
}

public sealed class PayoutError
{
    [JsonPropertyName("cause")] public string? Cause { get; set; }
    [JsonPropertyName("message")] public string? Message { get; set; }
    [JsonPropertyName("occurred_at")] public DateTimeOffset? OccurredAt { get; set; }
    [JsonPropertyName("type")] public string? Type { get; set; }
}
