using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json.Linq;

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
    }
}
