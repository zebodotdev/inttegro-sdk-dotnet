using Commerce.Http;
using Commerce.Models;
using Commerce.Responses;
using Commerce.Validation;

namespace Commerce.Resources;

public class FinancialAccountsResource
{
    private readonly ApiClient _client;

    internal FinancialAccountsResource(ApiClient client) => _client = client;

    public Task<CommerceResponse> CreateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/financial_accounts/create", payload, cancellationToken);

    public Task<CommerceResponse> CreateAsync(FinancialAccountCreateRequest payload, CancellationToken cancellationToken = default) =>
        CreateAsync(payload, validateOwner: true, cancellationToken);

    private Task<CommerceResponse> CreateAsync(FinancialAccountCreateRequest payload, bool validateOwner, CancellationToken cancellationToken)
    {
        if (validateOwner)
        {
            RequestValidator.Require(payload.Owner, "owner");
        }
        return _client.PostAsync("/financial_accounts/create", payload, cancellationToken);
    }

    public Task<CommerceResponse> LookupAsync(string accountId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/financial_accounts/lookup", new { account_id = accountId }, cancellationToken);

    public Task<CommerceResponse> LookupAsync(FinancialAccountLookupRequest payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/financial_accounts/lookup", payload, cancellationToken);

    public Task<CommerceResponse> ReconnectAsync(string accountId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/financial_accounts/reconnect", new { account_id = accountId }, cancellationToken);

    public Task<CommerceResponse> ReconnectAsync(FinancialAccountLookupRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.AccountId, "account_id");
        return _client.PostAsync("/financial_accounts/reconnect", payload, cancellationToken);
    }

    public Task<CommerceResponse> ConnectAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/financial_accounts/connect", payload, cancellationToken);

    public Task<CommerceResponse> ConnectAsync(FinancialAccountCreateRequest payload, CancellationToken cancellationToken = default) =>
        ConnectAsync(payload, validateOwner: true, cancellationToken);

    private Task<CommerceResponse> ConnectAsync(FinancialAccountCreateRequest payload, bool validateOwner, CancellationToken cancellationToken)
    {
        if (validateOwner)
        {
            RequestValidator.Require(payload.Owner, "owner");
        }
        return _client.PostAsync("/financial_accounts/connect", payload, cancellationToken);
    }

    public Task<CommerceResponse> UpdateAsync(FinancialAccountUpdateRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.AccountId, "account_id");
        return _client.PostAsync("/financial_accounts/update", payload, cancellationToken);
    }

    public Task<CommerceResponse> ArchiveAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/financial_accounts/archive", payload, cancellationToken);

    public Task<CommerceResponse> ArchiveAsync(FinancialAccountArchiveRequest payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/financial_accounts/archive", payload, cancellationToken);

    public Task<CommerceResponse> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/financial_accounts/page", payload ?? new { }, cancellationToken);

    public Task<CommerceResponse> PageAsync(FinancialAccountPageRequest payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/financial_accounts/page", payload, cancellationToken);

    public Task<CommerceResponse> VerifyAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/financial_accounts/verify", payload, cancellationToken);

    public Task<CommerceResponse> VerifyAsync(FinancialAccountVerifyRequest payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/financial_accounts/verify", payload, cancellationToken);

    public Task<CommerceResponse> EnablePushAsync(FinancialAccountToggleRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.AccountId, "account_id");
        return _client.PostAsync("/financial_accounts/enable_push", payload, cancellationToken);
    }

    public Task<CommerceResponse> DisablePushAsync(FinancialAccountToggleRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.AccountId, "account_id");
        return _client.PostAsync("/financial_accounts/disable_push", payload, cancellationToken);
    }

    public Task<CommerceResponse> EnablePullAsync(FinancialAccountToggleRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.AccountId, "account_id");
        return _client.PostAsync("/financial_accounts/enable_pull", payload, cancellationToken);
    }

    public Task<CommerceResponse> DisablePullAsync(FinancialAccountToggleRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.AccountId, "account_id");
        return _client.PostAsync("/financial_accounts/disable_pull", payload, cancellationToken);
    }

    public Task<CommerceResponse> DisconnectAsync(FinancialAccountToggleRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.AccountId, "account_id");
        return _client.PostAsync("/financial_accounts/disconnect", payload, cancellationToken);
    }
}
