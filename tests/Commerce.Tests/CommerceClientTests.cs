using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Commerce;
using Commerce.Errors;
using Commerce.Models;
using System.Linq;
using Xunit;

namespace Commerce.Tests;

public class CommerceClientTests
{
    private static readonly Regex UuidV7Regex = new("^[0-9a-f]{8}-[0-9a-f]{4}-7[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$", RegexOptions.IgnoreCase);

    [Fact]
    public async Task CallsAllEndpointsWithExpectedPaths()
    {
        var handler = new RecordingHandler();
        var httpClient = new HttpClient(handler) { BaseAddress = new Uri("https://api.zebo.dev") };
        var client = new CommerceClient("test", httpClient: httpClient);

        await client.Orders.CreateAsync(new { number = "1" });
        await client.Orders.NewAsync(new { number = "2" });
        await client.Orders.LookupAsync("or_1");
        await client.Orders.PayAsync(new { order_id = "or_1" });
        await client.Orders.ConfirmPaymentAsync(new { order_id = "or_1", token = "123456" });
        await client.Orders.RequestConfirmationAsync("or_1");
        await client.Orders.FinalizeAsync("or_1");
        await client.Orders.SendInvoiceAsync(new OrderSendInvoiceParams { OrderId = "or_1" });
        await client.Orders.SendReceiptAsync(new OrderSendReceiptParams { OrderId = "or_1" });
        await client.Orders.CompleteAsync(new { order_id = "or_1" });
        await client.Orders.CancelAsync("or_1");
        await client.Orders.RefundAsync("or_1");
        await client.Orders.PageAsync(new { });

        await client.PaymentMethods.TokenizeAsync(new
        {
            customer_id = "cu_1",
            payment_method_data = new
            {
                type = "mobile_money",
                mobile_money = new
                {
                    network = "mtn",
                    account_number = "0544998605"
                }
            }
        });
        await client.PaymentMethods.VerifyAsync("pm_1");
        await client.PaymentMethods.ConfirmVerificationAsync(new { payment_method_id = "pm_1", token = "123456" });
        await client.PaymentMethods.LookupAsync("pm_1");
        await client.PaymentMethods.DeleteAsync("pm_1");
        await client.PaymentMethods.SettingsAsync();

        await client.Payouts.SetDestinationsAsync(new { ghs = "dest" });
        await client.Payouts.SettingsAsync();
        await client.Payouts.DisableAutomaticAsync();
        await client.Payouts.EnableFXAsync();
        await client.Payouts.DisableFXAsync();
        await client.Payouts.PageAsync(new { });
        await client.Payouts.CancelAsync("po_1");

        await client.BalanceTransactions.PageAsync(new { });

        await client.FinancialAccounts.CreateAsync(new { });
        await client.FinancialAccounts.LookupAsync("fa_1");
        await client.FinancialAccounts.ConnectAsync(new { });
        await client.FinancialAccounts.ArchiveAsync(new { account_id = "fa_1" });
        await client.FinancialAccounts.PageAsync(new { });
        await client.FinancialAccounts.VerifyAsync(new { account_id = "fa_1" });
        await client.FinancialAccounts.EnablePushAsync(new FinancialAccountToggleRequest { AccountId = "fa_1" });
        await client.FinancialAccounts.DisablePushAsync(new FinancialAccountToggleRequest
        {
            AccountId = "fa_1",
            UnsetAsPayoutDestination = true
        });
        await client.FinancialAccounts.EnablePullAsync(new FinancialAccountToggleRequest { AccountId = "fa_1" });
        await client.FinancialAccounts.DisablePullAsync(new FinancialAccountToggleRequest { AccountId = "fa_1" });
        await client.FinancialAccounts.DisconnectAsync(new FinancialAccountToggleRequest
        {
            AccountId = "fa_1",
            UnsetAsPayoutDestination = true
        });

        await client.Customers.CreateAsync(new { name = "Jane Doe" });
        await client.Customers.LookupAsync("cu_1");
        await client.Customers.PageAsync(new { page_number = 1 });

        await client.Products.CreateAsync(new
        {
            type = "physical",
            name = "Product"
        });
        await client.Products.AddPriceAsync(new
        {
            product_id = "prod_1",
            amount = new { currency = "ghs", value = 5000 },
            set_as_default = true
        });
        await client.Products.SetDefaultUnitPriceAsync(new { product_id = "prod_1", price_id = "pr_1" });
        await client.Products.LookupAsync("prod_1");
        await client.Products.UpdateAsync(new { product_id = "prod_1", name = "Updated" });
        await client.Products.PublishAsync(new { product_id = "prod_1" });
        await client.Products.UnpublishAsync(new { product_id = "prod_1" });
        await client.Products.ArchiveAsync(new { product_id = "prod_1" });
        await client.Products.PageAsync(new { page_number = 1 });

        await client.Chimes.SendAsync(new { message = "hi" });
        await client.Chimes.LookupAsync("ch_1");
        await client.Chimes.ScheduleAsync(new { recipients = new[] { "+233544998605" }, full_message = "later", send_after = "2026-01-18T10:00:00Z" });
        await client.Chimes.BroadcastAsync(new { recipients = new[] { "+233544998605" }, message_template = "hello", service_name = "marketing" });

        await client.Schedules.LookupAsync("sch_1");
        await client.Schedules.CancelAsync("sch_1");
        await client.Broadcasts.LookupAsync("brc_1");
        await client.Broadcasts.CancelAsync("brc_1");

        await client.Otp.InitiateAsync(new
        {
            recipient = "+233",
            sender = "Acme",
            service_name = "Acme Bank",
            idempotency_key = "otp_login_1700000000"
        });
        await client.Otp.VerifyAsync(new { transaction_id = "txn_1", recipient = "+233", token = "123456" });
        await client.Otp.LookupAsync(new { transaction_id = "txn_1" });
        await client.Otp.CancelAsync(new { transaction_id = "txn_1", reason = "test" });

        await client.Apps.CreateAsync(new { name = "My App" });
        await client.Apps.LookupAsync();
        await client.Apps.UpdateAsync(new { alias = "my-app" });

        await client.Spec.CountriesAsync();
        await client.Balances.GetAsync();

        var expectedPaths = new[]
        {
            "/orders/new",
            "/orders/new",
            "/orders/lookup",
            "/orders/pay",
            "/orders/confirm_payment",
            "/orders/request_confirmation",
            "/orders/finalize",
            "/orders/send_invoice",
            "/orders/send_receipt",
            "/orders/complete",
            "/orders/cancel",
            "/orders/refund",
            "/orders/page",
            "/payment_methods/tokenize",
            "/payment_methods/verify",
            "/payment_methods/confirm_verification",
            "/payment_methods/lookup",
            "/payment_methods/delete",
            "/payment_methods/settings",
            "/payouts/set_destinations",
            "/payouts/settings",
            "/payouts/disable",
            "/payouts/enable_fx",
            "/payouts/disable_fx",
            "/payouts/page",
            "/payouts/cancel",
            "/balance_transactions/page",
            "/financial_accounts/create",
            "/financial_accounts/lookup",
            "/financial_accounts/connect",
            "/financial_accounts/archive",
            "/financial_accounts/page",
            "/financial_accounts/verify",
            "/financial_accounts/enable_push",
            "/financial_accounts/disable_push",
            "/financial_accounts/enable_pull",
            "/financial_accounts/disable_pull",
            "/financial_accounts/disconnect",
            "/customers/create",
            "/customers/lookup",
            "/customers/page",
            "/products/create",
            "/products/add_price",
            "/products/set_default_unit_price",
            "/products/lookup",
            "/products/update",
            "/products/publish",
            "/products/unpublish",
            "/products/archive",
            "/products/page",
            "/chimes/send",
            "/chimes/lookup",
            "/chimes/schedule",
            "/chimes/broadcast",
            "/schedules/lookup",
            "/schedules/cancel",
            "/broadcasts/lookup",
            "/broadcasts/cancel",
            "/otp/initiate",
            "/otp/verify",
            "/otp/lookup",
            "/otp/cancel",
            "/apps/create",
            "/apps/lookup",
            "/apps/update",
            "/spec/countries",
            "/balances"
        };

        Assert.Equal(expectedPaths, handler.Requests.Select(r => r.RequestUri!.AbsolutePath).ToArray());

        // Response wrapping
        handler.ResponseBody = JsonSerializer.Serialize(new { order = new { id = "or_123" } });
        var resp = await client.Orders.CreateAsync(new { number = "3" });
        Assert.Equal("or_123", resp["order"]?["id"]?.GetValue<string>());
    }

    [Fact]
    public async Task RaisesAuthenticationErrors()
    {
        var handler = new RecordingHandler
        {
            StatusCode = HttpStatusCode.Unauthorized,
            ResponseBody =
                "{\"type\":\"authentication_error\",\"code\":\"invalid_api_key\",\"url\":\"https://commerce.zebo.dev/e/invalid_api_key\",\"message\":\"invalid key\",\"detail\":\"API key is missing or invalid.\",\"fix_code\":\"check_api_key\",\"cause\":\"authentication_failure\"}"
        };
        var httpClient = new HttpClient(handler) { BaseAddress = new Uri("https://api.zebo.dev") };
        var client = new CommerceClient("bad", httpClient: httpClient);

        await Assert.ThrowsAsync<CommerceAuthenticationException>(() => client.Orders.LookupAsync("or_1"));
    }

    [Fact]
    public async Task MutatingPostsGenerateRequestMetaIdempotencyKey()
    {
        var handler = new RecordingHandler();
        var httpClient = new HttpClient(handler) { BaseAddress = new Uri("https://api.zebo.dev") };
        var client = new CommerceClient("test", httpClient: httpClient);

        await client.Orders.CreateAsync(new { number = "ORDER-1", idempotency_key = "legacy" });

        using var document = JsonDocument.Parse(handler.Bodies.Single());
        var root = document.RootElement;
        Assert.False(root.TryGetProperty("idempotency_key", out _));
        var key = root.GetProperty("request_meta").GetProperty("idempotency_key").GetString();
        Assert.Matches(UuidV7Regex, key!);
    }

    [Fact]
    public async Task MessageTemplatesCreateUsesRequestMetaIdempotencyByDefault()
    {
        var handler = new RecordingHandler();
        var httpClient = new HttpClient(handler) { BaseAddress = new Uri("https://api.zebo.dev") };
        var client = new CommerceClient("test", httpClient: httpClient);

        await client.MessageTemplates.CreateAsync(new
        {
            name = "welcome_sms",
            channel = "sms",
            purpose = "marketing",
            sms = new { message_template = "Welcome {{name}}" }
        });

        var request = Assert.Single(handler.Requests);
        Assert.False(request.Headers.Contains("Idempotency-Key"));
        using var document = JsonDocument.Parse(handler.Bodies.Single());
        var key = document.RootElement.GetProperty("request_meta").GetProperty("idempotency_key").GetString();
        Assert.Matches(UuidV7Regex, key!);
    }

    private class RecordingHandler : HttpMessageHandler
    {
        public List<HttpRequestMessage> Requests { get; } = new();
        public List<string> Bodies { get; } = new();
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public string ResponseBody { get; set; } = "{\"ok\":true}";

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Requests.Add(request);
            Bodies.Add(request.Content == null ? "" : await request.Content.ReadAsStringAsync(cancellationToken));
            var response = new HttpResponseMessage(StatusCode)
            {
                Content = new StringContent(ResponseBody, Encoding.UTF8, "application/json")
            };
            response.Headers.Date = DateTimeOffset.UtcNow;
            return response;
        }
    }
}
