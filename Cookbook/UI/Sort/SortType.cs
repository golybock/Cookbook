using System.Text.Json.Serialization;

namespace Cookbook.UI.Sort;

public class SortType
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
}