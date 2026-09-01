using System.Text.Json.Nodes;

namespace Inttegro.Errors;

public class InttegroException : Exception
{
    public InttegroException(string message) : base(message) { }
}

public class InttegroNetworkException : InttegroException
{
    public Exception? OriginalError { get; }

    public InttegroNetworkException(string message, Exception? original = null)
        : base(message)
    {
        OriginalError = original;
    }
}

public class InttegroTimeoutException : InttegroNetworkException
{
    public InttegroTimeoutException(string message, Exception? original = null)
        : base(message, original) { }
}

public class InttegroApiException : InttegroException
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

    public InttegroApiException(
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

public class InttegroAuthenticationException : InttegroApiException
{
    public InttegroAuthenticationException(
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

public class InttegroRateLimitException : InttegroApiException
{
    public int? RetryAfterSeconds { get; }

    public InttegroRateLimitException(
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
