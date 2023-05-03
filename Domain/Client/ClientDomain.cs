using System.Text.Json.Serialization;
using Domain.Recipe;

namespace Domain.Client;

public class ClientDomain
{
    [JsonPropertyName("login")]
    public string? Login { get; set; } = null!;
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    [JsonPropertyName("recipes")]
    public List<RecipeDomain> Recipes { get; set; } = new List<RecipeDomain>();
    [JsonPropertyName("email")]
    public string? Email { get; set; }
    [JsonPropertyName("imagePath")]
    public string? ImagePath { get; set; }
    
    public ClientDomain() { }

    public ClientDomain(ClientBlank client)
    {
        Login = client.Login;
        Name = client.Name;
        Email = client.Email;
        Description = client.Description;
    }
}