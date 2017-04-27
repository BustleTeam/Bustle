using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace IFBusTicketSystem.LiqPay
{
    public static class LiqPayUtility
    {
        public static byte[] Sha1(this string param)
        {
            var sha1 = SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(param);

            return sha1.ComputeHash(inputBytes);
        }

        public static IDictionary<string, string> GenerateData(IDictionary<string, string> parameters, string publicKey, string privateKey)
        {

            var jsonData = JsonConvert.SerializeObject(parameters.WithBasicApiParameters(publicKey));
            var data = Convert.ToBase64String(Encoding.ASCII.GetBytes(jsonData));

            return new Dictionary<string, string>
            {
                {"data", data},
                {"signature", CreateSignature(data, privateKey)}
            };
        }

        public static string CreateSignature(string base64EncodedData, string privateKey)
        {
            return string.Concat(privateKey, base64EncodedData, privateKey).ToSign();
        }

        public static string ToSign(this string str)
        {
            return Convert.ToBase64String(str.Sha1());
        }

        public static SortedDictionary<string, string> WithBasicApiParameters(this IDictionary<string, string> parameters , string publicKey)
        {
            var sortedList = new SortedDictionary<string, string>(parameters)
            {
                {"public_key", publicKey},
                {"version", LiqPayConstants.ApiVersion}
            };

            return sortedList;
        }

        public static SortedDictionary<string, string> WithSandboxParameter(this SortedDictionary<string, string> parameters, bool isCnbSandbox)
        {
            if (isCnbSandbox && !parameters.ContainsKey("sandbox"))
                return new SortedDictionary<string, string>(parameters)
                {
                    {"sandbox", "1"}
                };

            return parameters;
        }

        public static void CheckCnbParameters(this IDictionary<string, string> parameters)
        {
            if (!parameters.ContainsKey("amount"))
                throw new NullReferenceException("amount can not be null");
            else
            {
                if (parameters["amount"] == null)
                    throw new NullReferenceException("amount can not be null");
            }

            if (!parameters.ContainsKey("currency"))
                throw new NullReferenceException("currency can not be null");
            else
            {
                if (parameters["currency"] == null)
                    throw new NullReferenceException("currency can not be null");
            }

            if (!parameters.ContainsKey("description"))
                throw new NullReferenceException("description can not be null");
            else
            {
                if (parameters["description"] == null)
                    throw new NullReferenceException("description can not be null");
            }
        }
    }
}
