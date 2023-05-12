using System.Text.Json.Serialization;

namespace Models.Domain.Recipe.Category;

public class CategoryDomain
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}