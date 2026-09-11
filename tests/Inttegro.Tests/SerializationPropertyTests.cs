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

    [Fact]
    public void CountrySpecificationsDecodeThePublishedContractShape()
    {
        const string json = """
            {
              "gh": {
                "country_code": "gh",
                "legal_entity_types": ["company"],
                "financial_account_types": ["bank_account"],
                "id_document_types": ["passport"],
                "banks": {
                  "bank_account_type": "ghana_bank_account",
                  "code_scheme": "sort_code",
                  "items": [{
                    "id": "bank_1",
                    "name": "Example Bank",
                    "branches": [{
                      "id": "branch_1",
                      "name": "Accra",
                      "sort_code": "100100"
                    }]
                  }]
                }
              }
            }
            """;

        var specifications = JsonSerializer.Deserialize<CountrySpecifications>(json);

        var ghana = Assert.IsType<CountrySpecification>(specifications?["gh"]);
        Assert.Equal(new[] { "company" }, ghana.LegalEntityTypes);
        Assert.Equal(new[] { "bank_account" }, ghana.FinancialAccountTypes);
        Assert.Equal(new[] { "passport" }, ghana.IdDocumentTypes);
        Assert.Equal("sort_code", ghana.Banks?.CodeScheme);
        Assert.Equal("100100", ghana.Banks?.Items?[0].Branches?[0].SortCode);
    }
}
