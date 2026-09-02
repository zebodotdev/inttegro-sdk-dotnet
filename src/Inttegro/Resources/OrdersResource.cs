using Inttegro.Http;
using Inttegro.Models;
using Inttegro.Responses;
using Inttegro.Validation;

namespace Inttegro.Resources;

public class OrdersResource
{
    private readonly ApiClient _client;

    internal OrdersResource(ApiClient client) => _client = client;

    public Task<InttegroResponse> CreateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/orders/create", payload, cancellationToken);

    public Task<InttegroResponse> CreateAsync(OrderCreateRequest payload, CancellationToken cancellationToken = default)
    {
        ValidateCreate(payload);
        return _client.PostAsync("/orders/create", payload, cancellationToken);
    }

    public Task<InttegroResponse> NewAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/orders/new", payload, cancellationToken);

    public Task<InttegroResponse> NewAsync(OrderCreateRequest payload, CancellationToken cancellationToken = default)
    {
        ValidateCreate(payload);
        return _client.PostAsync("/orders/new", payload, cancellationToken);
    }

    public Task<InttegroResponse> UpdateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/orders/update", payload, cancellationToken);

    public Task<InttegroResponse> UpdateAsync(OrderUpdateRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.OrderId, "order_id");
        return _client.PostAsync("/orders/update", payload, cancellationToken);
    }

    public Task<InttegroResponse> LookupAsync(string orderId, object? options = null, CancellationToken cancellationToken = default)
    {
        var body = options as IDictionary<string, object?> ?? new Dictionary<string, object?>();
        body["order_id"] = orderId;
        return _client.PostAsync("/orders/lookup", body, cancellationToken);
    }

    public Task<InttegroResponse> LookupAsync(OrderLookupRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.OrderId, "order_id");
        return _client.PostAsync("/orders/lookup", payload, cancellationToken);
    }

    public Task<InttegroResponse> PayAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/orders/pay", payload, cancellationToken);

    public Task<InttegroResponse> PayAsync(OrderPayRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.OrderId, "order_id");
        return _client.PostAsync("/orders/pay", payload, cancellationToken);
    }

    public Task<InttegroResponse> ConfirmPaymentAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/orders/confirm_payment", payload, cancellationToken);

    public Task<InttegroResponse> ConfirmPaymentAsync(OrderConfirmPaymentRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.OrderId, "order_id");
        RequestValidator.Require(payload.Token, "token");
        return _client.PostAsync("/orders/confirm_payment", payload, cancellationToken);
    }

    public Task<InttegroResponse> RequestConfirmationAsync(string orderId, CancellationToken cancellationToken = default) =>
        RequestConfirmationAsync(new OrderRequestConfirmationRequest
        {
            OrderId = orderId,
            RequestMeta = StableOrderRequestMeta("request_confirmation", orderId)
        }, cancellationToken);

    public Task<InttegroResponse> RequestConfirmationAsync(OrderRequestConfirmationRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.OrderId, "order_id");
        return _client.PostAsync("/orders/request_confirmation", payload, cancellationToken);
    }

    public Task<InttegroResponse> FinalizeAsync(string orderId, CancellationToken cancellationToken = default) =>
        FinalizeAsync(new OrderFinalizeRequest
        {
            OrderId = orderId,
            RequestMeta = StableOrderRequestMeta("finalize", orderId)
        }, cancellationToken);

    public Task<InttegroResponse> FinalizeAsync(OrderFinalizeRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.OrderId, "order_id");
        return _client.PostAsync("/orders/finalize", payload, cancellationToken);
    }

    public Task<InttegroResponse> SendInvoiceAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/orders/send_invoice", payload, cancellationToken);

    public Task<InttegroResponse> SendInvoiceAsync(OrderSendInvoiceParams payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.OrderId, "order_id");
        return _client.PostAsync("/orders/send_invoice", payload, cancellationToken);
    }

    public Task<InttegroResponse> SendReceiptAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/orders/send_receipt", payload, cancellationToken);

    public Task<InttegroResponse> SendReceiptAsync(OrderSendReceiptParams payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.OrderId, "order_id");
        return _client.PostAsync("/orders/send_receipt", payload, cancellationToken);
    }

    public Task<InttegroResponse> CompleteAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/orders/complete", payload, cancellationToken);

    public Task<InttegroResponse> CompleteAsync(OrderCompleteRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.OrderId, "order_id");
        return _client.PostAsync("/orders/complete", payload, cancellationToken);
    }

    public Task<InttegroResponse> CancelAsync(string orderId, CancellationToken cancellationToken = default) =>
        CancelAsync(new OrderCancelRequest
        {
            OrderId = orderId,
            RequestMeta = StableOrderRequestMeta("cancel", orderId)
        }, cancellationToken);

    public Task<InttegroResponse> CancelAsync(OrderCancelRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.OrderId, "order_id");
        return _client.PostAsync("/orders/cancel", payload, cancellationToken);
    }

    /// <summary>
    /// Creates a refund through the compatibility route. New integrations should use Refunds.CreateAsync.
    /// </summary>
    [Obsolete("Use Refunds.CreateAsync for new integrations.")]
    public Task<InttegroResponse> RefundAsync(CreateRefundRequest payload, CancellationToken cancellationToken = default)
        => RefundAsync(payload, idempotencyKey: null, cancellationToken);

    [Obsolete("Use Refunds.CreateAsync for new integrations.")]
    public Task<InttegroResponse> RefundAsync(
        CreateRefundRequest payload,
        string? idempotencyKey,
        CancellationToken cancellationToken = default
    )
    {
        RefundsResource.ValidateCreate(payload);
        return _client.PostWithHeadersAsync(
            "/orders/refund",
            payload,
            RefundsResource.IdempotencyHeaders(idempotencyKey),
            cancellationToken
        );
    }

    public Task<InttegroResponse> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/orders/page", payload ?? new { }, cancellationToken);

    public Task<InttegroResponse> PageAsync(OrderPageRequest payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/orders/page", payload, cancellationToken);

    private static RequestMeta StableOrderRequestMeta(string action, string orderId) =>
        new() { IdempotencyKey = $"orders_{action}_{orderId}" };

    private static void ValidateCreate(OrderCreateRequest payload)
    {
        RequestValidator.RequireAny(
            ("customer_data", payload.CustomerData),
            ("customer_id", payload.CustomerId),
            "Either 'customer_data' or 'customer_id' is required."
        );
        RequestValidator.RequireCollection(payload.LineItems, "line_items");
    }
}
