using Inttegro.Http;
using Inttegro.Responses;

namespace Inttegro.Resources;

public class BroadcastsResource
{
    private readonly ApiClient _client;

    internal BroadcastsResource(ApiClient client) => _client = client;

    public Task<InttegroResponse> LookupAsync(string broadcastId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/broadcasts/lookup", new { broadcast_id = broadcastId }, cancellationToken);

    public Task<InttegroResponse> CancelAsync(string broadcastId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/broadcasts/cancel", new { broadcast_id = broadcastId }, cancellationToken);
}
