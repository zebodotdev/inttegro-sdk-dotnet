using System.Text.Json;
using System.Text.Json.Nodes;

namespace Inttegro.Http;

/// <summary>Internal representation of the API's JSON transport envelope.</summary>
internal sealed class WireEnvelope
{
    internal JsonNode? Data { get; }
    internal int StatusCode { get; }
    internal IReadOnlyDictionary<string, string> Headers { get; }
    internal IReadOnlyDictionary<string, object?>? Meta { get; }

    internal WireEnvelope(
        JsonNode? data,
        int statusCode = 0,
        IReadOnlyDictionary<string, string>? headers = null,
        IReadOnlyDictionary<string, object?>? meta = null
    )
    {
        Data = data;
        StatusCode = statusCode;
        Headers = headers ?? new Dictionary<string, string>();
        Meta = meta;
    }

    internal JsonNode? this[string key] => Data?[key];

    internal T? Deserialize<T>() => Data == null ? default : Data.Deserialize<T>();

    internal Inttegro.InttegroResponse<T> ToResponse<T>(T data) =>
        new(data, StatusCode, Headers, Meta);
}
