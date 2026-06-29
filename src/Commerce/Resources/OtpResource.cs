using Commerce.Http;
using Commerce.Responses;

namespace Commerce.Resources;

public class OtpResource
{
    private readonly ApiClient _client;

    public OtpResource(ApiClient client) => _client = client;

    public Task<CommerceResponse> InitiateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/otp/initiate", payload, cancellationToken);

    public Task<CommerceResponse> VerifyAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/otp/verify", payload, cancellationToken);

    public Task<CommerceResponse> LookupAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/otp/lookup", payload, cancellationToken);

    public Task<CommerceResponse> CancelAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/otp/cancel", payload, cancellationToken);
}
