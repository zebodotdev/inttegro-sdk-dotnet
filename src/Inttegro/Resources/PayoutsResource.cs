using Inttegro.Http;
using Inttegro;
using Inttegro.Responses;
using Inttegro.Validation;

namespace Inttegro.Resources;

public class PayoutsResource
{
    private readonly ApiClient _client;

    internal PayoutsResource(ApiClient client) => _client = client;

    public Task<InttegroResponse> SetDestinationsAsync(object destinations, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payouts/set_destinations", new { destinations }, cancellationToken);

    public Task<InttegroResponse> SetDestinationsAsync(PayoutSetDestinationsRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.Destinations, "destinations");
        return _client.PostAsync("/payouts/set_destinations", payload, cancellationToken);
    }

    public Task<InttegroResponse> SettingsAsync(CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payouts/settings", new { }, cancellationToken);

    public Task<InttegroResponse> DisableAutomaticAsync(CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payouts/disable", new { }, cancellationToken);

    public Task<InttegroResponse> EnableAutomaticAsync(CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payouts/enable", new { }, cancellationToken);

    public Task<InttegroResponse> EnableFXAsync(CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payouts/enable_fx", new { }, cancellationToken);

    public Task<InttegroResponse> DisableFXAsync(CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payouts/disable_fx", new { }, cancellationToken);

    public Task<InttegroResponse> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payouts/page", payload ?? new { }, cancellationToken);

    public Task<InttegroResponse> PageAsync(PayoutPageRequest payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payouts/page", payload, cancellationToken);

    public Task<InttegroResponse> LookupAsync(string payoutId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payouts/lookup", new { payout_id = payoutId }, cancellationToken);

    public Task<InttegroResponse> ScheduleAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payouts/schedule", payload, cancellationToken);

    public Task<InttegroResponse> ScheduleAsync(SchedulePayoutRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.DestinationId, "destination_id");
        RequestValidator.Require(payload.MaxAmount, "max_amount");
        RequestValidator.Require(payload.Reference, "reference");
        return _client.PostAsync("/payouts/schedule", payload, cancellationToken);
    }

    public Task<InttegroResponse> CancelAsync(string payoutId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payouts/cancel", new { payout_id = payoutId }, cancellationToken);

    public Task<InttegroResponse> CancelAsync(CancelPayoutRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.PayoutId, "payout_id");
        return _client.PostAsync("/payouts/cancel", payload, cancellationToken);
    }
}
