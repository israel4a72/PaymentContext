using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Address : ValueObject
{
    public Address(string street, string neighbourhood, string city, string state, string country, string zipCode)
    {
        Street = street;
        Neighbourhood = neighbourhood;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
        
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterThan(Street, 3, "Address.Street", "Street must have at least 3 characters")
            .IsLowerThan(Street, 50, "Address.Street", "Street must have a maximum of 50 characters")
            .IsGreaterThan(Neighbourhood, 3, "Address.Neighbourhood", "Neighbourhood must have at least 3 characters")
            .IsLowerThan(Neighbourhood, 50, "Address.Neighbourhood", "Neighbourhood must have a maximum of 50 characters")
            .IsGreaterThan(City, 3, "Address.City", "City must have at least 3 characters")
            .IsLowerThan(City, 50, "Address.City", "City must have a maximum of 50 characters")
            .IsGreaterThan(State, 3, "Address.State", "State must have at least 3 characters")
            .IsLowerThan(State, 50, "Address.State", "State must have a maximum of 50 characters")
            .IsGreaterThan(Country, 3, "Address.Country", "Country must have at least 3 characters")
            .IsLowerThan(Country, 50, "Address.Country", "Country must have a maximum of 50 characters")
            .IsGreaterThan(ZipCode, 3, "Address.ZipCode", "ZipCode must have at least 3 characters")
            .IsLowerThan(ZipCode, 50, "Address.ZipCode", "ZipCode must have a maximum of 50 characters")
        );
    }

    public string Street { get; private set; }
    public string Neighbourhood{ get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }
}