using System.Text.Json.Serialization;

namespace Blank.Client;

public class ClientBlank
{
    [JsonPropertyName("login")]
    public string? Login { get; set; } = string.Empty;
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    [JsonPropertyName("email")]
    public string? Email { get; set; }
}