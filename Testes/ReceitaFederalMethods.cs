using Moq;
using NUnit.Framework;
using ReceitaFederalDataScrapping;

namespace Testes
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidateCpfData()
        {
            string cpf = "111.848.468-12";
            string dataNascimento = "25/04/1955";
            string acess_token = "";

            var receitaDataScraping = new Mock<ReceitaFederal>();

            var result = receitaDataScraping.Object.ValidateCpfData(cpf, dataNascimento,acess_token);

            Assert.NotNull(result);
        }
    }
}