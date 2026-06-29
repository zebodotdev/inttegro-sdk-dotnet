using Commerce.Http;
using Commerce.Models;
using Commerce.Responses;
using Commerce.Validation;

namespace Commerce.Resources;

public class PayoutsResource
{
    private readonly ApiClient _client;

    public PayoutsResource(ApiClient client) => _client = client;

    public Task<CommerceResponse> SetDestinationsAsync(object destinations, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payouts/set_destinations", new { destinations }, cancellationToken);

    public Task<CommerceResponse> SetDestinationsAsync(PayoutSetDestinationsRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.Destinations, "destinations");
        return _client.PostAsync("/payouts/set_destinations", payload, cancellationToken);
    }

    public Task<CommerceResponse> SettingsAsync(CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payouts/settings", new { }, cancellationToken);

    public Task<CommerceResponse> DisableAutomaticAsync(CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payouts/disable", new { }, cancellationToken);

    public Task<CommerceResponse> EnableFXAsync(CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payouts/enable_fx", new { }, cancellationToken);

    public Task<CommerceResponse> DisableFXAsync(CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payouts/disable_fx", new { }, cancellationToken);

    public Task<CommerceResponse> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payouts/page", payload ?? new { }, cancellationToken);

    public Task<CommerceResponse> PageAsync(PayoutPageRequest payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payouts/page", payload, cancellationToken);

    public Task<CommerceResponse> CancelAsync(string payoutId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payouts/cancel", new { payout_id = payoutId }, cancellationToken);

    public Task<CommerceResponse> CancelAsync(CancelPayoutRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.PayoutId, "payout_id");
        return _client.PostAsync("/payouts/cancel", payload, cancellationToken);
    }
}
