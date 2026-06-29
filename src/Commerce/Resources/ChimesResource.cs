using Commerce.Http;
using Commerce.Responses;

namespace Commerce.Resources;

public class ChimesResource
{
    private readonly ApiClient _client;

    public ChimesResource(ApiClient client) => _client = client;

    public Task<CommerceResponse> SendAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/chimes/send", payload, cancellationToken);

    public Task<CommerceResponse> LookupAsync(string chimeId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/chimes/lookup", new { chime_id = chimeId }, cancellationToken);

    public Task<CommerceResponse> ScheduleAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/chimes/schedule", payload, cancellationToken);

    public Task<CommerceResponse> BroadcastAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/chimes/broadcast", payload, cancellationToken);
}
