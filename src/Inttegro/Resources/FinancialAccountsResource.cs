using Inttegro.Http;
using Inttegro.Models;
using Inttegro.Responses;
using Inttegro.Validation;

namespace Inttegro.Resources;

public class FinancialAccountsResource
{
    private readonly ApiClient _client;

    internal FinancialAccountsResource(ApiClient client) => _client = client;

    public Task<InttegroResponse> CreateAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/financial_accounts/create", payload, cancellationToken);

    public Task<InttegroResponse> CreateAsync(FinancialAccountCreateRequest payload, CancellationToken cancellationToken = default) =>
        CreateAsync(payload, validateOwner: true, cancellationToken);

    private Task<InttegroResponse> CreateAsync(FinancialAccountCreateRequest payload, bool validateOwner, CancellationToken cancellationToken)
    {
        if (validateOwner)
        {
            RequestValidator.Require(payload.Owner, "owner");
        }
        return _client.PostAsync("/financial_accounts/create", payload, cancellationToken);
    }

    public Task<InttegroResponse> LookupAsync(string accountId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/financial_accounts/lookup", new { account_id = accountId }, cancellationToken);

    public Task<InttegroResponse> LookupAsync(FinancialAccountLookupRequest payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/financial_accounts/lookup", payload, cancellationToken);

    public Task<InttegroResponse> ReconnectAsync(string accountId, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/financial_accounts/reconnect", new { account_id = accountId }, cancellationToken);

    public Task<InttegroResponse> ReconnectAsync(FinancialAccountLookupRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.AccountId, "account_id");
        return _client.PostAsync("/financial_accounts/reconnect", payload, cancellationToken);
    }

    public Task<InttegroResponse> ConnectAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/financial_accounts/connect", payload, cancellationToken);

    public Task<InttegroResponse> ConnectAsync(FinancialAccountCreateRequest payload, CancellationToken cancellationToken = default) =>
        ConnectAsync(payload, validateOwner: true, cancellationToken);

    private Task<InttegroResponse> ConnectAsync(FinancialAccountCreateRequest payload, bool validateOwner, CancellationToken cancellationToken)
    {
        if (validateOwner)
        {
            RequestValidator.Require(payload.Owner, "owner");
        }
        return _client.PostAsync("/financial_accounts/connect", payload, cancellationToken);
    }

    public Task<InttegroResponse> UpdateAsync(FinancialAccountUpdateRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.AccountId, "account_id");
        return _client.PostAsync("/financial_accounts/update", payload, cancellationToken);
    }

    public Task<InttegroResponse> ArchiveAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/financial_accounts/archive", payload, cancellationToken);

    public Task<InttegroResponse> ArchiveAsync(FinancialAccountArchiveRequest payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/financial_accounts/archive", payload, cancellationToken);

    public Task<InttegroResponse> PageAsync(object? payload = null, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/financial_accounts/page", payload ?? new { }, cancellationToken);

    public Task<InttegroResponse> PageAsync(FinancialAccountPageRequest payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/financial_accounts/page", payload, cancellationToken);

    public Task<InttegroResponse> VerifyAsync(object payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/financial_accounts/verify", payload, cancellationToken);

    public Task<InttegroResponse> VerifyAsync(FinancialAccountVerifyRequest payload, CancellationToken cancellationToken = default) =>
        _client.PostAsync("/financial_accounts/verify", payload, cancellationToken);

    public Task<InttegroResponse> EnablePushAsync(FinancialAccountToggleRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.AccountId, "account_id");
        return _client.PostAsync("/financial_accounts/enable_push", payload, cancellationToken);
    }

    public Task<InttegroResponse> DisablePushAsync(FinancialAccountToggleRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.AccountId, "account_id");
        return _client.PostAsync("/financial_accounts/disable_push", payload, cancellationToken);
    }

    public Task<InttegroResponse> EnablePullAsync(FinancialAccountToggleRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.AccountId, "account_id");
        return _client.PostAsync("/financial_accounts/enable_pull", payload, cancellationToken);
    }

    public Task<InttegroResponse> DisablePullAsync(FinancialAccountToggleRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.AccountId, "account_id");
        return _client.PostAsync("/financial_accounts/disable_pull", payload, cancellationToken);
    }

    public Task<InttegroResponse> DisconnectAsync(FinancialAccountToggleRequest payload, CancellationToken cancellationToken = default)
    {
        RequestValidator.Require(payload.AccountId, "account_id");
        return _client.PostAsync("/financial_accounts/disconnect", payload, cancellationToken);
    }
}
