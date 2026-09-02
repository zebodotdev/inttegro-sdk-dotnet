using Inttegro.Http;
using Inttegro;
using Inttegro.Responses;
using Inttegro.Validation;

namespace Inttegro.Resources;

public class CustomersResource
{
    private readonly ApiClient _client;

    internal CustomersResource(ApiClient client) => _client = client;

    public Task<InttegroResponse> CreateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/customers/create", payload, cancellationToken);

    public Task<InttegroResponse> CreateAsync(CreateCustomerRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.Name, "name");
        return _client.PostAsync("/customers/create", payload, cancellationToken);
    }

    public Task<InttegroResponse> LookupAsync(string customerId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/customers/lookup", new { customer_id = customerId }, cancellationToken);

    public Task<InttegroResponse> LookupAsync(LookupCustomerRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.CustomerId, "customer_id");
        return _client.PostAsync("/customers/lookup", payload, cancellationToken);
    }

    public Task<InttegroResponse> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/customers/page", payload ?? new { }, cancellationToken);

    public Task<InttegroResponse> PageAsync(PageCustomersRequest payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/customers/page", payload, cancellationToken);
}
