using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Inttegro.BankAccounts;
using Inttegro.Money;
using Inttegro.Wallets;

namespace Inttegro;

public sealed class OrderPayoutSettings
{
    [JsonPropertyName("destination")]
    public OrderPayoutDestination? Destination { get; set; }

    [JsonPropertyName("enable_fx")]
    public bool? EnableFx { get; set; }
}

public sealed class OrderPayoutDestination
{
    [JsonPropertyName("financial_account_id")]
    public string? FinancialAccountId { get; set; }

    [JsonPropertyName("financial_account_data")]
    public OrderPayoutFinancialAccount? FinancialAccountData { get; set; }
}

public sealed class OrderPayoutFinancialAccount
{
    [JsonPropertyName("type")]
    public FinancialAccountType Type { get; set; }

    [JsonPropertyName("wallet")]
    public WalletConfig? Wallet { get; set; }

    [JsonPropertyName("bank_account")]
    public BankAccountConfig? BankAccount { get; set; }

    [JsonPropertyName("dosh_account")]
    public JsonObject? DoshAccount { get; set; }
}

public sealed class OrderCreateRequest
{
    [JsonPropertyName("request_meta")]
    public RequestMeta? RequestMeta { get; set; }

    [JsonPropertyName("customer_data")]
    public CustomerData? CustomerData { get; set; }

    [JsonPropertyName("customer_id")]
    public string? CustomerId { get; set; }

    [JsonPropertyName("payment_method_id")]
    public string? PaymentMethodId { get; set; }

    [JsonPropertyName("payment_method_data")]
    public PaymentMethodData? PaymentMethodData { get; set; }

    [JsonPropertyName("statement_descriptor")]
    public string? StatementDescriptor { get; set; }

    [JsonPropertyName("statement_descriptor_prefix")]
    public string? StatementDescriptorPrefix { get; set; }

    [JsonPropertyName("execute_payment")]
    public bool? ExecutePayment { get; set; }

    [JsonPropertyName("finalize")]
    public bool? Finalize { get; set; }

    [Obsolete("Use RequestMeta.IdempotencyKey instead.")]
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

    [JsonPropertyName("checkout_settings")]
    public CheckoutSettings? CheckoutSettings { get; set; }

    [JsonPropertyName("payout_settings")]
    public OrderPayoutSettings? PayoutSettings { get; set; }

    [JsonPropertyName("number")]
    public string? Number { get; set; }

    [JsonPropertyName("line_items")]
    public List<LineItemParams>? LineItems { get; set; }

    [JsonPropertyName("custom_data")]
    public Dictionary<string, string>? CustomData { get; set; }

    [JsonPropertyName("billing_details")]
    public BillingDetails? BillingDetails { get; set; }

    [JsonPropertyName("shipping")]
    public Shipping? Shipping { get; set; }
}

public sealed class OrderLookupRequest
{
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }
}

public sealed class OrderUpdateRequest
{
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    [JsonPropertyName("clear_payment_method")]
    public bool? ClearPaymentMethod { get; set; }

    [JsonPropertyName("custom_data")]
    public Dictionary<string, string>? CustomData { get; set; }

    [JsonPropertyName("invoice_settings")]
    public JsonObject? InvoiceSettings { get; set; }

    [JsonPropertyName("finalize")]
    public bool? Finalize { get; set; }

    [JsonPropertyName("line_items")]
    public List<LineItemParams>? LineItems { get; set; }

    [JsonPropertyName("number")]
    public string? Number { get; set; }

    [JsonPropertyName("receipt_number")]
    public string? ReceiptNumber { get; set; }

    [JsonPropertyName("payment_method_data")]
    public PaymentMethodData? PaymentMethodData { get; set; }

    [JsonPropertyName("payment_method_id")]
    public string? PaymentMethodId { get; set; }

    [JsonPropertyName("statement_descriptor")]
    public string? StatementDescriptor { get; set; }

    [JsonPropertyName("statement_descriptor_prefix")]
    public string? StatementDescriptorPrefix { get; set; }
}

public sealed class OrderPayRequest
{
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    [JsonPropertyName("request_meta")]
    public RequestMeta? RequestMeta { get; set; }

    [JsonPropertyName("payment_method_id")]
    public string? PaymentMethodId { get; set; }

    [JsonPropertyName("payment_method_data")]
    public PaymentMethodData? PaymentMethodData { get; set; }

    [JsonPropertyName("paid_out_of_band")]
    public bool? PaidOutOfBand { get; set; }
}

public sealed class OrderConfirmPaymentRequest
{
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    [JsonPropertyName("request_meta")]
    public RequestMeta? RequestMeta { get; set; }

    [JsonPropertyName("token")]
    public string? Token { get; set; }
}

public sealed class OrderRequestConfirmationRequest
{
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    [JsonPropertyName("request_meta")]
    public RequestMeta? RequestMeta { get; set; }
}

public sealed class OrderFinalizeRequest
{
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    [JsonPropertyName("request_meta")]
    public RequestMeta? RequestMeta { get; set; }
}

public sealed class OrderSendInvoiceParams
{
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    [JsonPropertyName("request_meta")]
    public RequestMeta? RequestMeta { get; set; }
}

public sealed class OrderSendReceiptParams
{
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    [JsonPropertyName("request_meta")]
    public RequestMeta? RequestMeta { get; set; }
}

public sealed class OrderCompleteRequest
{
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    [JsonPropertyName("paid_out_of_band")]
    public bool? PaidOutOfBand { get; set; }
}

public sealed class OrderCancelRequest
{
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    [JsonPropertyName("request_meta")]
    public RequestMeta? RequestMeta { get; set; }
}

public sealed class OrderPageRequest
{
    [JsonPropertyName("page_number")]
    public int? PageNumber { get; set; }

    [JsonPropertyName("page_size")]
    public int? PageSize { get; set; }
}

public sealed class OrderCustomer
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("email_address")]
    public string? EmailAddress { get; set; }

    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? Extra { get; set; }
}

public sealed class OrderLineItemGroup
{
    [JsonPropertyName("line_items")]
    public List<LineItem>? LineItems { get; set; }

    [JsonPropertyName("total")]
    public Amount? Total { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? Extra { get; set; }
}

public sealed class OrderInvoiceFormat
{
    [JsonPropertyName("web")]
    public InvoiceUrl? Web { get; set; }

    [JsonPropertyName("pdf")]
    public InvoiceUrl? Pdf { get; set; }
}

public sealed class InvoiceUrl
{
    [JsonPropertyName("url")]
    public string? Url { get; set; }
}

public sealed class OrderInvoice
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("format")]
    public OrderInvoiceFormat? Format { get; set; }

    [JsonPropertyName("deliveries")]
    public List<JsonObject>? Deliveries { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? Extra { get; set; }
}

public sealed class Order
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("number")]
    public string? Number { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("customer")]
    public OrderCustomer? Customer { get; set; }

    [JsonPropertyName("line_item_group")]
    public OrderLineItemGroup? LineItemGroup { get; set; }

    [JsonPropertyName("payment")]
    public Payment? Payment { get; set; }

    [JsonPropertyName("invoice")]
    public OrderInvoice? Invoice { get; set; }

    [JsonPropertyName("shipping")]
    public JsonObject? Shipping { get; set; }

    [JsonPropertyName("initiated_at")]
    public string? InitiatedAt { get; set; }

    [JsonPropertyName("sealed_at")]
    public string? SealedAt { get; set; }

    [JsonPropertyName("completed_at")]
    public string? CompletedAt { get; set; }

    [JsonPropertyName("refunds")]
    public List<Refund>? Refunds { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? Extra { get; set; }
}

public sealed class OrderPage
{
    [JsonPropertyName("number")]
    public int? Number { get; set; }

    [JsonPropertyName("size")]
    public int? Size { get; set; }

    [JsonPropertyName("orders")]
    public List<Order>? Orders { get; set; }
}

public sealed class OrderDocumentDeliveryResult
{
    [JsonPropertyName("order")]
    public Order? Order { get; set; }

    [JsonPropertyName("delivery")]
    public OrderDocumentDelivery? Delivery { get; set; }
}

public sealed class OrderDocumentDelivery
{
    [JsonPropertyName("document_kind")]
    public string? DocumentKind { get; set; }

    [JsonPropertyName("document_url")]
    public string? DocumentUrl { get; set; }

    [JsonPropertyName("sent_channels")]
    public List<string>? SentChannels { get; set; }

    [JsonPropertyName("failed_channels")]
    public List<string>? FailedChannels { get; set; }

    [JsonPropertyName("deliveries")]
    public List<OrderDocumentDeliveryAttempt>? Deliveries { get; set; }

    [JsonPropertyName("failures")]
    public List<OrderDocumentDeliveryAttempt>? Failures { get; set; }
}

public sealed class OrderDocumentDeliveryAttempt
{
    [JsonPropertyName("channel")]
    public string? Channel { get; set; }

    [JsonPropertyName("chime_id")]
    public string? ChimeId { get; set; }

    [JsonPropertyName("error")]
    public string? Error { get; set; }
}
