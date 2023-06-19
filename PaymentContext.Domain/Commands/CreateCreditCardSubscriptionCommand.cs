using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands;

public class CreateCreditCardSubscriptionCommand : Notifiable<Notification>, ICommand
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Document { get; set; }
    public string Email { get; set; }
    public string CardHolderName { get; private set; }
    public string CardNumber { get; private set; }
    public string LastTransactionNumber { get; private set; }
    public DateTime PaidDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaid { get; set; }
    public string Payer { get; set; }
    public EDocumentType PayerDocumentType { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
    
    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterThan(FirstName, 3, "Name.FirstName", "Name must contain at least 3 characters")
            .IsLowerThan(FirstName, 50, "Name.FirstName", "Name must contain a maximum of 50 characters")
            .IsGreaterThan(LastName, 3, "Name.LastName", "Name must contain at least 3 characters")
            .IsLowerThan(LastName, 50, "Name.LastName", "Name must contain a maximum of 50 characters"));
    }
}