using System.Text.Json.Serialization;

namespace Inttegro;

public sealed class UploadRequestReviewReason
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("param")]
    public string? Param { get; set; }
}

public sealed class ReviewUploadRequestAttemptByIdRequest
{
    [JsonPropertyName("attempt_id")]
    public string? AttemptId { get; set; }

    [JsonPropertyName("decision")]
    public string? Decision { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("public_message")]
    public string? PublicMessage { get; set; }

    [JsonPropertyName("reasons")]
    public List<UploadRequestReviewReason>? Reasons { get; set; }
}

public sealed class ReviewUploadRequestAttemptByOrdinalRequest
{
    [JsonPropertyName("attempt_ordinal")]
    public long? AttemptOrdinal { get; set; }

    [JsonPropertyName("decision")]
    public string? Decision { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("public_message")]
    public string? PublicMessage { get; set; }

    [JsonPropertyName("reasons")]
    public List<UploadRequestReviewReason>? Reasons { get; set; }
}
