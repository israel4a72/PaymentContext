using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Subscription : Entity

{
    private IList<Payment> _payments;
    public Subscription(DateTime? expireDate)
    {
        ExpireDate = expireDate;
        Active = true;
        _payments = new List<Payment>();
    }

    public DateTime CreateDate { get; private set; }
    public DateTime LastUpdateDate { get; private set; }
    public DateTime? ExpireDate { get; private set; }
    public bool Active { get; private set; }

    public IReadOnlyCollection<Payment> Payments
    {
        get { return _payments.ToArray(); }
    }
    
    public void Inactivate()
    {
        Active = false;
        LastUpdateDate = DateTime.Now;
    }
    public void AddPayment(Payment payment)
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscription.Payments", "Payment date must be in the future")
        );
        _payments.Add(payment);
        LastUpdateDate = DateTime.Now;
    }
}