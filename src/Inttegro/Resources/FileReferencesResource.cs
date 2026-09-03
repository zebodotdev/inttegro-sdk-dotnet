using Inttegro.Http;

namespace Inttegro.Resources;

public class FileReferencesResource
{
    private readonly ApiClient _client;

    internal FileReferencesResource(ApiClient client) => _client = client;

    public Task<FileReferenceReconciliation> ReconcileAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync<FileReferenceReconciliation>("/file_references/reconcile", payload, cancellationToken);
}
