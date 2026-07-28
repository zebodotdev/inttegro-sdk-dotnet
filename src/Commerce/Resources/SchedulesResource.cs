using Commerce.Http;
using Commerce.Responses;

namespace Commerce.Resources;

public class SchedulesResource
{
    private readonly ApiClient _client;

    internal SchedulesResource(ApiClient client) => _client = client;

    public Task<CommerceResponse> LookupAsync(string scheduleId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/schedules/lookup", new { schedule_id = scheduleId }, cancellationToken);

    public Task<CommerceResponse> CancelAsync(string scheduleId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/schedules/cancel", new { schedule_id = scheduleId }, cancellationToken);
}
