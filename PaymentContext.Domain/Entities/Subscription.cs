namespace PaymentContext.Domain.Entities;

public class Subscription
{
    public Subscription(DateTime createDate, DateTime lastUpdateDate, DateTime? expireDate, bool active, IList<Payment> payments)
    {
        CreateDate = createDate;
        LastUpdateDate = lastUpdateDate;
        ExpireDate = expireDate;
        Active = active;
        Payments = payments;
    }

    public DateTime CreateDate { get; private set; }
    public DateTime LastUpdateDate { get; private set; }
    public DateTime? ExpireDate { get; private set; }
    public bool Active { get; private set; }

    public IList<Payment> Payments { get; private set; }
}