using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace IFBusTicketSystem.LiqPay
{
    public class LiqPayApi : ILiqPayApi
    {
        private readonly string _publicKey;
        private readonly string _privateKey;

        public WebProxy Proxy { get; set; }
        public string ProxyLogin { get; set; }
        public string ProxyPassword { get; set; }
        public bool IsCnbSandbox { get; set; }
        public bool RenderPayButton { get; set; } = true;


        public LiqPayApi(string publicKey, string privateKey)
        {
            _publicKey = publicKey;
            _privateKey = privateKey;

            CheckRequired();
        }

        public LiqPayApi(string publicKey, string privateKey, WebProxy proxy, string proxyLogin, string proxyPassword)
        {
            _publicKey = publicKey;
            _privateKey = privateKey;

            Proxy = proxy;
            ProxyLogin = proxyLogin;
            ProxyPassword = proxyPassword;

            CheckRequired();
        }

        public Dictionary<string, object> Api(string path, IDictionary<string, string> parameters)
        {
            var data = LiqPayUtility.GenerateData(parameters, _publicKey, _privateKey);

            var response = LiqPayRequest.Post(string.Concat(LiqPayConstants.LiqpayApiUrl, path), data, ProxyLogin, ProxyPassword, Proxy);

            return JsonConvert.DeserializeObject(response) as Dictionary<string, object>;
        }

        public string CnbForm(IDictionary<string, string> parameters)
        {
            parameters.CheckCnbParameters();

            var jsonData = JsonConvert.SerializeObject(parameters.WithBasicApiParameters(_publicKey).WithSandboxParameter(IsCnbSandbox));
            var data = Convert.ToBase64String(Encoding.ASCII.GetBytes(jsonData));

            string language;
            if (!parameters.TryGetValue("language", out language))
                language = LiqPayConstants.DefaultLang;
                
            var signature = LiqPayUtility.CreateSignature(data, _privateKey);

            return RenderHtmlForm(data, language, signature);
        }

        private string RenderHtmlForm(string data, string language, string signature)
        {
            var form =
                $"<form method=\"post\" action=\"{LiqPayConstants.LiqpayApiCheckoutUrl}\" accept-charset=\"utf-8\">\n" +
                $"<input type=\"hidden\" name=\"data\" value=\"{data}\" />\n" +
                $"<input type=\"hidden\" name=\"signature\" value=\"{signature}\" />\n";

            if (RenderPayButton)
            {
                form += $"<input type=\"image\" src=\"//static.liqpay.com/buttons/p1{language}.radius.png\" name=\"btn_text\" />\n";
            }

            form += "</form>\n";

            return form;
        }

        private void CheckRequired()
        {
            if(string.IsNullOrEmpty(_publicKey)) 
                throw new ArgumentException("public key is empty");

            if(string.IsNullOrEmpty(_privateKey))
                throw new ArgumentException("private key is empty");
        }
    }
}
