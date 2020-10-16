using bestcaptchasolver;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReceitaFederalDataScrapping.Utils
{
    class UtilsCrawler
    {
        public static string SolverCaptcha(string imageBase64, string acess_token)
        {
            BestCaptchaSolverAPI bcs = new BestCaptchaSolverAPI(acess_token);
            Dictionary<string, string> d = new Dictionary<string, string>()
            { 
                {"image",imageBase64 } 
            };
            string taskId = bcs.submit_image_captcha(d);
            Dictionary<string, string> apiResponse = bcs.retrieve(taskId);

            apiResponse.TryGetValue("text", out string captchaResultText);
            return captchaResultText;
        }

        public static ChromeDriver ChromeDriverConfigured()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            return new ChromeDriver(options);
        }

        public static string FormartCpf(string cpf)
        {
            var a = cpf.ToArray();
            return $"{a[0]}{a[1]}{a[2]}.{a[3]}{a[4]}{a[5]}.{a[6]}{a[7]}{a[8]}-{a[9]}{a[10]}";
        }
        public static string FormatDateOfBirth(string dataNascimento)
        {
            var a = dataNascimento.ToArray();
            return $"{a[0]}{a[1]}/{a[2]}{a[3]}/{a[4]}{a[5]}{a[6]}{a[7]}";
        }
    }
}
