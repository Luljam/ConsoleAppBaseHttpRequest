using ConsoleAppBaseHttpRequest.Services.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppBaseHttpRequest.Services
{
    public class Service : IService
    {
        public string SendCommand(HttpBodyRequest request)
        {
            IHttpProtocol httpSoap = new SoapProtocol();
            HttpIntegration integrationSoap = new HttpIntegration(httpSoap);

            return integrationSoap.DoBusinessLogic(request);
        }
    }
}
