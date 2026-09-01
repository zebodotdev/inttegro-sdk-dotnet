using Inttegro.Http;
using Inttegro.Models;
using Inttegro.Responses;
using Inttegro.Validation;

namespace Inttegro.Resources;

public class PaymentMethodsResource
{
    private readonly ApiClient _client;

    internal PaymentMethodsResource(ApiClient client) => _client = client;

    public Task<InttegroResponse> TokenizeAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payment_methods/tokenize", payload, cancellationToken);

    public Task<InttegroResponse> TokenizeAsync(PaymentMethodTokenizeRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.CustomerId, "customer_id");
        RequestValidator.Require(payload.PaymentMethodData, "payment_method_data");
        return _client.PostAsync("/payment_methods/tokenize", payload, cancellationToken);
    }

    public Task<InttegroResponse> VerifyAsync(string paymentMethodId, CancellationToken cancellationToken = default) =>
        VerifyAsync(new PaymentMethodVerifyRequest
        {
            PaymentMethodId = paymentMethodId,
            RequestMeta = StablePaymentMethodRequestMeta("verify", paymentMethodId)
        }, cancellationToken);

    public Task<InttegroResponse> VerifyAsync(PaymentMethodVerifyRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.PaymentMethodId, "payment_method_id");
        return _client.PostAsync("/payment_methods/verify", payload, cancellationToken);
    }

    public Task<InttegroResponse> ConfirmVerificationAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payment_methods/confirm_verification", payload, cancellationToken);

    public Task<InttegroResponse> ConfirmVerificationAsync(PaymentMethodConfirmVerificationRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.PaymentMethodId, "payment_method_id");
        RequestValidator.Require(payload.Token, "token");
        return _client.PostAsync("/payment_methods/confirm_verification", payload, cancellationToken);
    }

    public Task<InttegroResponse> LookupAsync(string paymentMethodId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payment_methods/lookup", new { payment_method_id = paymentMethodId }, cancellationToken);

    public Task<InttegroResponse> LookupAsync(PaymentMethodLookupRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.PaymentMethodId, "payment_method_id");
        return _client.PostAsync("/payment_methods/lookup", payload, cancellationToken);
    }

    public Task<InttegroResponse> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payment_methods/page", payload ?? new { }, cancellationToken);

    public Task<InttegroResponse> PageAsync(PaymentMethodPageRequest payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payment_methods/page", payload, cancellationToken);

    public Task<InttegroResponse> UpdateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payment_methods/update", payload, cancellationToken);

    public Task<InttegroResponse> UpdateAsync(PaymentMethodUpdateRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.PaymentMethodId, "payment_method_id");
        return _client.PostAsync("/payment_methods/update", payload, cancellationToken);
    }

    public Task<InttegroResponse> ActivateAsync(string paymentMethodId, CancellationToken cancellationToken = default) =>
        ActivateAsync(ActionRequest("activate", paymentMethodId), cancellationToken);

    public Task<InttegroResponse> ActivateAsync(PaymentMethodActionRequest payload, CancellationToken cancellationToken = default) =>
        PostActionAsync("/payment_methods/activate", payload, cancellationToken);

    public Task<InttegroResponse> DisactivateAsync(string paymentMethodId, CancellationToken cancellationToken = default) =>
        DisactivateAsync(ActionRequest("disactivate", paymentMethodId), cancellationToken);

    public Task<InttegroResponse> DisactivateAsync(PaymentMethodActionRequest payload, CancellationToken cancellationToken = default) =>
        PostActionAsync("/payment_methods/disactivate", payload, cancellationToken);

    public Task<InttegroResponse> ArchiveAsync(string paymentMethodId, CancellationToken cancellationToken = default) =>
        ArchiveAsync(ActionRequest("archive", paymentMethodId), cancellationToken);

    public Task<InttegroResponse> ArchiveAsync(PaymentMethodActionRequest payload, CancellationToken cancellationToken = default) =>
        PostActionAsync("/payment_methods/archive", payload, cancellationToken);

    public Task<InttegroResponse> UnarchiveAsync(string paymentMethodId, CancellationToken cancellationToken = default) =>
        UnarchiveAsync(ActionRequest("unarchive", paymentMethodId), cancellationToken);

    public Task<InttegroResponse> UnarchiveAsync(PaymentMethodActionRequest payload, CancellationToken cancellationToken = default) =>
        PostActionAsync("/payment_methods/unarchive", payload, cancellationToken);

    public Task<InttegroResponse> DeleteAsync(string paymentMethodId, CancellationToken cancellationToken = default) =>
        DeleteAsync(new PaymentMethodDeleteRequest
        {
            PaymentMethodId = paymentMethodId,
            RequestMeta = StablePaymentMethodRequestMeta("delete", paymentMethodId)
        }, cancellationToken);

    public Task<InttegroResponse> DeleteAsync(PaymentMethodDeleteRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.PaymentMethodId, "payment_method_id");
        return _client.PostAsync("/payment_methods/delete", payload, cancellationToken);
    }

    public Task<InttegroResponse> SettingsAsync(CancellationToken cancellationToken = default) =>
        _client.PostAsync("/payment_methods/settings", new { }, cancellationToken);

    private static RequestMeta StablePaymentMethodRequestMeta(string action, string paymentMethodId) =>
        new() { IdempotencyKey = $"payment_methods_{action}_{paymentMethodId}" };

    private Task<InttegroResponse> PostActionAsync(string path, PaymentMethodActionRequest payload, CancellationToken cancellationToken)
    {
        RequestValidator.Require(payload.PaymentMethodId, "payment_method_id");
        return _client.PostAsync(path, payload, cancellationToken);
    }

    private static PaymentMethodActionRequest ActionRequest(string action, string paymentMethodId) =>
        new()
        {
            PaymentMethodId = paymentMethodId,
            RequestMeta = StablePaymentMethodRequestMeta(action, paymentMethodId)
        };
}
