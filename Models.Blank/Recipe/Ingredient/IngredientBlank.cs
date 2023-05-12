using System.Text.Json.Serialization;

namespace Models.Blank.Recipe.Ingredient;

public class IngredientBlank
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}