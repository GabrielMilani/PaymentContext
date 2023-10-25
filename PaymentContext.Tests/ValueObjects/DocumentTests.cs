using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects;

[TestClass]
public class DocumentTests
{
    [TestMethod]
    public void ShouldReturnErrorWhenCNPJIsInvalid()
    {
        var doc = new Document("123", EDocumentType.CNPJ);
        Assert.IsTrue(!doc.IsValid);
    }
    [TestMethod]
    public void ShouldReturnSuccessWhenCNPJIsValid()
    {
        var doc = new Document("12345678910111", EDocumentType.CNPJ);
        Assert.IsTrue(doc.IsValid);
    }
    [TestMethod]
    public void ShouldReturnErrorWhenCPFIsInvalid()
    {
        var doc = new Document("123", EDocumentType.CPF);
        Assert.IsTrue(!doc.IsValid);
    }
    [TestMethod]
    [DataTestMethod]
    [DataRow("12345678910")]
    [DataRow("12345678911")]
    [DataRow("12345678912")]
    [DataRow("12345678913")]
    public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
    {
        var doc = new Document(cpf, EDocumentType.CPF);
        Assert.IsTrue(doc.IsValid);
    }
}