using System.Text.Json.Serialization;

namespace Models.Blank.Recipe.Category;

public class CategoryBlank
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}