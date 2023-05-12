using System.Text.Json.Serialization;

namespace BlankModels.Recipe.Ingredient;

public class MeasureBlank
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}