﻿using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading;

namespace ReceitaFederalDataScrapping.Crawlers
{
    class CpfCrawler
    {
        private string baseUrl = @"https://servicos.receita.fazenda.gov.br/servicos/cpf/consultasituacao/ConsultaPublicaSonoro.asp?";
        private string _acess_token;
        private ChromeOptions chromeOptions = new ChromeOptions();
        private ChromeDriver driver = new ChromeDriver();
        public CpfCrawler(string acess_token)
        {
            this._acess_token = acess_token;
        }
        public Dictionary<string,string> CpfResponse(string cpf, string dataNascimento)
        {
            GoToUrl(cpf, dataNascimento);
            TryToPass();
            return GetDataFromCPF();
        }
        private void GoToUrl(string cpf, string dataNascimento)
        {
            driver.Navigate().GoToUrl($"{baseUrl}CPF={cpf}&NASCIMENTO={dataNascimento}");
        }
        private void TryToPass()
        {
            string imageBaseB64 = GetImageB64();
            string responseCaptcha = Utils.Utils.SolverCaptcha(imageBaseB64,this._acess_token);
            driver.FindElementByXPath("//*[@id='txtTexto_captcha_serpro_gov_br']").SendKeys(responseCaptcha);
            Thread.Sleep(500);
            driver.FindElementByXPath("//*[@id='id_submit']").Click();
            if (driver.Url.Contains("Error"))
            {
                TryToPass();
            }
        }

        private string GetImageB64()
        {
            return driver.FindElementByXPath("//*[@id='imgCaptcha']").GetAttribute("src").Replace("data:image/png;base64,","");
        }

        private Dictionary<string, string> GetDataFromCPF()
        {
            string cpf = driver.FindElementByXPath("//*[@class='clConteudoDados'][1]").Text;
            string nome = driver.FindElementByXPath("//*[@class='clConteudoDados'][2]").Text;
            string dataNascimento = driver.FindElementByXPath("//*[@class='clConteudoDados'][3]").Text;
            string situacaoCadastral = driver.FindElementByXPath("//*[@class='clConteudoDados'][4]").Text;
            string dataInscricao = driver.FindElementByXPath("//*[@class='clConteudoDados'][5]").Text;
            string digitoVerificador = driver.FindElementByXPath("//*[@class='clConteudoDados'][6]").Text;


            return new Dictionary<string, string> { 
                {"CPF", cpf.Replace("No do CPF: ","") },
                {"NOME", nome.Replace("Nome: ","") },
                {"NASCIMENTO", dataNascimento.Replace("Data de Nascimento: ","") },
                {"SITUACAO", situacaoCadastral.Replace("Situação Cadastral: ","")},
                {"DATAINSCRICAO", dataInscricao.Replace("Data da Inscrição: ","") },
                {"DIGITOVERIFICADOR", digitoVerificador.Replace("Digito Verificador: ","") }
            };
        }

    }
}