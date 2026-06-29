using Commerce.Http;
using Commerce.Responses;

namespace Commerce.Resources;

public class BroadcastsResource
{
    private readonly ApiClient _client;

    public BroadcastsResource(ApiClient client) => _client = client;

    public Task<CommerceResponse> LookupAsync(string broadcastId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/broadcasts/lookup", new { broadcast_id = broadcastId }, cancellationToken);

    public Task<CommerceResponse> CancelAsync(string broadcastId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/broadcasts/cancel", new { broadcast_id = broadcastId }, cancellationToken);
}
