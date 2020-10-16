using ReceitaFederalDataScrapping.Crawlers;
using System;
using System.Collections.Generic;

namespace ReceitaFederalDataScrapping
{
    public class ReceitaFederal
    {
        public Dictionary<string,string> ValidateCpfData(string cpf, string dataNascimento, string acess_token)
        {
            CpfCrawler cpfCrawler = new CpfCrawler(acess_token);
            return cpfCrawler.CpfResponse(cpf, dataNascimento);
        }

        

    }
}
