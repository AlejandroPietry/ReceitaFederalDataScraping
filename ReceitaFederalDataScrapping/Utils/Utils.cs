using bestcaptchasolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReceitaFederalDataScrapping.Utils
{
    class Utils
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

            apiResponse.TryGetValue("text", out string captchaResultText
);
            return captchaResultText;
        }
    }
}
