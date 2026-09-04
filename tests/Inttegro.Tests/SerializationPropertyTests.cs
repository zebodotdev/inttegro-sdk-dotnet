using System.Text.Json;
using FsCheck.Xunit;
using Inttegro.Money;
using Xunit;

namespace Inttegro.Tests;

public sealed class SerializationPropertyTests
{
    [Property(MaxTest = 200)]
    public void AmountsRoundTripWithoutChangingMinorUnits(int value)
    {
        var amount = new AmountParams { Currency = Currency.GHS, Value = value };

        var decoded = JsonSerializer.Deserialize<AmountParams>(JsonSerializer.Serialize(amount));

        Assert.NotNull(decoded);
        Assert.Equal(Currency.GHS, decoded.Currency);
        Assert.Equal(value, decoded.Value);
    }
}
