using Flunt.Notifications;

namespace PaymentContext.Shared.Entities;

public class Entity : Notifiable<Notification>
{
    public Guid Id { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public DateTime LasUpdatedDate { get; private set; }

    public Entity()
    {
        Id = Guid.NewGuid();
        CreatedDate = DateTime.Now;
        LasUpdatedDate = DateTime.Now;
    }
}