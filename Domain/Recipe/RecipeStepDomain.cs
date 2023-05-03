using System.Text.Json.Serialization;

namespace Domain.Recipe;

public class RecipeStepDomain
{
    [JsonPropertyName("recipeId")]
    public int RecipeId { get; set; }
    [JsonPropertyName("number")]
    public int Number { get; set; }
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;

    public RecipeStepDomain() { }

    public RecipeStepDomain(RecipeStepBlank recipeStep)
    {
        RecipeId = recipeStep.RecipeId;
        Number = recipeStep.Number;
        Text = recipeStep.Text;
    }
}