using Commerce.Http;
using Commerce.Models;
using Commerce.Responses;
using Commerce.Validation;

namespace Commerce.Resources;

public class OrdersResource
{
    private readonly ApiClient _client;

    internal OrdersResource(ApiClient client) => _client = client;

    public Task<CommerceResponse> CreateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/orders/create", payload, cancellationToken);

    public Task<CommerceResponse> CreateAsync(OrderCreateRequest payload, CancellationToken cancellationToken = default)
    {
        ValidateCreate(payload);
        return _client.PostAsync("/orders/create", payload, cancellationToken);
    }

    public Task<CommerceResponse> NewAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/orders/new", payload, cancellationToken);

    public Task<CommerceResponse> NewAsync(OrderCreateRequest payload, CancellationToken cancellationToken = default)
    {
        ValidateCreate(payload);
        return _client.PostAsync("/orders/new", payload, cancellationToken);
    }

    public Task<CommerceResponse> UpdateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/orders/update", payload, cancellationToken);

    public Task<CommerceResponse> UpdateAsync(OrderUpdateRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.OrderId, "order_id");
        return _client.PostAsync("/orders/update", payload, cancellationToken);
    }

    public Task<CommerceResponse> LookupAsync(string orderId, object? options = null, CancellationToken cancellationToken = default)
    {
        var body = options as IDictionary<string, object?> ?? new Dictionary<string, object?>();
        body["order_id"] = orderId;
        return _client.PostAsync("/orders/lookup", body, cancellationToken);
    }

    public Task<CommerceResponse> LookupAsync(OrderLookupRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.OrderId, "order_id");
        return _client.PostAsync("/orders/lookup", payload, cancellationToken);
    }

    public Task<CommerceResponse> PayAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/orders/pay", payload, cancellationToken);

    public Task<CommerceResponse> PayAsync(OrderPayRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.OrderId, "order_id");
        return _client.PostAsync("/orders/pay", payload, cancellationToken);
    }

    public Task<CommerceResponse> ConfirmPaymentAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/orders/confirm_payment", payload, cancellationToken);

    public Task<CommerceResponse> ConfirmPaymentAsync(OrderConfirmPaymentRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.OrderId, "order_id");
        RequestValidator.Require(payload.Token, "token");
        return _client.PostAsync("/orders/confirm_payment", payload, cancellationToken);
    }

    public Task<CommerceResponse> RequestConfirmationAsync(string orderId, CancellationToken cancellationToken = default) =>
        RequestConfirmationAsync(new OrderRequestConfirmationRequest
        {
            OrderId = orderId,
            RequestMeta = StableOrderRequestMeta("request_confirmation", orderId)
        }, cancellationToken);

    public Task<CommerceResponse> RequestConfirmationAsync(OrderRequestConfirmationRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.OrderId, "order_id");
        return _client.PostAsync("/orders/request_confirmation", payload, cancellationToken);
    }

    public Task<CommerceResponse> FinalizeAsync(string orderId, CancellationToken cancellationToken = default) =>
        FinalizeAsync(new OrderFinalizeRequest
        {
            OrderId = orderId,
            RequestMeta = StableOrderRequestMeta("finalize", orderId)
        }, cancellationToken);

    public Task<CommerceResponse> FinalizeAsync(OrderFinalizeRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.OrderId, "order_id");
        return _client.PostAsync("/orders/finalize", payload, cancellationToken);
    }

    public Task<CommerceResponse> SendInvoiceAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/orders/send_invoice", payload, cancellationToken);

    public Task<CommerceResponse> SendInvoiceAsync(OrderSendInvoiceParams payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.OrderId, "order_id");
        return _client.PostAsync("/orders/send_invoice", payload, cancellationToken);
    }

    public Task<CommerceResponse> SendReceiptAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/orders/send_receipt", payload, cancellationToken);

    public Task<CommerceResponse> SendReceiptAsync(OrderSendReceiptParams payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.OrderId, "order_id");
        return _client.PostAsync("/orders/send_receipt", payload, cancellationToken);
    }

    public Task<CommerceResponse> CompleteAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/orders/complete", payload, cancellationToken);

    public Task<CommerceResponse> CompleteAsync(OrderCompleteRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.OrderId, "order_id");
        return _client.PostAsync("/orders/complete", payload, cancellationToken);
    }

    public Task<CommerceResponse> CancelAsync(string orderId, CancellationToken cancellationToken = default) =>
        CancelAsync(new OrderCancelRequest
        {
            OrderId = orderId,
            RequestMeta = StableOrderRequestMeta("cancel", orderId)
        }, cancellationToken);

    public Task<CommerceResponse> CancelAsync(OrderCancelRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.OrderId, "order_id");
        return _client.PostAsync("/orders/cancel", payload, cancellationToken);
    }

    public Task<CommerceResponse> RefundAsync(string orderId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/orders/refund", new { order_id = orderId }, cancellationToken);

    public Task<CommerceResponse> RefundAsync(OrderRefundRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.OrderId, "order_id");
        return _client.PostAsync("/orders/refund", payload, cancellationToken);
    }

    public Task<CommerceResponse> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/orders/page", payload ?? new { }, cancellationToken);

    public Task<CommerceResponse> PageAsync(OrderPageRequest payload, CancellationToken cancellationToken = default) =>
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
