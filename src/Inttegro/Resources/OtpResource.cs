using Inttegro.Http;
using Inttegro.Responses;

namespace Inttegro.Resources;

public class OtpResource
{
    private readonly ApiClient _client;

    internal OtpResource(ApiClient client) => _client = client;

    public Task<InttegroResponse> InitiateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/otp/initiate", payload, cancellationToken);

    public Task<InttegroResponse> VerifyAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/otp/verify", payload, cancellationToken);

    public Task<InttegroResponse> LookupAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/otp/lookup", payload, cancellationToken);

    public Task<InttegroResponse> CancelAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/otp/cancel", payload, cancellationToken);
}
