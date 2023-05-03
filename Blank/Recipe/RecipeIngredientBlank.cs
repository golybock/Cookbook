using System.Text.Json.Serialization;
using Domain.Recipe;

namespace Blank.Recipe;

public class RecipeIngredientBlank
{
    [JsonPropertyName("ingredientId")]
    public int IngredientId { get; set; }
    [JsonPropertyName("count")]
    public decimal Count { get; set; } = 1;

    public RecipeIngredientBlank()  { }

    public RecipeIngredientBlank(int ingredientId, int recipeId, decimal count)
    {
        IngredientId = ingredientId;
        Count = count;
    }

    public RecipeIngredientBlank(RecipeIngredientDomain recipeIngredient)
    {
        IngredientId = recipeIngredient.Ingredient.Id;
        Count = recipeIngredient.Count;
    }
}