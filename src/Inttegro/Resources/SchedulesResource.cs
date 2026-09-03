using Inttegro.Http;

namespace Inttegro.Resources;

public class SchedulesResource
{
    private readonly ApiClient _client;

    internal SchedulesResource(ApiClient client) => _client = client;

    public Task<ScheduledChime> LookupAsync(string scheduleId, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<ScheduledChime>("/schedules/lookup", "scheduled_chime", new { schedule_id = scheduleId }, cancellationToken);

    public Task<ScheduledChime> CancelAsync(string scheduleId, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<ScheduledChime>("/schedules/cancel", "scheduled_chime", new { schedule_id = scheduleId }, cancellationToken);
}
