namespace Inttegro;

/// <summary>Deterministic questions about Inttegro resource responses.</summary>
public static class ResourceSemantics
{
    public static bool IsPaid(this Payment payment) => payment.Status == PaymentStatus.Paid;

    public static bool RequiresAction(this Payment payment) =>
        payment.Status == PaymentStatus.RequiresAction;

    public static bool IsTerminal(this Payment payment) =>
        payment.Status is PaymentStatus.Paid
            or PaymentStatus.Canceled
            or PaymentStatus.Expired
            or PaymentStatus.Failed;

    public static PaymentNextAction? RequiredAction(this Payment payment) =>
        payment.RequiresAction() ? payment.NextAction : null;

    public static bool IsPaid(this Order order) =>
        order.Status == OrderStatus.Paid || order.PaidAt is not null;

    public static bool RequiresPayment(this Order order) =>
        order.Status == OrderStatus.RequiresPayment;

    public static bool IsTerminal(this Order order) =>
        order.Status is OrderStatus.Paid
            or OrderStatus.Completed
            or OrderStatus.Canceled
            or OrderStatus.Expired;

    public static PaymentNextAction? RequiredPaymentAction(this Order order) =>
        order.Payment?.RequiredAction();

    public static bool IsActive(this PurchaseIntent intent) =>
        intent.Status == PurchaseIntentStatus.Active;

    public static bool IsSingleUse(this PurchaseIntent intent) =>
        intent.Usage.SingleUse is true;

    public static string? UsedOrderId(this PurchaseIntent intent)
    {
        var id = intent.IsSingleUse() ? intent.Usage.Order?.Id : null;
        return string.IsNullOrEmpty(id) ? null : id;
    }

    public static bool IsArchived(this Product product) => product.ArchivedAt is not null;

    public static bool IsPublished(this Product product) => product.Active && !product.IsArchived();

    public static bool WasEverPublished(this Product product) => product.PublishedAt is not null;

    public static bool IsArchived(this PaymentMethod method) => method.ArchivedAt is not null;

    public static bool IsVerified(this PaymentMethod method) => method.VerifiedAt is not null;

    public static bool IsReusable(this PaymentMethod method) =>
        method.Active && !method.IsArchived() && method.Ephemeral is not true;
}
