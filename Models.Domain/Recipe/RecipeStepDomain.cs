using System.Text.Json.Serialization;

namespace Models.Domain.Recipe;

public class RecipeStepDomain
{
    [JsonPropertyName("number")]
    public int Number { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;
}