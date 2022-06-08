using ConsoleAppBaseHttpRequest.Services.Integration;

namespace ConsoleAppBaseHttpRequest.Services
{
    public interface IService
    {
        string SendCommand(HttpBodyRequest request);
    }
}
