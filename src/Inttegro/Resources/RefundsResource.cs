using Inttegro.Http;
using Inttegro.Models;
using Inttegro.Responses;
using Inttegro.Validation;

namespace Inttegro.Resources;

public sealed class RefundsResource
{
    private readonly ApiClient _client;

    internal RefundsResource(ApiClient client) => _client = client;

    public Task<InttegroResponse> CreateAsync(
        CreateRefundRequest payload,
        CancellationToken cancellationToken = default
    ) => CreateAsync(payload, idempotencyKey: null, cancellationToken);

    public Task<InttegroResponse> CreateAsync(
        CreateRefundRequest payload,
        string? idempotencyKey,
        CancellationToken cancellationToken = default
    )
    {
        ValidateCreate(payload);
        return _client.PostWithHeadersAsync(
            "/refunds/create",
            payload,
            IdempotencyHeaders(idempotencyKey),
            cancellationToken
        );
    }

    public Task<InttegroResponse> CancelAsync(
        string refundId,
        CancellationToken cancellationToken = default
    ) => CancelAsync(new CancelRefundRequest { RefundId = refundId }, idempotencyKey: null, cancellationToken);

    public Task<InttegroResponse> CancelAsync(
        CancelRefundRequest payload,
        CancellationToken cancellationToken = default
    ) => CancelAsync(payload, idempotencyKey: null, cancellationToken);

    public Task<InttegroResponse> CancelAsync(
        CancelRefundRequest payload,
        string? idempotencyKey,
        CancellationToken cancellationToken = default
    )
    {
        RequestValidator.Require(payload.RefundId, "refund_id");
        return _client.PostWithHeadersAsync(
            "/refunds/cancel",
            payload,
            IdempotencyHeaders(idempotencyKey),
            cancellationToken
        );
    }

    public Task<InttegroResponse> LookupAsync(
        string refundId,
        CancellationToken cancellationToken = default
    ) => LookupAsync(new LookupRefundRequest { RefundId = refundId }, cancellationToken);

    public Task<InttegroResponse> LookupAsync(
        LookupRefundRequest payload,
        CancellationToken cancellationToken = default
    )
    {
        RequestValidator.Require(payload.RefundId, "refund_id");
        return _client.PostAsync("/refunds/lookup", payload, cancellationToken);
    }

    public Task<InttegroResponse> PageAsync(
        PageRefundsRequest payload,
        CancellationToken cancellationToken = default
    )
    {
        RequestValidator.Require(payload.PageNumber, "page_number");
        return _client.PostAsync("/refunds/page", payload, cancellationToken);
    }

    internal static void ValidateCreate(CreateRefundRequest payload)
    {
        RequestValidator.Require(payload.OrderId, "order_id");
        RequestValidator.Require(payload.Reason, "reason");
        RequestValidator.RequireCollection(payload.LineItems, "line_items");
        foreach (var line in payload.LineItems!)
        {
            RequestValidator.Require(line.OrderLineItemId, "order_line_item_id");
            RequestValidator.Require(line.RefundAmount, "refund_amount");
        }
    }

    internal static IDictionary<string, string> IdempotencyHeaders(string? idempotencyKey) =>
        string.IsNullOrWhiteSpace(idempotencyKey)
            ? new Dictionary<string, string>()
            : new Dictionary<string, string> { ["Idempotency-Key"] = idempotencyKey };
}
