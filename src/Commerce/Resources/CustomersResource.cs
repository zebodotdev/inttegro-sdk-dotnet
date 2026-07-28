using Commerce.Http;
using Commerce.Models;
using Commerce.Responses;
using Commerce.Validation;

namespace Commerce.Resources;

public class CustomersResource
{
    private readonly ApiClient _client;

    internal CustomersResource(ApiClient client) => _client = client;

    public Task<CommerceResponse> CreateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/customers/create", payload, cancellationToken);

    public Task<CommerceResponse> CreateAsync(CreateCustomerRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.Name, "name");
        return _client.PostAsync("/customers/create", payload, cancellationToken);
    }

    public Task<CommerceResponse> LookupAsync(string customerId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/customers/lookup", new { customer_id = customerId }, cancellationToken);

    public Task<CommerceResponse> LookupAsync(LookupCustomerRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.CustomerId, "customer_id");
        return _client.PostAsync("/customers/lookup", payload, cancellationToken);
    }

    public Task<CommerceResponse> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/customers/page", payload ?? new { }, cancellationToken);

    public Task<CommerceResponse> PageAsync(PageCustomersRequest payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/customers/page", payload, cancellationToken);
}
