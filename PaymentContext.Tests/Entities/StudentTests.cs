using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities;

[TestClass]
public class StudentTests
{
    private readonly Name _name;
    private readonly Document _document;
    private readonly Address _address;
    private readonly Email _email;
    private readonly Student _student;

    public StudentTests()
    {
        _name = new Name("Gabriel", "Milani");
        _document = new Document("12345678910", EDocumentType.CPF);
        _address = new Address("Rua 1", "2", "Bairro 3", "Santo Antônio da Platina", "PR", "BR", "86430000");
        _email = new Email("g.milani.e@gmail.com");
        _student = new Student(_name, _document, _email, _address);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenHadSubscription()
    {
        var payment = new PayPalPayment(DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Gabriel", _document, _address, _email, "123456789");
        var subscription = new Subscription(null);
        subscription.AddPayment(payment);
        _student.AddSubscription(subscription);
        _student.AddSubscription(subscription);
        Assert.IsTrue(!_student.IsValid);
    }
    [TestMethod]
    public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
    {
        var subscription = new Subscription(null);
        _student.AddSubscription(subscription);
        Assert.IsTrue(!_student.IsValid);
    }
    [TestMethod]
    public void ShouldReturnSuccessWhenAddSubscription()
    {
        var payment = new PayPalPayment(DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Gabriel", _document, _address, _email, "123456789");
        var subscription = new Subscription(null);
        subscription.AddPayment(payment);
        _student.AddSubscription(subscription);
        Assert.IsTrue(_student.IsValid);
    }
}