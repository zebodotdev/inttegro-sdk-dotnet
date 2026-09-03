using System.Text.Json;
using System.Text.Json.Serialization;

namespace Inttegro.Money;

[JsonConverter(typeof(CurrencyJsonConverter))]
public readonly record struct Currency(string Value)
{
    public static readonly Currency GHS = new("ghs");
    public static readonly Currency USD = new("usd");
    public static readonly Currency GBP = new("gbp");
    public static readonly Currency EUR = new("eur");
    public static readonly Currency CNY = new("cny");

    public override string ToString() => Value;
}

public sealed class CurrencyJsonConverter : JsonConverter<Currency>
{
    public override Currency Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        new((reader.GetString() ?? throw new JsonException("Currency must be a string.")).ToLowerInvariant());

    public override void Write(Utf8JsonWriter writer, Currency value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.Value);
}

public class AmountParams
{
    [JsonPropertyName("currency")]
    public Currency Currency { get; set; }

    [JsonPropertyName("value")]
    public long Value { get; set; }
}

public class Amount
{
    [JsonPropertyName("currency")]
    public Currency Currency { get; set; }

    [JsonPropertyName("value")]
    public long Value { get; set; }
}
