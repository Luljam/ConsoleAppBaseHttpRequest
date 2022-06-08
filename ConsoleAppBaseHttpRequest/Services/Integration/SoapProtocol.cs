using System;
using System.Net.Http;
using System.Text;

namespace ConsoleAppBaseHttpRequest.Services.Integration
{
    public sealed class SoapProtocol : BaseHttpRequest, IHttpProtocol
    {
        public string HttpRequest(HttpBodyRequest httpBodyRequest)
        {
            //WebRequest request = WebRequest.Create(httpBodyRequest.Url);
            //request.Method = httpBodyRequest.Method;
            //request.ContentType = httpBodyRequest.ContentType;
            //foreach (var header in httpBodyRequest.Header)
            //{
            //    request.Headers.Add(header.Key, header.Value);
            //}

            //XmlDocument SOAPReqBody = new XmlDocument();
            //SOAPReqBody.LoadXml(httpBodyRequest.Body);

            //using (Stream stream = request.GetRequestStream())
            //{
            //    SOAPReqBody.Save(stream);
            //}

            //var response = GetHttpWebRequest(request);

            //return response;
            string responseString = String.Empty;
            StringContent postContet = new StringContent(httpBodyRequest.Body, Encoding.UTF8, "text/xml");

            using (var client = new HttpClient())
            {
                var response = client.PostAsync(httpBodyRequest.Url, postContet).Result;
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;

                    // by calling .Result you are synchronously reading the result
                    responseString = responseContent.ReadAsStringAsync().Result;
                }
            }

            return responseString;
        }
    }
}
