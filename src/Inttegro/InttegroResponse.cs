namespace Inttegro;

/// <summary>Decoded SDK value plus response-only HTTP metadata.</summary>
public sealed class InttegroResponse<T>
{
    public InttegroResponse(
        T data,
        int statusCode,
        IReadOnlyDictionary<string, string> headers,
        IReadOnlyDictionary<string, object?>? meta = null
    )
    {
        Data = data;
        StatusCode = statusCode;
        Headers = headers;
        Meta = meta;
        RequestId = Header(headers, "x-request-id");
        RetryAfter = Header(headers, "retry-after");
    }

    public T Data { get; }
    public int StatusCode { get; }
    public IReadOnlyDictionary<string, string> Headers { get; }
    public IReadOnlyDictionary<string, object?>? Meta { get; }
    public string? RequestId { get; }
    public string? RetryAfter { get; }

    private static string? Header(IReadOnlyDictionary<string, string> headers, string name)
    {
        foreach (var item in headers)
        {
            if (string.Equals(item.Key, name, StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrWhiteSpace(item.Value))
            {
                return item.Value;
            }
        }

        return null;
    }
}
