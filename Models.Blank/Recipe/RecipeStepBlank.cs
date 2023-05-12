using System.Text.Json.Serialization;

namespace BlankModels.Recipe;

public class RecipeStepBlank
{
    [JsonPropertyName("number")]
    public int Number { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;
}