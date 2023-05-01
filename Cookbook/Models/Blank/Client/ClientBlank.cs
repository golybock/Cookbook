using System.Text.Json.Serialization;
using Cookbook.Models.Domain.Client;

namespace Cookbook.Models.Blank.Client;

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
    
    public ClientBlank() { }

    public ClientBlank(ClientDomain client)
    {
        Login = client.Login;
        Name = client.Name;
        Email = client.Email;
        Description = client.Description;
    }
}