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
        public void TestCrawlerCPF()
        {
            string cpf = "011.262.182-19";
            string dataNascimento = "25/01/2001";
            string acess_token = "D9A891E0CC5B4A42961A64A1EDE59943";

            var receitaDataScraping = new Mock<ReceitaFederal>();

            var result = receitaDataScraping.Object.ValidateCpfData(cpf, dataNascimento,acess_token);

            Assert.NotNull(result);
        }
    }
}