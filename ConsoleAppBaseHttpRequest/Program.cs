using ConsoleAppBaseHttpRequest.Services;
using ConsoleAppBaseHttpRequest.Services.Integration;
using System;
using System.Collections.Generic;
using System.Net;

namespace ConsoleAppBaseHttpRequest
{
    internal class Program : BaseHttpRequest
    {
        static void Main(string[] args)
        {
            //creating object of program class to access methods
            SoapRequest(2);
            RestRequest();

            Console.Read();
        }

        public static void SoapRequest(int number)
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
            //var soap = new SoapProtocol();
            var response = service.SendCommand(request);

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
