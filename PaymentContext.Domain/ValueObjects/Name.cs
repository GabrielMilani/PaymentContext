using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsLowerThan(FirstName, 40, "FirstName", "Nome deve conter menos que 40 caracteres")
            .IsGreaterThan(FirstName, 3, "FirstName", "Nome deve conter mais que 3 caracteres")
            .IsLowerThan(LastName, 40, "LastName", "Sobrenome deve conter menos que 40 caracteres")
            .IsGreaterThan(LastName, 3, "LastName", "Sobrenome deve conter mais que 3 caracteres"));
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}