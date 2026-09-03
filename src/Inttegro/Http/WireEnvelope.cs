using System.Text.Json;
using System.Text.Json.Nodes;

namespace Inttegro.Http;

/// <summary>Internal representation of the API's JSON transport envelope.</summary>
internal sealed class WireEnvelope
{
    internal JsonNode? Data { get; }

    internal WireEnvelope(JsonNode? data) => Data = data;

    internal JsonNode? this[string key] => Data?[key];

    internal T? Deserialize<T>() => Data == null ? default : Data.Deserialize<T>();
}
