using PaymentContext.Domain.ValueObjects;
using Document = System.Reflection.Metadata.Document;
using ICommand = PaymentContext.Shared.Commands.ICommand;

namespace PaymentContext.Domain.Commands;

public class CreatePaypalSubscriptionCommand : ICommand
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Document { get; set; }
    public string Email { get; set; }
    public string TransactionCode { get; set; }
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
        throw new NotImplementedException();
    }
}