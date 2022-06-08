using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppBaseHttpRequest.Services.Integration
{
    public class HttpBodyRequest
    {
        public Dictionary<string, string> Header { get; set; }
        public string Method { get; set; }
        public string Body { get; set; }
        public string Url { get; set; }
        public string ContentType { get; set; }
    }
}
