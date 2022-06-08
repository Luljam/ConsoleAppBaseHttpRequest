using ConsoleAppBaseHttpRequest.Services;
using ConsoleAppBaseHttpRequest.Services.Integration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ConsoleAppBaseHttpRequest
{
    internal class Program : BaseHttpRequest
    {
        static async Task Main(string[] args)
        {
           await SoapRequest(2);
            RestRequest();

            Console.Read();
        }

        public static async Task SoapRequest(int number)
        {
            HttpBodyRequest request = new HttpBodyRequest
            {
                Method = "Post",
                Body = @"<?xml version=""1.0"" encoding=""utf-8""?>
                        <soap:Envelope xmlns:soap = ""http://schemas.xmlsoap.org/soap/envelope/"">
                          <soap:Body>
                            <NumberToWords xmlns = ""http://www.dataaccess.com/webservicesserver/"">
                              <ubiNum>" + number + @"</ubiNum>
                            </NumberToWords>
                          </soap:Body>
                        </soap:Envelope>",
                Url = "https://www.dataaccess.com/webservicesserver/NumberConversion.wso",
                ContentType = "text/xml;charset=\"utf-8\"",
                Header = GetHeaderSoap()
            };


            Service service = new Service();
            IHttpProtocol httpSoap = new SoapProtocol();
            //var soap = new SoapProtocol();
            var response = await service.SendCommand(request, httpSoap);

            //var response = soap.HttpRequest(request);
            Console.WriteLine("\n Response Soap");
            Console.WriteLine(response);
        }

        public static void RestRequest()
        {
            try
            {
                HttpBodyRequest request = new HttpBodyRequest
                {
                    Method = "Post",
                    Body = "This is a test that posts this string to a Web server.",
                    Url = "http://www.contoso.com/PostAccepter.aspx",
                    ContentType = "application/json",
                    Header = GetHeaderRest()
                };

                var rest = new RestProtocol();
                var response = rest.HttpRequest(request);

                Console.WriteLine("\n Response Rest");
                Console.WriteLine(response);

            }
            catch (WebException we)
            {
                Console.WriteLine(we.Message);
            }
        }

        private static Dictionary<string, string> GetHeaderSoap()
        {
            Dictionary<string, string> Header = new Dictionary<string, string>
            {
                { "Pragma", "no-cache" },
                { "Cache-Control", "no-cache" }
            };
            return Header;
        }

        private static Dictionary<string, string> GetHeaderRest()
        {
            Dictionary<string, string> Headder = new Dictionary<string, string>
            {
                { "Pragma", "no-cache" },
                { "Cache-Control", "no-cache" }
            };
            return Headder;
        }
    }
}
