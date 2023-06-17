using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObject
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterThan(FirstName, 3, "Name.FirstName", "Name must contain at least 3 characters")
            .IsLowerThan(FirstName, 50, "Name.FirstName", "Name must contain a maximum of 50 characters")
            .IsGreaterThan(LastName, 3, "Name.LastName", "Name must contain at least 3 characters")
            .IsLowerThan(LastName, 50, "Name.LastName", "Name must contain a maximum of 50 characters")
        );
    }
}