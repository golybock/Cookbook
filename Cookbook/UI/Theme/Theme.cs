using System.Text.Json.Serialization;

namespace Cookbook.UI.Theme;

public class Theme
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
}