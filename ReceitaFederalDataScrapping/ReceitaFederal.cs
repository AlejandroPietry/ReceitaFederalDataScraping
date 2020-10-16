using ReceitaFederalDataScrapping.Crawlers;
using System.Collections.Generic;

namespace ReceitaFederalDataScrapping
{
    public class ReceitaFederal
    {
        public Dictionary<string,string> ValidateCpfData(string cpf, string dataNascimento, string acess_token)
        {
            if (!cpf.Contains("."))
                cpf = Utils.UtilsCrawler.FormartCpf(cpf);
            if (!dataNascimento.Contains("/"))
                dataNascimento = Utils.UtilsCrawler.FormatDateOfBirth(dataNascimento);

            CpfCrawler cpfCrawler = new CpfCrawler(acess_token);
            return cpfCrawler.CpfResponse(cpf, dataNascimento);
        }
    }
}
