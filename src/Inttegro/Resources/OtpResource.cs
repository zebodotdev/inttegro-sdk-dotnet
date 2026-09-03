using Inttegro.Http;

namespace Inttegro.Resources;

public class OtpResource
{
    private readonly ApiClient _client;

    internal OtpResource(ApiClient client) => _client = client;

    public Task<OtpTransaction> InitiateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<OtpTransaction>("/otp/initiate", "transaction", payload, cancellationToken);

    public Task<OtpVerification> VerifyAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync<OtpVerification>("/otp/verify", payload, cancellationToken);

    public Task<OtpTransaction> LookupAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<OtpTransaction>("/otp/lookup", "transaction", payload, cancellationToken);

    public Task<OtpTransaction> CancelAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostResourceAsync<OtpTransaction>("/otp/cancel", "transaction", payload, cancellationToken);
}
