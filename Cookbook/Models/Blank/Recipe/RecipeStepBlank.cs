using System.Text.Json.Serialization;
using Cookbook.Models.Domain.Recipe;

namespace Cookbook.Models.Blank.Recipe;

public class RecipeStepBlank
{
    [JsonPropertyName("recipeId")]
    public int RecipeId { get; set; }
    [JsonPropertyName("number")]
    public int Number { get; set; }
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;

    public RecipeStepBlank() { }

    public RecipeStepBlank(RecipeStepDomain recipeStep)
    {
        RecipeId = recipeStep.RecipeId;
        Number = recipeStep.Number;
        Text = recipeStep.Text;
    }
}