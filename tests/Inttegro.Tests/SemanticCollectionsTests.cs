using System.Text.Json;
using Xunit;

namespace Inttegro.Tests;

public sealed class SemanticCollectionsTests
{
    [Fact]
    public void CustomDataControlsMutationAndRollsBackInvalidChanges()
    {
        var data = new CustomData().Set("order", "first");

        Assert.Throws<ArgumentException>(() => data.Set(new string('x', 257), "invalid"));
        Assert.Equal("first", data["order"]);
        Assert.Single(data);
        Assert.Equal("{\"order\":\"first\"}", JsonSerializer.Serialize(data));
    }

    [Fact]
    public void CustomDataPatchDistinguishesSetFromUnset()
    {
        var patch = new CustomDataPatch()
            .Set("campaign", "winter")
            .Unset("legacy");

        Assert.Equal(
            "{\"campaign\":\"winter\",\"legacy\":null}",
            JsonSerializer.Serialize(patch));
    }

    [Fact]
    public void SemanticCollectionsRoundTripWithoutExposingMutableDictionaries()
    {
        var metadata = new FileMetadata().Set("source", "invoice");
        var destinations = new PayoutDestinations().Set("GHS", "fa_example");

        var decodedMetadata = JsonSerializer.Deserialize<FileMetadata>(JsonSerializer.Serialize(metadata));
        var decodedDestinations = JsonSerializer.Deserialize<PayoutDestinations>(JsonSerializer.Serialize(destinations));

        Assert.Equal("invoice", decodedMetadata!["source"]);
        Assert.Equal("fa_example", decodedDestinations!["GHS"]);
        Assert.IsAssignableFrom<IReadOnlyDictionary<string, string>>(decodedMetadata);
    }

    [Fact]
    public void StructuredInputAndCustomerBalanceKeepTheirDomainTypes()
    {
        var input = new CustomDataInput()
            .Set("campaign", "launch")
            .Set("attribution", new { channel = "partner" });
        var customer = JsonSerializer.Deserialize<Customer>(
            """
            {
              "id":"cu_example",
              "name":"Ada",
              "created_at":"2026-01-01T00:00:00Z",
              "guest":false,
              "balance":{"ghs":{"as_of":"2026-01-01T00:00:00Z","available":{"currency":"ghs","value":2500}}}
            }
            """);

        Assert.Equal("partner", input.Get<Dictionary<string, string>>("attribution")!["channel"]);
        Assert.Equal(2500, customer!.Balance!["ghs"].Available!.Value);
    }
}
