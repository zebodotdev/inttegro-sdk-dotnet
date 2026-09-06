using System.Text.Json.Serialization;

namespace Inttegro.Diagnostics;

public enum ErrorReportingPolicy
{
    Unexpected,
    All
}

public sealed record SdkReportContext(
    [property: JsonPropertyName("language")] string Language,
    [property: JsonPropertyName("version")] string Version
);

public sealed record HttpReportContext(
    [property: JsonPropertyName("method")] string Method,
    [property: JsonPropertyName("route")] string? Route,
    [property: JsonPropertyName("serverAddress")] string ServerAddress,
    [property: JsonPropertyName("statusCode")] int? StatusCode,
    [property: JsonPropertyName("requestId")] string? RequestId,
    [property: JsonPropertyName("durationMs")] long DurationMs
);

public sealed record ApiErrorReportContext(
    [property: JsonPropertyName("type")] string? Type,
    [property: JsonPropertyName("code")] string? Code,
    [property: JsonPropertyName("fixCode")] string? FixCode
);

public sealed record TraceReportContext(
    [property: JsonPropertyName("traceId")] string TraceId,
    [property: JsonPropertyName("spanId")] string SpanId
);

/// <summary>A privacy-safe description of a failed Inttegro SDK operation.</summary>
public sealed record ErrorReport(
    [property: JsonPropertyName("schemaVersion")] int SchemaVersion,
    [property: JsonPropertyName("eventId")] string EventId,
    [property: JsonPropertyName("occurredAt")] DateTimeOffset OccurredAt,
    [property: JsonPropertyName("severity")] string Severity,
    [property: JsonPropertyName("category")] string Category,
    [property: JsonPropertyName("operation")] string Operation,
    [property: JsonPropertyName("sdk")] SdkReportContext Sdk,
    [property: JsonPropertyName("http")] HttpReportContext Http,
    [property: JsonPropertyName("apiError")] ApiErrorReportContext? ApiError,
    [property: JsonPropertyName("trace")] TraceReportContext? Trace,
    [property: JsonPropertyName("exceptionType")] string ExceptionType,
    [property: JsonPropertyName("fingerprint")] string Fingerprint
);

/// <summary>Receives one report after a logical SDK operation finally fails.</summary>
public delegate void ErrorReporter(ErrorReport report);
