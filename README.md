# Zebo Commerce .NET SDK

Lightweight .NET client for the Zebo Commerce API (orders, payment methods, payouts, OTP, chimes, balance transactions, financial accounts, platform apps/keys/sessions, and specs). Targets .NET 8 and uses only the base class library.

## Installation

From `sdks/dotnet/src/Commerce`:

```bash
dotnet build
```

Once published:

```bash
dotnet add package Zebo.Commerce
```

## Quick start

```csharp
using Commerce;

var client = new CommerceClient(apiKey: Environment.GetEnvironmentVariable("COMMERCE_API_KEY"));

var order = await client.Orders.CreateAsync(new
{
    customer_data = new { name = "Akua Mensah", phone_number = "+233544998605" },
    payout_settings = new
    {
        destination = new { financial_account_id = "fa_1234567890abcdef" },
        enable_fx = false
    },
    payment_method_data = new
    {
        type = "mobile_money",
        mobile_money = new { issuer = "mtn", number = "0544998605" }
    },
    line_items = new[]
    {
        new
        {
            type = "product",
            product = new
            {
                name = "Monthly Subscription",
                price = new { currency = "ghs", value = 5000 },
                quantity = 1
            }
        }
    }
});

Console.WriteLine(order["order"]?["id"]);
```

Responses are wrapped `CommerceResponse` objects backed by `JsonNode`; access via `response["order"]?["id"]` or deserialize with `response.Deserialize<T>()`.

## Chimes, schedules, broadcasts

```csharp
// Schedule a chime
var scheduled = await client.Chimes.ScheduleAsync(new
{
    recipients = new[] { "+233544998605", "user@example.com" },
    full_message = "Hello! This is your scheduled reminder.",
    send_after = "2026-01-18T10:00:00Z",
    sender_id = "YourBrand"
});

// Broadcast a chime
var broadcast = await client.Chimes.BroadcastAsync(new
{
    recipients = new[] { "+233544998605", "user@example.com" },
    message_template = "Hello! Check out our new product launch.",
    service_name = "MarketingCampaign",
    sender = "YourBrand"
});

// Lookup/cancel schedules and broadcasts
var scheduleInfo = await client.Schedules.LookupAsync("sch_abc123def456ghi789");
var canceledSchedule = await client.Schedules.CancelAsync("sch_abc123def456ghi789");
var broadcastInfo = await client.Broadcasts.LookupAsync("brc_abc123def456ghi789");
var canceledBroadcast = await client.Broadcasts.CancelAsync("brc_abc123def456ghi789");
```

## Typed models

```csharp
using Commerce.Models;
using System.Text.Json.Nodes;

var account = await client.FinancialAccounts.ConnectAsync(new FinancialAccountCreateRequest
{
    Label = "Primary GHS Bank Account",
    Type = FinancialAccountType.BankAccount,
    Reference = "BANK-GHS-001",
    Currency = "ghs",
    CustomData = new Dictionary<string, string>
    {
        ["merchant_id"] = "merch_123"
    },
    PullConfiguration = new PullPushConfig
    {
        Enabled = true,
        Mandate = new JsonObject()
    },
    Owner = new BankAccountOwner
    {
        Name = "Jane Smith",
        Address = new BankAccountOwnerAddress
        {
            Name = "Business Address",
            Line1 = "456 Business Road",
            City = "Accra",
            Region = "Greater Accra",
            Country = "Ghana"
        }
    },
    BankAccount = new BankAccountConfig
    {
        Type = BankAccountType.GhanaBankAccount,
        GhanaBankAccount = new GhanaBankAccount
        {
            Number = "1234567890",
            SortCode = "040127",
            Holder = new BankAccountOwner
            {
                Name = "John Doe",
                Address = new BankAccountOwnerAddress
                {
                    Name = "Home Address",
                    Line1 = "123 Main Street",
                    City = "Accra",
                    Region = "Greater Accra",
                    Country = "Ghana"
                }
            }
        }
    },
    PushConfiguration = new PullPushConfig { Enabled = true }
});

var typed = account.Deserialize<FinancialAccountResponse>();
Console.WriteLine(typed?.Account?.Id);

await client.FinancialAccounts.DisablePushAsync(new FinancialAccountToggleRequest
{
    AccountId = "fa_1234567890abcdef",
    UnsetAsPayoutDestination = true
});

await client.FinancialAccounts.DisconnectAsync(new FinancialAccountToggleRequest
{
    AccountId = "fa_1234567890abcdef",
    UnsetAsPayoutDestination = true
});

await client.FinancialAccounts.PageAsync(new FinancialAccountPageRequest
{
    PageNumber = 1,
    PageSize = 50
});
```

Typed request overloads validate required fields and throw `ArgumentException` when missing.

```csharp
var order = await client.Orders.CreateAsync(new OrderCreateRequest
{
    CustomerData = new CustomerData
    {
        Name = "Akua Mensah",
        EmailAddress = "akua@example.com",
        PhoneNumber = "+233544998605"
    },
    LineItems = new List<LineItem>
    {
        new LineItem
        {
            Type = LineItemType.Product,
            Product = new ProductDetails
            {
                Name = "Monthly Subscription",
                Type = ProductType.Digital,
                Quantity = 1,
                Price = new Money { Currency = "ghs", Value = 5000 }
            }
        }
    }
});

var created = order.Deserialize<OrderCreateResponse>();
Console.WriteLine(created?.Order?.Id);
```

## Customers

```csharp
var customer = await client.Customers.CreateAsync(new CreateCustomerRequest
{
    Name = "Jane Doe",
    EmailAddress = "jane@example.com",
    PhoneNumber = "+233501234567"
});

var existing = await client.Customers.LookupAsync("cu_1234567890abcdef");
var page = await client.Customers.PageAsync(new PageCustomersRequest { PageNumber = 1, PageSize = 50 });
```

## Products

```csharp
var product = await client.Products.CreateAsync(new CreateProductRequest
{
    Type = ProductType.Physical,
    Name = "Premium Cotton T-Shirt"
});

await client.Products.AddPriceAsync(new AddProductPriceRequest
{
    ProductId = product["product"]?["id"]?.GetValue<string>(),
    Amount = new ProductPriceAmount { Currency = "ghs", Value = 5000 },
    SetAsDefault = true
});

await client.Products.PageAsync(new PageProductsRequest { PageNumber = 1, PageSize = 50 });

await client.Products.PublishAsync(new ProductActionRequest
{
    ProductId = product["product"]?["id"]?.GetValue<string>()
});
```

## Prices

```csharp
var price = await client.Prices.CreateAsync(new CreatePriceRequest
{
    Currency = "USD",
    Amount = 1999,
    Label = "Standard pricing"
});

await client.Prices.UpdateAsync(new UpdatePriceRequest
{
    PriceId = price["price"]?["id"]?.GetValue<string>(),
    Label = "Premium pricing"
});
```

## Examples

### Hosted checkout

```csharp
var checkout = await client.Orders.NewAsync(new
{
    finalize = true,
    customer_data = new { name = "Jane Doe" },
    payout_settings = new
    {
        destination = new { financial_account_id = "fa_1234567890abcdef" },
        enable_fx = false
    },
    line_items = new[]
    {
        new { type = "product", product = new { name = "Subscription", quantity = 1, price = new { currency = "ghs", value = 5000 } } }
    }
});

var url = checkout["order"]?["invoice"]?["format"]?["web"]?["url"]?.GetValue<string>();
```

### Handle errors

```csharp
using Commerce.Errors;

try
{
    await client.Orders.LookupAsync("or_missing");
}
catch (CommerceAuthenticationException ex)
{
    Console.WriteLine($"Check API key: {ex.Message}");
}
catch (CommerceRateLimitException ex)
{
    Console.WriteLine($"Retry after {ex.RetryAfterSeconds}s");
}
catch (CommerceApiException ex)
{
    Console.WriteLine($"API error {ex.StatusCode}: {ex.Message}");
}
```

### OTP flows with lookup/cancel

```csharp
var txn = await client.Otp.InitiateAsync(new
{
    recipient = "+233241234567",
    idempotency_key = $"otp_login_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}",
    sender = "Acme",
    service_name = "Acme Bank",
    purpose = "login"
});

await client.Otp.VerifyAsync(new { transaction_id = txn["transaction_id"], recipient = "+233241234567", token = "123456" });
await client.Otp.LookupAsync(new { transaction_id = txn["transaction_id"] });
await client.Otp.CancelAsync(new { transaction_id = txn["transaction_id"], reason = "user_requested_new_code" });
```

### Platform: apps, keys, sessions

```csharp
var app = await client.Platform.CreateAppAsync(new { name = "My App" });
var key = await client.Platform.GenerateKeyAsync(new { app_id = app["app"]?["id"] });
var session = await client.Platform.NewSessionAsync(new { app_id = app["app"]?["id"] });
```

## Available resources

- `client.Orders.CreateAsync|NewAsync|LookupAsync|PayAsync|ConfirmPaymentAsync|RequestConfirmationAsync|FinalizeAsync|CompleteAsync|CancelAsync|RefundAsync|PageAsync`
- `client.PaymentMethods.TokenizeAsync|VerifyAsync|ConfirmVerificationAsync|LookupAsync|DeleteAsync|SettingsAsync`
- `client.Payouts.SetDestinationsAsync|SettingsAsync|DisableAutomaticAsync|EnableFXAsync|DisableFXAsync|PageAsync|CancelAsync`
- `client.BalanceTransactions.PageAsync`
- `client.FinancialAccounts.CreateAsync|LookupAsync|ConnectAsync|ArchiveAsync|PageAsync|VerifyAsync|UpdateAsync|EnablePushAsync|DisablePushAsync|EnablePullAsync|DisablePullAsync|DisconnectAsync`
- `client.Customers.CreateAsync|LookupAsync|PageAsync`
- `client.Products.CreateAsync|AddPriceAsync|SetDefaultUnitPriceAsync|LookupAsync|UpdateAsync|PublishAsync|UnpublishAsync|ArchiveAsync|PageAsync`
- `client.Prices.CreateAsync|LookupAsync|UpdateAsync`
- `client.Chimes.SendAsync|LookupAsync|ScheduleAsync`
- `client.Otp.InitiateAsync|VerifyAsync|LookupAsync|CancelAsync`
- `client.Balances.GetAsync`
- `client.Platform.CreateAppAsync|GenerateKeyAsync|NewSessionAsync`
- `client.Spec.CountriesAsync`

## Development

From `sdks/dotnet`:

```bash
dotnet build src/Commerce/Commerce.csproj
dotnet test tests/Commerce.Tests/Commerce.Tests.csproj
```

CI/release/security workflows live in `sdks/dotnet/.github`.
