using System.Text.Json.Nodes;

namespace Commerce.Errors;

public class CommerceException : Exception
{
    public CommerceException(string message) : base(message) { }
}

public class CommerceNetworkException : CommerceException
{
    public Exception? OriginalError { get; }

    public CommerceNetworkException(string message, Exception? original = null)
        : base(message)
    {
        OriginalError = original;
    }
}

public class CommerceTimeoutException : CommerceNetworkException
{
    public CommerceTimeoutException(string message, Exception? original = null)
        : base(message, original) { }
}

public class CommerceApiException : CommerceException
{
    public int StatusCode { get; }
    public string? Code { get; }
    public string? Type { get; }
    public string? Url { get; }
    public string? Detail { get; }
    public string? FixCode { get; }
    public string? Cause { get; }
    public string? Body { get; }
    public JsonNode? Data { get; }

    public CommerceApiException(
        string message,
        int statusCode,
        string? code = null,
        string? type = null,
        string? url = null,
        string? detail = null,
        string? fixCode = null,
        string? cause = null,
        string? body = null,
        JsonNode? data = null
    )
        : base(message)
    {
        StatusCode = statusCode;
        Code = code;
        Type = type;
        Url = url;
        Detail = detail;
        FixCode = fixCode;
        Cause = cause;
        Body = body;
        Data = data;
    }
}

public class CommerceAuthenticationException : CommerceApiException
{
    public CommerceAuthenticationException(
        string message,
        int statusCode,
        string? code = null,
        string? type = null,
        string? url = null,
        string? detail = null,
        string? fixCode = null,
        string? cause = null,
        string? body = null,
        JsonNode? data = null
    )
        : base(message, statusCode, code, type, url, detail, fixCode, cause, body, data) { }
}

public class CommerceRateLimitException : CommerceApiException
{
    public int? RetryAfterSeconds { get; }

    public CommerceRateLimitException(
        string message,
        int statusCode,
        string? code = null,
        string? type = null,
        string? url = null,
        string? detail = null,
        string? fixCode = null,
        string? cause = null,
        string? body = null,
        JsonNode? data = null,
        int? retryAfterSeconds = null
    )
        : base(message, statusCode, code, type, url, detail, fixCode, cause, body, data)
    {
        RetryAfterSeconds = retryAfterSeconds;
    }
}
