using Inttegro;
using Xunit;

namespace Inttegro.Tests;

public sealed class ApiEnumsTests
{
    [Fact]
    public void ExposesExactWireValues()
    {
        Assert.Equal("digital", ApiEnums.ProductType.Digital);
        Assert.Equal("requested_by_customer", ApiEnums.RefundReason.RequestedByCustomer);
        Assert.Equal("pending", ApiEnums.UploadRequestStatus.Pending);
    }
}
