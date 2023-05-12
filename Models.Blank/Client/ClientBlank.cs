using System.Text.Json.Serialization;

namespace Models.Blank.Client;

public class ClientBlank
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    [JsonPropertyName("email")]
    public string? Email { get; set; }
}