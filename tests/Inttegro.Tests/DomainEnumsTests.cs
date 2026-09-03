using Inttegro;
using System.Text.Json;
using Xunit;

namespace Inttegro.Tests;

public sealed class DomainEnumsTests
{
    [Fact]
    public void SerializesExactWireValues()
    {
        Assert.Equal("\"digital\"", JsonSerializer.Serialize(ProductType.Digital));
        Assert.Equal("\"requested_by_customer\"", JsonSerializer.Serialize(RefundReason.RequestedByCustomer));
        Assert.Equal("\"pending\"", JsonSerializer.Serialize(UploadRequestStatus.Pending));
    }
}
