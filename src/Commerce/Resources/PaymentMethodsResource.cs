using Commerce.Http;
using Commerce.Models;
using Commerce.Responses;
using Commerce.Validation;

namespace Commerce.Resources;

public class PaymentMethodsResource
{
    private readonly ApiClient _client;

    internal PaymentMethodsResource(ApiClient client) => _client = client;

    public Task<CommerceResponse> TokenizeAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payment_methods/tokenize", payload, cancellationToken);

    public Task<CommerceResponse> TokenizeAsync(PaymentMethodTokenizeRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.CustomerId, "customer_id");
        RequestValidator.Require(payload.PaymentMethodData, "payment_method_data");
        return _client.PostAsync("/payment_methods/tokenize", payload, cancellationToken);
    }

    public Task<CommerceResponse> VerifyAsync(string paymentMethodId, CancellationToken cancellationToken = default) =>
        VerifyAsync(new PaymentMethodVerifyRequest
        {
            PaymentMethodId = paymentMethodId,
            RequestMeta = StablePaymentMethodRequestMeta("verify", paymentMethodId)
        }, cancellationToken);

    public Task<CommerceResponse> VerifyAsync(PaymentMethodVerifyRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.PaymentMethodId, "payment_method_id");
        return _client.PostAsync("/payment_methods/verify", payload, cancellationToken);
    }

    public Task<CommerceResponse> ConfirmVerificationAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payment_methods/confirm_verification", payload, cancellationToken);

    public Task<CommerceResponse> ConfirmVerificationAsync(PaymentMethodConfirmVerificationRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.PaymentMethodId, "payment_method_id");
        RequestValidator.Require(payload.Token, "token");
        return _client.PostAsync("/payment_methods/confirm_verification", payload, cancellationToken);
    }

    public Task<CommerceResponse> LookupAsync(string paymentMethodId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payment_methods/lookup", new { payment_method_id = paymentMethodId }, cancellationToken);

    public Task<CommerceResponse> LookupAsync(PaymentMethodLookupRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.PaymentMethodId, "payment_method_id");
        return _client.PostAsync("/payment_methods/lookup", payload, cancellationToken);
    }

    public Task<CommerceResponse> DeleteAsync(string paymentMethodId, CancellationToken cancellationToken = default) =>
        DeleteAsync(new PaymentMethodDeleteRequest
        {
            PaymentMethodId = paymentMethodId,
            RequestMeta = StablePaymentMethodRequestMeta("delete", paymentMethodId)
        }, cancellationToken);

    public Task<CommerceResponse> DeleteAsync(PaymentMethodDeleteRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.PaymentMethodId, "payment_method_id");
        return _client.PostAsync("/payment_methods/delete", payload, cancellationToken);
    }

    public Task<CommerceResponse> SettingsAsync(CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payment_methods/settings", new { }, cancellationToken);

    private static RequestMeta StablePaymentMethodRequestMeta(string action, string paymentMethodId) =>
        new() { IdempotencyKey = $"payment_methods_{action}_{paymentMethodId}" };
}
