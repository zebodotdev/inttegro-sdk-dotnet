using Inttegro.Http;

namespace Inttegro.Resources;

public class BroadcastsResource
{
    private readonly ApiClient _client;

    internal BroadcastsResource(ApiClient client) => _client = client;

    public Task<Broadcast> LookupAsync(string broadcastId, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<Broadcast>("/broadcasts/lookup", "broadcast", new { broadcast_id = broadcastId }, cancellationToken);

    public Task<Broadcast> CancelAsync(string broadcastId, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<Broadcast>("/broadcasts/cancel", "broadcast", new { broadcast_id = broadcastId }, cancellationToken);
}
