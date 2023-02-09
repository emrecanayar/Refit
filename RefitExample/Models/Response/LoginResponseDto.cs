using Newtonsoft.Json;

namespace RefitExample.Models.Response
{
    public class LoginResponseDto
    {
        //Login olma işlemi sonucunda geriye dönen response model için oluşturulmuş örnek bir class
        [JsonProperty(PropertyName = "userId")] public int UserId { get; set; }
        [JsonProperty(PropertyName = "token")] public string? Token { get; set; }
        [JsonProperty(PropertyName = "expireTime")] public int ExpireTime { get; set; }
        [JsonProperty(PropertyName = "customer")] public List<object>? Customer { get; set; }
        [JsonProperty(PropertyName = "refreshToken")] public string? RefreshToken { get; set; }
    }
}
