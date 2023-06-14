namespace PaymentContext.Domain.Entities;

public abstract class Payment
{
    protected Payment(string number, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, string document, string address, string email)
    {
        Number = number;
        PaidDate = paidDate;
        ExpireDate = expireDate;
        Total = total;
        TotalPaid = totalPaid;
        Payer = payer;
        Document = document;
        Address = address;
        Email = email;
    }
    public string Number { get; private set; }
    public DateTime PaidDate { get; private set; }
    public DateTime ExpireDate { get; private set; }
    public decimal Total { get; private set; }
    public decimal TotalPaid { get; private set; }
    public string Payer { get; private set; }
    public string Document { get; private set; }
    public string Address { get; private set; }
    public string Email { get; private set; }
}

public class BoletoPayment : Payment
{
    public BoletoPayment(string number, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, string document, string address, string email, string barCode, string boletoNumber) 
        : base(number, paidDate, expireDate, total, totalPaid, payer, document, address, email)
    {
        BarCode = barCode;
        BoletoNumber = boletoNumber;
    }
    public string BarCode { get; private set; }
    public string BoletoNumber { get; private set; }
}

public class CreditCardPayment : Payment
{
    public CreditCardPayment(string number, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, string document, string address, string email, string cardHolderName, string cardNumber, string lastTransactionNumber) 
        : base(number, paidDate, expireDate, total, totalPaid, payer, document, address, email)
    {
        CardHolderName = cardHolderName;
        CardNumber = cardNumber;
        LastTransactionNumber = lastTransactionNumber;
    }
    public string CardHolderName { get; private set; }
    public string CardNumber { get; private set; }
    public string LastTransactionNumber { get; private set; }
}

public class PayPalPayment : Payment
{
    public PayPalPayment(string number, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, string document, string address, string email, string transactionCode) 
        : base(number, paidDate, expireDate, total, totalPaid, payer, document, address, email)
    {
        TransactionCode = transactionCode;
    }
    public string TransactionCode { get; private set; }
}