using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Document : ValueObject
{
    public string Number { get; private set; }
    public EDocumentType Type { get; private set; }

    public Document(string number, EDocumentType type)
    {
        Number = number;
        Type = type;
        
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsTrue(Validate(), "Document.Number", "Documento inválido")
        );
    }

    public bool Validate()
    {
        if (Type == EDocumentType.CPF && Number.Length == 11)
            return true;
        if (Type == EDocumentType.CNPJ && Number.Length == 14)
            return true;

        return false;
    }
}