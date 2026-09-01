using Inttegro.Http;
using Inttegro.Responses;

namespace Inttegro.Resources;

public class AppsResource
{
    private readonly ApiClient _client;

    internal AppsResource(ApiClient client) => _client = client;

    public Task<InttegroResponse> CreateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/apps/create", payload, cancellationToken);

    public Task<InttegroResponse> LookupAsync(CancellationToken cancellationToken = default) =>
        _client.PostAsync("/apps/lookup", new { }, cancellationToken);

    public Task<InttegroResponse> UpdateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/apps/update", payload, cancellationToken);
}
