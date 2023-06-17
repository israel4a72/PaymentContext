using PaymentContext.Domain;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities;

[TestClass]
public class StudentTests
{
    private readonly Student _student;
    private readonly Subscription _subscription;
    private readonly Name _name;
    private readonly Document _document;
    private readonly Email _email;
    private readonly Address _address;
    private readonly Payment _payment;

    public StudentTests()
    {
        _name = new Name("Silva", "Zoldick");
        _document = new Document("12345678900", EDocumentType.CPF);
        _email = new Email("zed@manga.com");
        _address = new Address("1 street", "1245", "city", "state", "country", "zipCode");
        _student = new Student(_name, _document, _email);
        _subscription = new Subscription(null);
        _payment = new PayPalPayment(DateTime.Now, DateTime.Now.AddDays(5), 10, 10, 
            "hmm", _document, _address, _email, "12345678");
    }
    [TestMethod]
    public void ShouldReturnErrorWhenHadActiveSubscription()
    {
        _subscription.AddPayment(_payment);
        _student.AddSubscription(_subscription);
        _student.AddSubscription(_subscription);
        
        Assert.IsFalse(_student.IsValid);
    }
    [TestMethod]
    public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
    {
        _student.AddSubscription(_subscription);
        
        Assert.IsFalse(_student.IsValid);
    }
    [TestMethod]
    public void ShouldReturnSuccessWhenHadNoActiveSubscription()
    {
        _subscription.AddPayment(_payment);
        _student.AddSubscription(_subscription);
        
        Assert.IsTrue(_student.IsValid);
    } 
}