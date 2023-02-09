using RefitExample.Abstractions;
using RefitExample.Models;
using RefitExample.Models.Response;

namespace RefitExample.Concretes
{
    public class HeaderParameterManager : IHeaderParameterService
    {
        private readonly IConfiguration _configuration;
        private readonly ILoginClient _loginClient;

        public HeaderParameterManager(IConfiguration configuration, ILoginClient loginClient)
        {
            _configuration = configuration;
            _loginClient = loginClient;
        }

        private static string? Token { get; set; }
        public LoginResponseDto GetResponse()
        {
            LoginRequestDto dto = _configuration.GetSection("RefitLogin").Get<LoginRequestDto>();
            var result = _loginClient.Login(dto);
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
