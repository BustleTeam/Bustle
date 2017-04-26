using System.Collections.Generic;

namespace IFBusTicketSystem.LiqPay
{
    public interface ILiqPayApi
    {
        Dictionary<string, object> Api(string path, IDictionary<string, string> parameters);

        /// <summary> 
        /// Liq and Buy
        /// Payment acceptance on the site client to server
        /// To accept payments on your site you will need:
        /// Register on www.liqpay.com
        /// Create a store in your account using install master
        /// Get a ready HTML-button or create a simple HTML form
        /// HTML form should be sent by POST to URL https://www.liqpay.com/api/3/checkout Two parameters data and signature, where:
        /// data - function result base64_encode( $json_string )
        /// signature - function result base64_encode( sha1( $private_key . $data . $private_key ) )
        /// </summary> 
        string CnbForm(IDictionary<string, string> parameters);
    }
}
