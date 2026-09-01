using Inttegro.Http;
using Inttegro.Responses;

namespace Inttegro.Resources;

public class FileReferencesResource
{
    private readonly ApiClient _client;

    internal FileReferencesResource(ApiClient client) => _client = client;

    public Task<InttegroResponse> ReconcileAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/file_references/reconcile", payload, cancellationToken);
}
