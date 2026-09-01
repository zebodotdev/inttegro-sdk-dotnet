using System.Text.Json;
using System.Text.Json.Nodes;

namespace Inttegro.Responses;

public class InttegroResponse
{
    public JsonNode? Data { get; }

    public InttegroResponse(JsonNode? data)
    {
        Data = data;
    }

    public JsonNode? this[string key] => Data?[key];

    public T? Deserialize<T>()
    {
        return Data == null ? default : Data.Deserialize<T>();
    }
}
