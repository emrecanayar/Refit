using Refit;
using RefitExample.Models;
using RefitExample.Models.Response;

namespace RefitExample.Abstractions
{
    [Headers("Content-Type: application/json")]
    public interface ILoginService
    {
        [Post("/auth/login")]
        Task<LoginResponseDto> Login([Body] LoginRequestDto dto);
    }
}