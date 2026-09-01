# Inttegro .NET SDK

The official .NET client for building server-side Inttegro integrations.

> **Fastest, most modern path:** connect an agent to [Inttegro MCP](https://studio.inttegro.com/inttegro-mcp) at `https://mcp.inttegro.com`, then ask it to run `design_integration`. It will produce an implementation and test plan for your application. Use this SDK when you are ready to connect that plan to your .NET service.

All official Inttegro SDKs expose the same API capabilities. This package adds .NET-specific models, async APIs, and transport integration.

## Install

Targets .NET 8.

```bash
dotnet add package Inttegro
```

Store your secret key in the server environment:

```bash
export INTTEGRO_API_KEY="your_secret_key"
```

Never put the key in browser code, a mobile app, or source control. The client uses `https://api.inttegro.com` by default.

## Create a hosted checkout

Create and finalize an order, then send the customer to its hosted invoice URL:

```csharp
using Inttegro;
using Inttegro.Errors;
using Inttegro.Models;

var apiKey = Environment.GetEnvironmentVariable("INTTEGRO_API_KEY")
    ?? throw new InvalidOperationException("INTTEGRO_API_KEY is required");

using var inttegro = new InttegroClient(apiKey);

try
{
    var response = await inttegro.Orders.CreateAsync(new OrderCreateRequest
    {
        RequestMeta = new RequestMeta { IdempotencyKey = "checkout-cart-123" },
        CustomerData = new CustomerData
        {
            Name = "Akua Mensah",
            EmailAddress = "akua@example.com",
            PhoneNumber = "+233544998605"
        },
        Finalize = true,
        CheckoutSettings = new CheckoutSettings
        {
            RedirectUrl = "https://example.com/orders/complete",
            CancelUrl = "https://example.com/cart"
        },
        LineItems = new List<LineItem>
        {
            new()
            {
                Type = LineItemType.Product,
                Product = new ProductDetails
                {
                    Type = ProductType.Digital,
                    Name = "Monthly subscription",
                    Quantity = 1,
                    Price = new Money { Currency = "ghs", Value = 5000 }
                }
            }
        }
    });

    var created = response.Deserialize<OrderCreateResponse>();
    var checkoutUrl = created?.Order?.Invoice?.Format?.Web?.Url
        ?? throw new InvalidOperationException("Order did not include a checkout URL");
    Console.WriteLine($"{created.Order!.Id} {checkoutUrl}");
}
catch (InttegroApiException error)
{
    Console.Error.WriteLine($"{error.Code}: {error.Detail ?? error.Message}");
    throw;
}
```

Amounts use integer minor units: `5000` GHS is GHS 50.00. Reuse the same idempotency key when retrying the same logical write. If you omit one, the SDK generates a UUIDv7 key for mutating calls.

## Work with the API

The SDK covers orders and checkout, customers, products and prices, purchase intents, payment methods, balances, payouts and refunds, notifications, files, application settings, keys, and country specifications. Resources use .NET properties such as `PurchaseIntents` and `PaymentMethods`.

.NET-specific features:

- Nullable-aware typed request models and public enum constants.
- Async resource methods with `CancellationToken` support.
- `InttegroResponse` for flexible `JsonNode` access and `Deserialize<T>()` for typed responses.
- Injectable `HttpClient`, base URL, and timeout for connection reuse and tests.
- Structured authentication, rate-limit, network, timeout, and API exceptions.

See the [API reference](https://studio.inttegro.com/api-reference) for request fields and lifecycle rules, [errors](https://studio.inttegro.com/errors) for recovery guidance, and [idempotency](https://studio.inttegro.com/idempotency) for safe retries.

## Develop

```bash
dotnet build src/Inttegro/Inttegro.csproj
dotnet test tests/Inttegro.Tests/Inttegro.Tests.csproj
```
