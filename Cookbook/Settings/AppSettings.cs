using System.Net.NetworkInformation;
using System.Text.Json.Serialization;
using Cookbook.UI.Theme;

namespace Cookbook.Settings;

public class AppSettings
{
    // values
    [JsonPropertyName("token")] public string? Token { get; set; } = string.Empty;
    [JsonPropertyName("theme")] public Theme Theme { get; set; } = new Theme();
    
    // info
    [JsonPropertyName("github")] public string Github { get; set; } = string.Empty;
    [JsonPropertyName("version")] public string Version { get; set; } = string.Empty;
    [JsonPropertyName("description")] public string? Description { get; set; } 
}