using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Student : Entity
{
    private IList<Subscription> _subscriptions;
    public Student(Name name, Document document, Email email)
    {
        Name = name;
        Document = document;
        Email = email;
        _subscriptions = new List<Subscription>();
        
        AddNotifications(name, document, email);
    }

    public Name Name { get; set; }
    public Document Document { get; private set; }
    public Email Email { get; private set; }
    
    public IReadOnlyCollection<Subscription> Subscriptions
    {
        get { return _subscriptions.ToArray(); }
    }

    public void AddSubscription(Subscription subscription)
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsFalse(Subscriptions.Any(x => x.Active), "Student.Subscriptions", "You already have an active subscription")
            .AreNotEquals(0, subscription.Payments.Count, "Student.Subscription.Payments", "This subscription has no payments")
        );
        _subscriptions.Add(subscription);
    }
}