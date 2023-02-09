using Refit;
using RefitExample.Models;
using RefitExample.Models.Response;

namespace RefitExample.Abstractions
{
    [Headers("Content-Type: application/json")]
    public interface ILoginClient
    {
        //Örnek bir login metodu isteğimizi body kısmında bu şekilde belirlediğiniz model ile gönderebiliyoruz. Yine geriye dönüş tipimizi de metotta yer aldığı gibi belirtebiliyoruz.
        [Post("/auth/login")]
        Task<LoginResponseDto> Login([Body] LoginRequestDto dto);
    }
}