using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppBaseHttpRequest.Services.Integration
{
    public sealed class HttpIntegration
    {
        readonly IHttpProtocol _httpProtocol;

        public HttpIntegration(IHttpProtocol httpProtocol)
        {
            _httpProtocol = httpProtocol;
        }

        public async Task<string> DoBusinessLogic(HttpBodyRequest request)
        {
            return await _httpProtocol.HttpRequest(request);
        }
    }
}