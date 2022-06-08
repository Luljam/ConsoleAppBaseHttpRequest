using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace ConsoleAppBaseHttpRequest.Services.Integration
{
    public sealed class RestProtocol : BaseHttpRequest, IHttpProtocol
    {
        public string HttpRequest(HttpBodyRequest httpBodyRequest)
        {
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(httpBodyRequest.Url);
            //request.Method = httpBodyRequest.Method;
            //request.ContentType = httpBodyRequest.ContentType;
            //foreach (var header in httpBodyRequest.Header)
            //{
            //    request.Headers.Add(header.Key, header.Value);
            //}

            //byte[] byteArray = Encoding.UTF8.GetBytes(httpBodyRequest.Body);

            //using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            //{
            //    streamWriter.Write(byteArray);
            //}

            //var response = GetHttpWebRequest(request);
            string responseString = String.Empty;

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(httpBodyRequest.Url).Result;
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
