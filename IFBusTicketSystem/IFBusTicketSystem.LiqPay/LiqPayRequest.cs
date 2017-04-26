using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace IFBusTicketSystem.LiqPay
{
    internal class LiqPayRequest
    {
        public static string Post(string url, IDictionary<string, string> list, string proxyLogin = null, string proxyPassword = null, WebProxy proxy = null)
        {
            var urlParameters = Encoding.ASCII.GetBytes(
                list.Aggregate(
                    string.Empty, 
                    (current, entry) => current + string.Concat(entry.Key, "=", WebUtility.UrlEncode(entry.Value), "&")
                    )
                );

            var request = WebRequest.CreateHttp(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = urlParameters.Length;

            if (proxy != null)
            {
                request.Proxy = proxy;

                if(!string.IsNullOrEmpty(proxyLogin) && !string.IsNullOrEmpty(proxyPassword))
                    request.Proxy.Credentials = new NetworkCredential(proxyLogin, proxyPassword);
            } 

            using (var stream = request.GetRequestStream())
            {
                stream.Write(urlParameters, 0, urlParameters.Length);
            }

            string responseContent = null;

            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        responseContent = streamReader.ReadToEnd();
                    }
                }
            }

            return responseContent;
        }
    }
}
