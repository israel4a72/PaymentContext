using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Document : ValueObject
{
    public Document(string number, EDocumentType type)
    {
        Number = number;
        Type = type;
        
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsTrue(Validate(), "Document.Number", "Documento inválido")
        );
    }
    public string Number { get; private set; }
    public EDocumentType Type { get; private set; }
    public bool Validate() => IsCpf() || IsCnpj();
    public bool IsCpf() => Type == EDocumentType.CPF && Number.Length == 11;
    public bool IsCnpj() => Type == EDocumentType.CNPJ && Number.Length == 14;
}