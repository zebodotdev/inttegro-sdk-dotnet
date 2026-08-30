using Commerce.Http;
using Commerce.Responses;

namespace Commerce.Resources;

public class FileReferencesResource
{
    private readonly ApiClient _client;

    internal FileReferencesResource(ApiClient client) => _client = client;

    public Task<CommerceResponse> ReconcileAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/file_references/reconcile", payload, cancellationToken);
}
