using Inttegro.Http;
using Inttegro.Responses;

namespace Inttegro.Resources;

public class SchedulesResource
{
    private readonly ApiClient _client;

    internal SchedulesResource(ApiClient client) => _client = client;

    public Task<InttegroResponse> LookupAsync(string scheduleId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/schedules/lookup", new { schedule_id = scheduleId }, cancellationToken);

    public Task<InttegroResponse> CancelAsync(string scheduleId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/schedules/cancel", new { schedule_id = scheduleId }, cancellationToken);
}
