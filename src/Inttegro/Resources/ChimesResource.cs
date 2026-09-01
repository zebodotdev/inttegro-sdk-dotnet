using Inttegro.Http;
using Inttegro.Responses;

namespace Inttegro.Resources;

public class ChimesResource
{
    private readonly ApiClient _client;

    internal ChimesResource(ApiClient client) => _client = client;

    public Task<InttegroResponse> SendAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/chimes/send", payload, cancellationToken);

    public Task<InttegroResponse> LookupAsync(string chimeId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/chimes/lookup", new { chime_id = chimeId }, cancellationToken);

    public Task<InttegroResponse> ScheduleAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/chimes/schedule", payload, cancellationToken);

    public Task<InttegroResponse> BroadcastAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/chimes/broadcast", payload, cancellationToken);

    public Task<InttegroResponse> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/chimes/page", payload ?? new { }, cancellationToken);
}
