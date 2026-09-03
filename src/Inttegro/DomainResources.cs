using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Inttegro;

public sealed class App
{
    [JsonPropertyName("id")] public string? Id { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("alias")] public string? Alias { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("legal_entity_type")] public string? LegalEntityType { get; set; }
    [JsonPropertyName("created_at")] public string? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public string? UpdatedAt { get; set; }
    [JsonPropertyName("archived_at")] public string? ArchivedAt { get; set; }
    [JsonPropertyName("secret_key")] public GeneratedSecretKey? SecretKey { get; set; }
    [JsonPropertyName("relationship")] public AppRelationship? Relationship { get; set; }
    [JsonExtensionData] public Dictionary<string, JsonElement>? Extra { get; set; }
}

public sealed class AppRelationship
{
    [JsonPropertyName("id")] public string? Id { get; set; }
    [JsonPropertyName("kind")] public string? Kind { get; set; }
    [JsonPropertyName("status")] public string? Status { get; set; }
    [JsonPropertyName("actor_app_id")] public string? ActorAppId { get; set; }
    [JsonPropertyName("creator_app_id")] public string? CreatorAppId { get; set; }
    [JsonPropertyName("placement_parent_app_id")] public string? PlacementParentAppId { get; set; }
    [JsonPropertyName("subject_app_id")] public string? SubjectAppId { get; set; }
    [JsonPropertyName("child_app_id")] public string? ChildAppId { get; set; }
    [JsonPropertyName("child_standing")] public string? ChildStanding { get; set; }
    [JsonPropertyName("relationship_policy")] public JsonObject? RelationshipPolicy { get; set; }
    [JsonPropertyName("created_at")] public string? CreatedAt { get; set; }
    [JsonExtensionData] public Dictionary<string, JsonElement>? Extra { get; set; }
}

public sealed class BalanceAmount
{
    [JsonPropertyName("amount")] public long? Amount { get; set; }
}

public sealed class BalanceBreakdown
{
    [JsonPropertyName("available")] public BalanceAmount? Available { get; set; }
    [JsonPropertyName("pending")] public BalanceAmount? Pending { get; set; }
    [JsonPropertyName("reserved")] public BalanceAmount? Reserved { get; set; }
    [JsonPropertyName("refund")] public BalanceAmount? Refund { get; set; }
    [JsonPropertyName("includes_transactions_before")] public string? IncludesTransactionsBefore { get; set; }
}

public sealed class BalanceSnapshot : Dictionary<string, BalanceBreakdown> { }

public sealed class BalanceTransactionPage
{
    [JsonPropertyName("number")] public int? Number { get; set; }
    [JsonPropertyName("size")] public int? Size { get; set; }
    [JsonPropertyName("transactions")] public List<BalanceTransaction>? Transactions { get; set; }
}

public sealed class Broadcast
{
    [JsonPropertyName("id")] public string? Id { get; set; }
    [JsonPropertyName("recipients")] public List<string>? Recipients { get; set; }
    [JsonPropertyName("customer_ids")] public List<string>? CustomerIds { get; set; }
    [JsonPropertyName("content")] public string? Content { get; set; }
    [JsonPropertyName("sender_id")] public string? SenderId { get; set; }
    [JsonPropertyName("purpose")] public string? Purpose { get; set; }
    [JsonPropertyName("send_after")] public string? SendAfter { get; set; }
    [JsonPropertyName("created_at")] public string? CreatedAt { get; set; }
    [JsonPropertyName("executed_at")] public string? ExecutedAt { get; set; }
    [JsonPropertyName("canceled_at")] public string? CanceledAt { get; set; }
    [JsonPropertyName("chime_ids")] public List<string>? ChimeIds { get; set; }
    [JsonPropertyName("errors")] public List<ApiError>? Errors { get; set; }
    [JsonExtensionData] public Dictionary<string, JsonElement>? Extra { get; set; }
}

public sealed class Chime
{
    [JsonPropertyName("id")] public string? Id { get; set; }
    [JsonPropertyName("created_at")] public string? CreatedAt { get; set; }
    [JsonPropertyName("full_message")] public string? FullMessage { get; set; }
    [JsonPropertyName("sender_id")] public string? SenderId { get; set; }
    [JsonPropertyName("purpose")] public string? Purpose { get; set; }
    [JsonPropertyName("customer_id")] public string? CustomerId { get; set; }
    [JsonPropertyName("recipient")] public JsonObject? Recipient { get; set; }
    [JsonPropertyName("email")] public JsonObject? Email { get; set; }
    [JsonPropertyName("transmission")] public ChimeTransmission? Transmission { get; set; }
    [JsonPropertyName("custom_data")] public Dictionary<string, string>? CustomData { get; set; }
    [JsonExtensionData] public Dictionary<string, JsonElement>? Extra { get; set; }
}

public sealed class ChimeTransmission
{
    [JsonPropertyName("recipient")] public string? Recipient { get; set; }
    [JsonPropertyName("sender_id")] public string? SenderId { get; set; }
    [JsonPropertyName("sent_via")] public string? SentVia { get; set; }
    [JsonPropertyName("status")] public string? Status { get; set; }
    [JsonPropertyName("sent_at")] public string? SentAt { get; set; }
    [JsonPropertyName("delivered_at")] public string? DeliveredAt { get; set; }
    [JsonPropertyName("failed_at")] public string? FailedAt { get; set; }
}

public sealed class ChimePage
{
    [JsonPropertyName("number")] public int? Number { get; set; }
    [JsonPropertyName("size")] public int? Size { get; set; }
    [JsonPropertyName("chimes")] public List<Chime>? Chimes { get; set; }
}

public sealed class ScheduledChime
{
    [JsonPropertyName("id")] public string? Id { get; set; }
    [JsonPropertyName("recipients")] public List<string>? Recipients { get; set; }
    [JsonPropertyName("content")] public string? Content { get; set; }
    [JsonPropertyName("full_message")] public string? FullMessage { get; set; }
    [JsonPropertyName("sender_id")] public string? SenderId { get; set; }
    [JsonPropertyName("purpose")] public string? Purpose { get; set; }
    [JsonPropertyName("send_after")] public string? SendAfter { get; set; }
    [JsonPropertyName("created_at")] public string? CreatedAt { get; set; }
    [JsonPropertyName("executed_at")] public string? ExecutedAt { get; set; }
    [JsonPropertyName("canceled_at")] public string? CanceledAt { get; set; }
    [JsonPropertyName("chime_ids")] public List<string>? ChimeIds { get; set; }
    [JsonPropertyName("errors")] public List<ApiError>? Errors { get; set; }
    [JsonExtensionData] public Dictionary<string, JsonElement>? Extra { get; set; }
}

public sealed class MessageTemplate
{
    [JsonPropertyName("id")] public string? Id { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("about")] public string? About { get; set; }
    [JsonPropertyName("channel")] public string? Channel { get; set; }
    [JsonPropertyName("purpose")] public string? Purpose { get; set; }
    [JsonPropertyName("locale")] public string? Locale { get; set; }
    [JsonPropertyName("status")] public string? Status { get; set; }
    [JsonPropertyName("sms")] public JsonObject? Sms { get; set; }
    [JsonPropertyName("email")] public JsonObject? Email { get; set; }
    [JsonPropertyName("variables")] public List<JsonObject>? Variables { get; set; }
    [JsonPropertyName("attachments")] public List<string>? Attachments { get; set; }
    [JsonPropertyName("created_at")] public string? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public string? UpdatedAt { get; set; }
    [JsonPropertyName("published_at")] public string? PublishedAt { get; set; }
    [JsonPropertyName("archived_at")] public string? ArchivedAt { get; set; }
    [JsonExtensionData] public Dictionary<string, JsonElement>? Extra { get; set; }
}

public sealed class MessageTemplatePage
{
    [JsonPropertyName("number")] public int? Number { get; set; }
    [JsonPropertyName("size")] public int? Size { get; set; }
    [JsonPropertyName("message_templates")] public List<MessageTemplate>? MessageTemplates { get; set; }
}

public sealed class MessageTemplatePreview
{
    [JsonPropertyName("message_template")] public MessageTemplate? MessageTemplate { get; set; }
    [JsonPropertyName("rendered")] public JsonObject? Rendered { get; set; }
}

public sealed class OtpTransaction
{
    [JsonPropertyName("id")] public string? Id { get; set; }
    [JsonPropertyName("status")] public string? Status { get; set; }
    [JsonPropertyName("full_message")] public string? FullMessage { get; set; }
    [JsonPropertyName("initiated_at")] public string? InitiatedAt { get; set; }
    [JsonPropertyName("expires_at")] public string? ExpiresAt { get; set; }
    [JsonPropertyName("canceled_at")] public string? CanceledAt { get; set; }
    [JsonPropertyName("cancel_reason")] public string? CancelReason { get; set; }
    [JsonPropertyName("transmission")] public ChimeTransmission? Transmission { get; set; }
    [JsonExtensionData] public Dictionary<string, JsonElement>? Extra { get; set; }
}

public sealed class OtpVerificationAttempt
{
    [JsonPropertyName("id")] public string? Id { get; set; }
    [JsonPropertyName("recipient")] public string? Recipient { get; set; }
    [JsonPropertyName("presented_token")] public string? PresentedToken { get; set; }
    [JsonPropertyName("attempted_at")] public string? AttemptedAt { get; set; }
    [JsonPropertyName("result")] public JsonObject? Result { get; set; }
}

public sealed class OtpVerification
{
    [JsonPropertyName("transaction")] public OtpTransaction? Transaction { get; set; }
    [JsonPropertyName("verification_attempt")] public OtpVerificationAttempt? VerificationAttempt { get; set; }
}

public sealed class GeneratedSecretKey
{
    [JsonPropertyName("id")] public string? Id { get; set; }
    [JsonPropertyName("label")] public string? Label { get; set; }
    [JsonPropertyName("token_type")] public string? TokenType { get; set; }
    [JsonPropertyName("issued_at")] public string? IssuedAt { get; set; }
    [JsonPropertyName("token")] public string? Token { get; set; }
}

public sealed class SecretKey
{
    [JsonPropertyName("id")] public string? Id { get; set; }
    [JsonPropertyName("label")] public string? Label { get; set; }
    [JsonPropertyName("token_type")] public string? TokenType { get; set; }
    [JsonPropertyName("issued_at")] public string? IssuedAt { get; set; }
    [JsonPropertyName("updated_at")] public string? UpdatedAt { get; set; }
    [JsonPropertyName("expires_at")] public string? ExpiresAt { get; set; }
    [JsonPropertyName("status")] public string? Status { get; set; }
    [JsonPropertyName("active")] public bool? Active { get; set; }
    [JsonPropertyName("revoked_at")] public string? RevokedAt { get; set; }
    [JsonPropertyName("last_used_at")] public string? LastUsedAt { get; set; }
    [JsonPropertyName("usage_count")] public int? UsageCount { get; set; }
}

public sealed class SecretKeyPage
{
    [JsonPropertyName("number")] public int? Number { get; set; }
    [JsonPropertyName("size")] public int? Size { get; set; }
    [JsonPropertyName("count")] public int? Count { get; set; }
    [JsonPropertyName("total")] public int? Total { get; set; }
    [JsonPropertyName("has_more")] public bool? HasMore { get; set; }
    [JsonPropertyName("keys")] public List<SecretKey>? Keys { get; set; }
}

public sealed class SecretKeyUsageRow
{
    [JsonPropertyName("secret_key_id")] public string? SecretKeyId { get; set; }
    [JsonPropertyName("occurred_at")] public string? OccurredAt { get; set; }
    [JsonPropertyName("auth_result")] public string? AuthResult { get; set; }
}

public sealed class SecretKeyUsagePage
{
    [JsonPropertyName("number")] public int? Number { get; set; }
    [JsonPropertyName("size")] public int? Size { get; set; }
    [JsonPropertyName("count")] public int? Count { get; set; }
    [JsonPropertyName("total")] public int? Total { get; set; }
    [JsonPropertyName("has_more")] public bool? HasMore { get; set; }
    [JsonPropertyName("rows")] public List<SecretKeyUsageRow>? Rows { get; set; }
}

public sealed class SecretKeyUsage
{
    [JsonPropertyName("key")] public SecretKey? Key { get; set; }
    [JsonPropertyName("usage")] public SecretKeyUsagePage? Usage { get; set; }
}

public sealed class StoredFile
{
    [JsonPropertyName("id")] public string? Id { get; set; }
    [JsonPropertyName("purpose")] public string? Purpose { get; set; }
    [JsonPropertyName("status")] public string? Status { get; set; }
    [JsonPropertyName("scan_status")] public string? ScanStatus { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("filename")] public string? Filename { get; set; }
    [JsonPropertyName("content_type")] public string? ContentType { get; set; }
    [JsonPropertyName("size")] public long? Size { get; set; }
    [JsonPropertyName("created_at")] public string? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public string? UpdatedAt { get; set; }
    [JsonPropertyName("deleted_at")] public string? DeletedAt { get; set; }
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("custom_data")] public Dictionary<string, string>? CustomData { get; set; }
    [JsonExtensionData] public Dictionary<string, JsonElement>? Extra { get; set; }
}

public sealed class StoredFilePage
{
    [JsonPropertyName("number")] public int? Number { get; set; }
    [JsonPropertyName("size")] public int? Size { get; set; }
    [JsonPropertyName("files")] public List<StoredFile>? Files { get; set; }
}

public sealed class FileLink
{
    [JsonPropertyName("id")] public string? Id { get; set; }
    [JsonPropertyName("file_id")] public string? FileId { get; set; }
    [JsonPropertyName("status")] public string? Status { get; set; }
    [JsonPropertyName("expires_at")] public string? ExpiresAt { get; set; }
    [JsonPropertyName("created_at")] public string? CreatedAt { get; set; }
    [JsonPropertyName("revoked_at")] public string? RevokedAt { get; set; }
    [JsonPropertyName("custom_data")] public Dictionary<string, string>? CustomData { get; set; }
    [JsonExtensionData] public Dictionary<string, JsonElement>? Extra { get; set; }
}

public sealed class FileLinkPage
{
    [JsonPropertyName("number")] public int? Number { get; set; }
    [JsonPropertyName("size")] public int? Size { get; set; }
    [JsonPropertyName("file_links")] public List<FileLink>? FileLinks { get; set; }
}

public sealed class FileLinkCreation
{
    [JsonPropertyName("file_link")] public FileLink? FileLink { get; set; }
    [JsonPropertyName("url")] public string? Url { get; set; }
}

public sealed class FileReferenceReconciliation
{
    [JsonPropertyName("reconciled")] public bool? Reconciled { get; set; }
    [JsonPropertyName("error")] public ApiError? Error { get; set; }
}

public sealed class UploadRequest
{
    [JsonPropertyName("id")] public string? Id { get; set; }
    [JsonPropertyName("purpose")] public string? Purpose { get; set; }
    [JsonPropertyName("status")] public string? Status { get; set; }
    [JsonPropertyName("upload_url")] public string? UploadUrl { get; set; }
    [JsonPropertyName("expires_at")] public string? ExpiresAt { get; set; }
    [JsonPropertyName("created_at")] public string? CreatedAt { get; set; }
    [JsonPropertyName("canceled_at")] public string? CanceledAt { get; set; }
    [JsonPropertyName("custom_data")] public Dictionary<string, string>? CustomData { get; set; }
    [JsonPropertyName("metadata")] public Dictionary<string, string>? Metadata { get; set; }
    [JsonPropertyName("constraints")] public JsonObject? Constraints { get; set; }
    [JsonPropertyName("display")] public JsonObject? Display { get; set; }
    [JsonPropertyName("attempts")] public JsonObject? Attempts { get; set; }
    [JsonExtensionData] public Dictionary<string, JsonElement>? Extra { get; set; }
}

public sealed class UploadRequestPage
{
    [JsonPropertyName("number")] public int? Number { get; set; }
    [JsonPropertyName("size")] public int? Size { get; set; }
    [JsonPropertyName("upload_requests")] public List<UploadRequest>? UploadRequests { get; set; }
}

public sealed class UploadFulfillment
{
    [JsonPropertyName("upload_request")] public UploadRequest? UploadRequest { get; set; }
    [JsonPropertyName("file")] public StoredFile? File { get; set; }
}

public sealed class PaymentMethodVerificationSession
{
    [JsonPropertyName("payment_method_id")] public string? PaymentMethodId { get; set; }
    [JsonPropertyName("status")] public string? Status { get; set; }
    [JsonPropertyName("token_sent_at")] public string? TokenSentAt { get; set; }
    [JsonPropertyName("expires_at")] public string? ExpiresAt { get; set; }
    [JsonPropertyName("delivery")] public JsonObject? Delivery { get; set; }
}

public sealed class PaymentMethodDeletion
{
    [JsonPropertyName("deleted")] public bool? Deleted { get; set; }
    [JsonPropertyName("payment_method_id")] public string? PaymentMethodId { get; set; }
}

public sealed class PurchaseIntent
{
    [JsonPropertyName("id")] public string? Id { get; set; }
    [JsonPropertyName("application_id")] public string? ApplicationId { get; set; }
    [JsonPropertyName("product_id")] public string? ProductId { get; set; }
    [JsonPropertyName("price_id")] public string? PriceId { get; set; }
    [JsonPropertyName("quantity")] public PurchaseIntentQuantity? Quantity { get; set; }
    [JsonPropertyName("status")] public string? Status { get; set; }
    [JsonPropertyName("created_at")] public string? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public string? UpdatedAt { get; set; }
    [JsonPropertyName("expires_at")] public string? ExpiresAt { get; set; }
    [JsonPropertyName("product")] public Product? Product { get; set; }
    [JsonPropertyName("price")] public PurchaseIntentPrice? Price { get; set; }
    [JsonExtensionData] public Dictionary<string, JsonElement>? Extra { get; set; }
}

public sealed class PurchaseIntentPage
{
    [JsonPropertyName("number")] public int? Number { get; set; }
    [JsonPropertyName("size")] public int? Size { get; set; }
    [JsonPropertyName("purchase_intents")] public List<PurchaseIntent>? PurchaseIntents { get; set; }
}

public sealed class CountrySpecification
{
    [JsonPropertyName("country_code")] public string? CountryCode { get; set; }
    [JsonPropertyName("country_name")] public string? CountryName { get; set; }
    [JsonPropertyName("currencies")] public List<string>? Currencies { get; set; }
    [JsonPropertyName("payment_methods")] public List<string>? PaymentMethods { get; set; }
    [JsonPropertyName("payout_schedules")] public List<string>? PayoutSchedules { get; set; }
    [JsonPropertyName("bt_aging_specs")] public List<string>? BalanceTransactionAgingSpecs { get; set; }
    [JsonExtensionData] public Dictionary<string, JsonElement>? Extra { get; set; }
}

public sealed class CountrySpecifications : Dictionary<string, CountrySpecification> { }
