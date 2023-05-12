using System.Text.Json.Serialization;

namespace BlankModels.Client;

public class ClientBlank
{
    [JsonPropertyName("roleId")]
    public int RoleId { get; set; }
    [JsonPropertyName("login")]
    public string Login { get; set; } = string.Empty;
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    [JsonPropertyName("email")]
    public string? Email { get; set; }
    [JsonPropertyName("imagePath")]
    public string? ImagePath { get; set; }
}