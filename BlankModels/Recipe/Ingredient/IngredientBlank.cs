using System.Text.Json.Serialization;

namespace BlankModels.Recipe.Ingredient;

public class IngredientBlank
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}