using RefitExample.Models.Response;

namespace RefitExample.Abstractions
{
    //Bir end-pointe istekte bulunacaksak eğer ve header tarafında göndermemiz gereken yapılar varsa onları toplu bir şekilde burada toplayıp daha sonra konfigruasyon yaptığımız yerde her istek için direkt olarak gönderebiliriz.
    public interface IHeaderParameterService
    {
        LoginResponseDto GetResponse();
        string GetToken();
    }
}
