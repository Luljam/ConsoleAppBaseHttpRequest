using ConsoleAppBaseHttpRequest.Services.Integration;
using System.Threading.Tasks;

namespace ConsoleAppBaseHttpRequest.Services
{
    public interface IService
    {
        Task<string> SendCommand(HttpBodyRequest request, IHttpProtocol httpSoap);
    }
}
