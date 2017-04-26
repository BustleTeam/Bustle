using System;
using System.Collections.Generic;
using System.Text;
using IFBusTicketSystem.LiqPay;
using Newtonsoft.Json.Linq;
using Xunit;

namespace IFBusTicketSystem.UnitTests.LiqPay
{
    public class LiqPayApiTests
    {
        private readonly LiqPayApi _liqPay;

        private const string CnbFormWithoutSandbox = "<form method=\"post\" action=\"https://www.liqpay.com/api/3/checkout\" accept-charset=\"utf-8\">\n" +
            "<input type=\"hidden\" name=\"data\" value=\"eyJhbW91bnQiOiIxLjUiLCJjdXJyZW5jeSI6IlVTRCIsImRlc2NyaXB0aW9uIjoiRGVzY3JpcHRpb24iLCJsYW5ndWFnZSI6ImVuIiwicHVibGljX2tleSI6InB1YmxpY0tleSIsInZlcnNpb24iOiIzIn0=\" />\n" +
            "<input type=\"hidden\" name=\"signature\" value=\"krCwuK4CBtNFAb6zqmJCeR/85VU=\" />\n" +
            "<input type=\"image\" src=\"//static.liqpay.com/buttons/p1en.radius.png\" name=\"btn_text\" />\n" +
            "</form>\n";

        private const string CnbFormWithSandbox = "<form method=\"post\" action=\"https://www.liqpay.com/api/3/checkout\" accept-charset=\"utf-8\">\n" +
            "<input type=\"hidden\" name=\"data\" value=\"eyJhbW91bnQiOiIxLjUiLCJjdXJyZW5jeSI6IlVTRCIsImRlc2NyaXB0aW9uIjoiRGVzY3JpcHRpb24iLCJsYW5ndWFnZSI6ImVuIiwicHVibGljX2tleSI6InB1YmxpY0tleSIsInNhbmRib3giOiIxIiwidmVyc2lvbiI6IjMifQ==\" />\n" +
            "<input type=\"hidden\" name=\"signature\" value=\"jDmdwKnagO2JhE1ONHdk3F7FG0c=\" />\n" +
            "<input type=\"image\" src=\"//static.liqpay.com/buttons/p1en.radius.png\" name=\"btn_text\" />\n" +
            "</form>\n";

        public LiqPayApiTests()
        {
            _liqPay = new LiqPayApi("publicKey", "privateKey");
        }

        [Fact]
        public void CnbFormWithSandboxParameter()
        {
            var parameters = DefaultTestParameters();

            Assert.Equal(CnbFormWithSandbox, _liqPay.CnbForm(parameters));
        }

        [Fact]
        public void CnbFormWithoutSandboxParameter()
        {
            var parameters = DefaultTestParameters("sandbox");

            Assert.Equal(CnbFormWithoutSandbox, _liqPay.CnbForm(parameters));
        }

        [Fact]
        public void CnbFormWillSetSandboxParamIfItEnabledGlobally()
        {
            var parameters = DefaultTestParameters("sandbox");

            _liqPay.IsCnbSandbox = true;

            Assert.Equal(CnbFormWithSandbox, _liqPay.CnbForm(parameters));
        }

        [Fact]
        public void CnbParameters_Succeed()
        {
            var parameters = DefaultTestParameters();
            _liqPay.CheckCnbParameters(parameters);

            Assert.Equal(parameters["language"], "en");
            Assert.Equal(parameters["currency"], "USD");
            Assert.Equal(parameters["amount"], "1.5");
            Assert.Equal(parameters["description"], "Description");
        }

        [Theory]
        [InlineData("amount")]
        [InlineData("currency")]
        [InlineData("description")]
        public void CnbParametersThrowNullReferenceExceptionWithoutParameter(string parameter)
        {
            var parameters = DefaultTestParameters("amount");

            Assert.Throws<NullReferenceException>(() => _liqPay.CheckCnbParameters(parameters));
        }

        [Fact]
        public void WithBasicApiParams_Succeed()
        {
            var parameters = DefaultTestParameters();

            var fullParams = parameters.WithBasicApiParameters("publicKey");

            Assert.Equal("publicKey", fullParams["public_key"]);
            Assert.Equal("3", fullParams["version"]);
            Assert.Equal("1.5", fullParams["amount"]);
        }

        [Fact]
        public void StringToSign_Succeed()
        {
            Assert.Equal("i0XkvRxqy4i+v2QH0WIF9WfmKj4=", _liqPay.StringToSign("some string"));
        }

        [Fact]
        public void CreateSignature_Succeed()
        {
            var obj = JObject.FromObject(new
            {
                field = "value"
            });

            var encodedData = Convert.ToBase64String(Encoding.ASCII.GetBytes(obj.ToString()));

            Assert.Equal("BCgDax9Rl0aG7CGqjxGDE/mtqxQ=", _liqPay.CreateSignature(encodedData));
        }

        [Fact]
        public void GenerateData_Succeed()
        {
            var invoiceParams = new SortedDictionary<string, string>
            {
                {"email", "client-email@gmail.com"},
                {"amount", "200"},
                {"currency", "USD"},
                {"order_id", "order_id_1" },
                {"goods", "[{amount: 100, count: 2, unit: 'un.', name: 'phone'}]"}
            };

            var generatedData = _liqPay.GenerateData(invoiceParams);

            Assert.Equal("DqcGjvo2aXgt0+zBZECdH4cbPWY=", generatedData["signature"]);
            Assert.Equal(
                "eyJhbW91bnQiOiIyMDAiLCJjdXJyZW5jeSI6IlVTRCIsImVtYWlsIjoiY2xpZW50LWVtYWlsQGdtYWlsLmNvbSIsImdvb2RzIjoiW3thbW91bnQ6IDEwMCwgY291bnQ6IDIsIHVuaXQ6ICd1bi4nLCBuYW1lOiAncGhvbmUnfV0iLCJvcmRlcl9pZCI6Im9yZGVyX2lkXzEiLCJwdWJsaWNfa2V5IjoicHVibGljS2V5IiwidmVyc2lvbiI6IjMifQ==", 
                generatedData["data"]);
        }

        private IDictionary<string, string> DefaultTestParameters(string removedKey = null)
        {
            var parameters = new SortedDictionary<string, string>
            {
                {"language", "en"},
                {"amount", "1.5"},
                {"currency", "USD"},
                {"description", "Description"},
                {"sandbox", "1"}
            };

            if (removedKey != null)
                parameters.Remove(removedKey);

            return parameters;
        }
    }
}
