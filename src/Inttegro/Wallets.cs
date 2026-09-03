using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Inttegro.Wallets;

[JsonConverter(typeof(Inttegro.WireEnumJsonConverter<WalletType>))]
public enum WalletType
{
    [EnumMember(Value = "mobile_money")]
    MobileMoney
}

public sealed class WalletMobileMoney
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("account_number")]
    public string? AccountNumber { get; set; }

    [JsonPropertyName("network")]
    public string? Network { get; set; }
}

public sealed class WalletConfig
{
    [JsonPropertyName("type")]
    public WalletType Type { get; set; }

    [JsonPropertyName("mobile_money")]
    public WalletMobileMoney? MobileMoney { get; set; }
}
