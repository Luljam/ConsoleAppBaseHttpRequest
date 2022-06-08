using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppBaseHttpRequest.Services.Integration
{
    public interface IHttpProtocol
    {
        string HttpRequest(HttpBodyRequest httpBodyRequest);
    }
}
