namespace Inttegro;

/// <summary>String constants for every enum published by the Inttegro API.</summary>
public static class ApiEnums
{
    public static class AppManagementRole { public const string Parent = "parent", Child = "child"; }
    public static class AppCredentialOwner { public const string Child = "child", Parent = "parent"; }
    public static class AppRelationshipKind { public const string Placement = "placement"; }
    public static class AppRelationshipStatus { public const string Active = "active", Inactive = "inactive", Suspended = "suspended", Revoked = "revoked"; }
    public static class SecretKeyTokenType { public const string Bearer = "bearer"; }
    public static class SecretKeyStatus { public const string Active = "active", Revoked = "revoked", Expired = "expired"; }
    public static class SecretKeyAuthResult { public const string Succeeded = "succeeded", Failed = "failed"; }

    public static class FileStatus { public const string Uploading = "uploading", Processing = "processing", Available = "available", Failed = "failed", Deleted = "deleted"; }
    public static class FileDisposition { public const string Attachment = "attachment", Inline = "inline"; }
    public static class FileDelivery { public const string Stream = "stream", Redirect = "redirect"; }
    public static class FileScanStatus { public const string Pending = "pending", Passed = "passed", Failed = "failed", Skipped = "skipped"; }
    public static class FileSourceType { public const string Direct = "direct", UploadRequest = "upload_request", Service = "service"; }
    public static class FileStorageEncoding { public const string Identity = "identity", Brotli = "br"; }
    public static class FileLinkStatus { public const string Active = "active", Revoked = "revoked", Expired = "expired", Disabled = "disabled"; }
    public static class FileLinkKind { public const string Public = "public"; }
    public static class FileLinkDeliveryMode { public const string Redirect = "redirect", Download = "download", Inline = "inline"; }
    public static class UploadRequestStatus { public const string Pending = "pending", Uploading = "uploading", Fulfilled = "fulfilled", Expired = "expired", Canceled = "canceled", Failed = "failed"; }
    public static class UploadReviewDecision { public const string Approved = "approved", Rejected = "rejected"; }
    public static class UploadReviewType { public const string Automatic = "automatic", Manual = "manual"; }

    public static class PaymentNextActionType { public const string ConfirmPayment = "confirm_payment", Execute = "execute", Redirect = "redirect", Authorize = "authorize", None = "none"; }
    public static class PaymentConfirmationChannel { public const string Sms = "sms", Email = "email", Push = "push"; }
    public static class PaymentMethodType { public const string MobileMoney = "mobile_money", BankAccount = "bank_account", Card = "card", Motito = "motito"; }
    public static class MobileMoneyNetwork { public const string Airtel = "airtel", Mtn = "mtn", Telecel = "telecel", Vodafone = "vodafone"; }

    public static class ProductType { public const string Physical = "physical", Digital = "digital", Service = "service", Voucher = "voucher", Custom = "custom", Cause = "cause"; }
    public static class ProductShipmentType { public const string Delivery = "delivery", Download = "download", Render = "render", Service = "service", Stream = "stream"; }
    public static class ProductShipmentInputType { public const string Delivery = "delivery", Download = "download", Render = "render", Stream = "stream"; }
    public static class LineItemType { public const string Product = "product", Fee = "fee", Shipping = "shipping"; }
    public static class PurchaseIntentStatus { public const string Active = "active", Expired = "expired", Inactive = "inactive", Used = "used"; }
    public static class PurchaseIntentActivityType { public const string ExpiredViewed = "expired_viewed", OrderCreated = "order_created", PaymentFailed = "payment_failed", PaymentStarted = "payment_started", Viewed = "viewed"; }

    public static class FinancialAccountType { public const string Wallet = "wallet", BankAccount = "bank_account", DoshAccount = "dosh_account"; }
    public static class WalletType { public const string MobileMoney = "mobile_money"; }
    public static class BankAccountType { public const string GhanaBankAccount = "ghana_bank_account"; }

    public static class MessageTemplateChannel { public const string Sms = "sms", Email = "email"; }
    public static class MessageTemplateStatus { public const string Draft = "draft", Published = "published", Archived = "archived"; }
    public static class MessageTemplateVariableType { public const string String = "string", Number = "number", Integer = "integer", Boolean = "boolean", Url = "url", Email = "email", Phone = "phone", Date = "date", Datetime = "datetime", Array = "array"; }
    public static class MessageTemplateVariableItemType { public const string String = "string", Number = "number", Integer = "integer", Boolean = "boolean", Url = "url", Email = "email", Phone = "phone", Date = "date", Datetime = "datetime"; }
    public static class ContentSafetyStatus { public const string Allowed = "allowed", Rejected = "rejected", Quarantined = "quarantined"; }

    public static class OrderDocumentKind { public const string Invoice = "invoice", Receipt = "receipt"; }
    public static class DeliveryChannel { public const string Email = "email", Sms = "sms"; }
    public static class CheckoutOrderStatus { public const string Preparing = "preparing", RequiresPayment = "requires_payment", Completed = "completed", Canceled = "canceled", Expired = "expired"; }
    public static class OrderStatus { public const string Preparing = "preparing", RequiresPayment = "requires_payment", Paid = "paid", Completed = "completed", Canceled = "canceled", Expired = "expired", Unknown = "unknown"; }
    public static class OrderPaymentStatus { public const string Initiated = "initiated", RequiresAction = "requires_action", Overdue = "overdue", Executed = "executed", Paid = "paid", Canceled = "canceled", Expired = "expired", Failed = "failed", Unknown = "unknown"; }
    public static class PaymentAttemptStatus { public const string Initiated = "initiated", Executed = "executed", Succeeded = "succeeded", Canceled = "canceled", Expired = "expired", Failed = "failed", Unknown = "unknown"; }
    public static class CheckoutPaymentStatus { public const string RequiresAction = "requires_action", Processing = "processing", Succeeded = "succeeded", Failed = "failed", Cancelled = "cancelled"; }
    public static class PaymentResponseStatus { public const string Pending = "pending", RequiresConfirmation = "requires_confirmation", Processing = "processing", Succeeded = "succeeded", Failed = "failed"; }
    public static class OrderCreatedFromResourceType { public const string PurchaseIntent = "purchase_intent"; }

    public static class RefundReason { public const string RequestedByCustomer = "requested_by_customer", Duplicate = "duplicate", Fraudulent = "fraudulent", OrderCanceled = "order_canceled", ItemReturned = "item_returned", ItemDamaged = "item_damaged", ItemNotReceived = "item_not_received", ItemNotAsDescribed = "item_not_as_described", Custom = "custom"; }
    public static class RefundStatus { public const string Canceled = "canceled", Failed = "failed", Pending = "pending", Processing = "processing", Succeeded = "succeeded"; }
    public static class BalanceTransactionType { public const string Payment = "payment", Refund = "refund"; }
    public static class PayoutStatus { public const string Initialized = "initialized", Scheduled = "scheduled", Processing = "processing", Executing = "executing", Succeeded = "succeeded", Invalid = "invalid", Canceled = "canceled"; }

    public static class ChimeRecipientType { public const string Phone = "phone", Email = "email"; }
    public static class ChimeTransport { public const string Sms = "sms", Email = "email"; }
    public static class ChimeEmailSchemaKind { public const string GmailViewAction = "gmail_view_action", SchemaOrgOrder = "schema_org_order", SchemaOrgInvoice = "schema_org_invoice"; }

    public static class OTPAlphabetType { public const string Numeric = "numeric", Alpha = "alpha", Alphanumeric = "alphanumeric"; }
    public static class OTPStatus { public const string Canceled = "canceled", Expired = "expired", Pending = "pending", PendingDelivery = "pending_delivery", PendingVerification = "pending_verification", Verified = "verified"; }
    public static class OTPTransmissionStatus { public const string Delivered = "delivered", Failed = "failed", Submitted = "submitted"; }
    public static class OTPVerificationVerdict { public const string Fail = "fail", Pass = "pass"; }
}
