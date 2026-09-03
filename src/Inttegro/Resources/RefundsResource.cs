using Inttegro.Http;
using Inttegro;
using Inttegro.Validation;

namespace Inttegro.Resources;

public sealed class RefundsResource
{
    private readonly ApiClient _client;

    internal RefundsResource(ApiClient client) => _client = client;

    public Task<Refund> CreateAsync(
        CreateRefundRequest payload,
        CancellationToken cancellationToken = default
    ) => CreateAsync(payload, idempotencyKey: null, cancellationToken);

    public Task<Refund> CreateAsync(
        CreateRefundRequest payload,
        string? idempotencyKey,
        CancellationToken cancellationToken = default
    )
    {
        ValidateCreate(payload);
        return _client.PostResourceWithHeadersAsync<Refund>(
            "/refunds/create",
            "refund",
            payload,
            IdempotencyHeaders(idempotencyKey),
            cancellationToken
        );
    }

    public Task<Refund> CancelAsync(
        string refundId,
        CancellationToken cancellationToken = default
    ) => CancelAsync(new CancelRefundRequest { RefundId = refundId }, idempotencyKey: null, cancellationToken);

    public Task<Refund> CancelAsync(
        CancelRefundRequest payload,
        CancellationToken cancellationToken = default
    ) => CancelAsync(payload, idempotencyKey: null, cancellationToken);

    public Task<Refund> CancelAsync(
        CancelRefundRequest payload,
        string? idempotencyKey,
        CancellationToken cancellationToken = default
    )
    {
        RequestValidator.Require(payload.RefundId, "refund_id");
        return _client.PostResourceWithHeadersAsync<Refund>(
            "/refunds/cancel",
            "refund",
            payload,
            IdempotencyHeaders(idempotencyKey),
            cancellationToken
        );
    }

    public Task<Refund> LookupAsync(
        string refundId,
        CancellationToken cancellationToken = default
    ) => LookupAsync(new LookupRefundRequest { RefundId = refundId }, cancellationToken);

    public Task<Refund> LookupAsync(
        LookupRefundRequest payload,
        CancellationToken cancellationToken = default
    )
    {
        RequestValidator.Require(payload.RefundId, "refund_id");
        return _client.PostResourceAsync<Refund>("/refunds/lookup", "refund", payload, cancellationToken);
    }

    public Task<RefundPage> PageAsync(
        PageRefundsRequest payload,
        CancellationToken cancellationToken = default
    )
    {
        RequestValidator.Require(payload.PageNumber, "page_number");
        return _client.PostResourceAsync<RefundPage>("/refunds/page", "page", payload, cancellationToken);
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
