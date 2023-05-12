using System.Text.Json.Serialization;

namespace BlankModels.Recipe.Category;

public class CategoryBlank
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}