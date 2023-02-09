using System.Text.Json.Serialization;

namespace RefitExample.Models
{
    public class LoginRequestDto
    {
        //Login olurken body kısmında göndereceğimiz örnek  request in modeli 
        //Burada eğer direkt olarak class içerisinde yer alan propertyleri göndermede sorun yaşarsanız amacına uygun olması yani json yapısına uygun olması için JsonPropertyName attribute kullanarak class içerisinde yer alan propertylere json formatta isim verebilirsiniz.
        [JsonPropertyName("userName")] public string? UserName { get; set; }
        [JsonPropertyName("password")] public string? Password { get; set; }
    }
}
