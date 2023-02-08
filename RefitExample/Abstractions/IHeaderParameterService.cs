using RefitExample.Models.Response;

namespace RefitExample.Abstractions
{
    public interface IHeaderParameterService
    {
        LoginResponseDto GetResponse();
        string GetToken();
    }
}
