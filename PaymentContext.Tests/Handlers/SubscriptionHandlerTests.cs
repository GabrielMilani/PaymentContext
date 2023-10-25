using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers;

[TestClass]
public class SubscriptionHandlerTests
{
    [TestMethod]
    public void ShouldReturnErrorWhenDocumentExists()
    {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
        var command = new CreateBoletoSubscriptionCommand();
        command.FirstName = "Gabriel";
        command.LastName = "Milani";
        command.Document = "12345678910";
        command.Email = "Gabriel@Hotmail.com";
        command.BarCode = "123456789";
        command.BoletoNumber = "1234654987";
        command.PaymentNumber = "123123";
        command.PaidDate = DateTime.Now;
        command.ExpireDate = DateTime.Now.AddMonths(1);
        command.Total = 60;
        command.TotalPaid = 60;
        command.Payer = "MILANI";
        command.PayerDocument = "12345678911";
        command.PayerDocumentType = EDocumentType.CPF;
        command.PayerEmail = "Gabril@Hotmail.com";
        command.Street = "Rua 1";
        command.Number = "123";
        command.Neighborhood = "Bairro 1";
        command.City = "cidade 1";
        command.State = "PR";
        command.Country = "BR";
        command.ZipCode = "12345678";

        handler.Handle(command);
        Assert.AreEqual(false, handler.IsValid);
    }
    [TestMethod]
    public void ShouldReturnErrorWhenEmailExists()
    {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
        var command = new CreateBoletoSubscriptionCommand();
        command.FirstName = "Gabriel";
        command.LastName = "Milani";
        command.Document = "12345678912";
        command.Email = "Gabriel@gmail.com";
        command.BarCode = "123456789";
        command.BoletoNumber = "1234654987";
        command.PaymentNumber = "123123";
        command.PaidDate = DateTime.Now;
        command.ExpireDate = DateTime.Now.AddMonths(1);
        command.Total = 60;
        command.TotalPaid = 60;
        command.Payer = "MILANI";
        command.PayerDocument = "12345678911";
        command.PayerDocumentType = EDocumentType.CPF;
        command.PayerEmail = "Gabril@Hotmail.com";
        command.Street = "Rua 1";
        command.Number = "123";
        command.Neighborhood = "Bairro 1";
        command.City = "cidade 1";
        command.State = "PR";
        command.Country = "BR";
        command.ZipCode = "12345678";

        handler.Handle(command);
        Assert.AreEqual(false, handler.IsValid);
    }
}