using PaymentContext.Domain.Commands;

namespace PaymentContext.Tests.Commands;

[TestClass]
public class CreatePayPalSubscriptionCommandTests
{
    [TestMethod]
    public void ShouldReturnErrorWhenNameIsInvalid()
    {
        var command = new CreatePayPalSubscriptionCommand();
        command.FirstName = "";

        command.Validate();
        Assert.AreEqual(false, command.IsValid);
    }
}
