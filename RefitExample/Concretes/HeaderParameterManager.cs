using RefitExample.Abstractions;
using RefitExample.Models;
using RefitExample.Models.Response;

namespace RefitExample.Concretes
{
    public class HeaderParameterManager : IHeaderParameterService
    {
        private readonly IConfiguration _configuration;
        private readonly ILoginService _loginService;

        public HeaderParameterManager(IConfiguration configuration, ILoginService loginService)
        {
            _configuration = configuration;
            _loginService = loginService;
        }

        private static string? Token { get; set; }
        public LoginResponseDto GetResponse()
        {
            LoginRequestDto dto = _configuration.GetSection("RefitLogin").Get<LoginRequestDto>();
            var result = _loginService.Login(dto);
            return result.Result;
        }

        public string GetToken()
        {
            if (string.IsNullOrWhiteSpace(Token))
            {
                var result = GetResponse();
                Token = result.Token;
            }
            return Token;
        }
    }
}
