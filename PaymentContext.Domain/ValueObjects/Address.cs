using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Address : ValueObject
{
    public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
    {
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;

        AddNotifications(new Contract<Notification>().Requires()
                                                     .IsLowerThan(Street, 100, "Address.Street", "Rua deve conter menos que 100 caracteres")
                                                     .IsGreaterThan(Street, 1, "Address.Street", "Rua deve conter mais que 1 caracteres")
                                                     .IsLowerThan(Number, 10, "Address.Number", "Numero deve conter menos que 10 caracteres")
                                                     .IsGreaterThan(Number, 3, "Address.Number", "Numero deve conter mais que 1 caracteres")
                                                     .IsLowerThan(Neighborhood, 40, "Address.Neighborhood", "Bairro deve conter menos que 40 caracteres")
                                                     .IsGreaterThan(Neighborhood, 3, "Address.Neighborhood", "Bairro deve conter mais que 3 caracteres")
                                                     .IsLowerThan(City, 100, "Address.City", "Cidade deve conter menos que 100 caracteres")
                                                     .IsGreaterThan(City, 3, "Address.City", "Cidade deve conter mais que 3 caracteres")
                                                     .IsGreaterOrEqualsThan(State, 2, "Address.State", "Sigla Estado deve conter 2 caracteres")
                                                     .IsGreaterOrEqualsThan(Country, 2, "Address.Country", "Sigla Pais deve conter 2 caracteres")
                                                     .IsGreaterOrEqualsThan(ZipCode, 8, "Address.ZipCode", "Codigo da cidade deve conter 8 caracteres"));
    }

    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }
}