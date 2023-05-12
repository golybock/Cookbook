using System.Text.Json.Serialization;

namespace Models.Domain.Client;

public class ClientRoleDomain
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}