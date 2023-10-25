using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public abstract class Payment : Entity
{
    public Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string owner,
                   Document document, Address address, Email email)
    {
        Number = Guid.NewGuid().ToString().Replace("-", "").ToUpper().Substring(0, 10);
        PaidDate = paidDate;
        ExpireDate = expireDate;
        Total = total;
        TotalPaid = totalPaid;
        Owner = owner;
        Document = document;
        Address = address;
        Email = email;

        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterThan(0, Total, "Payment.Total", "O total não pode ser zero")
            .IsLowerThan(Total, TotalPaid, "Payment.TotalPaid", "O valor pago e menor que o valor a ser recebido.")
            );
    }

    public string Number { get; private set; }
    public DateTime PaidDate { get; private set; }
    public DateTime ExpireDate { get; private set; }
    public decimal Total { get; private set; }
    public decimal TotalPaid { get; private set; }
    public string Owner { get; private set; }
    public Document Document { get; private set; }
    public Address Address { get; private set; }
    public Email Email { get; private set; }
}