using System.Text.Json;
using System.Text.Json.Nodes;

namespace Commerce.Responses;

public class CommerceResponse
{
    public JsonNode? Data { get; }

    public CommerceResponse(JsonNode? data)
    {
        Data = data;
    }

    public JsonNode? this[string key] => Data?[key];

    public T? Deserialize<T>()
    {
        return Data == null ? default : Data.Deserialize<T>();
    }
}
