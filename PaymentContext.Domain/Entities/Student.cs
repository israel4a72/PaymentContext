namespace PaymentContext.Domain.Entities;

public class Student
{
    public Student(string firstName, string lastName, string document, string email, IList<Subscription> subscriptions)
    {
        FirstName = firstName;
        LastName = lastName;
        Document = document;
        Email = email;
        Subscriptions = subscriptions;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Document { get; private set; }
    public string Email { get; private set; }
    
    public IList<Subscription> Subscriptions { get; private set; }
}