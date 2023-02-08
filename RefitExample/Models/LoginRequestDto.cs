using System.Text.Json.Serialization;

namespace RefitExample.Models
{
    public class LoginRequestDto
    {
        [JsonPropertyName("userName")] public string? UserName { get; set; }
        [JsonPropertyName("password")] public string? Password { get; set; }
    }
}
