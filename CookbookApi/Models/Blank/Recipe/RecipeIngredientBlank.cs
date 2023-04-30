using CookbookApi.Models.Database.Recipe;
using CookbookApi.Models.Domain.Recipe;

namespace CookbookApi.Models.Blank.Recipe;

public class RecipeIngredientBlank
{
    public int IngredientId { get; set; }
    
    public decimal Count { get; set; } = 1;

    public RecipeIngredientBlank()  { }

    public RecipeIngredientBlank(int ingredientId, int recipeId, decimal count)
    {
        IngredientId = ingredientId;
        Count = count;
    }

    public RecipeIngredientBlank(RecipeIngredient recipeIngredient)
    {
        IngredientId = recipeIngredient.IngredientId;
        Count = recipeIngredient.Count;
    }
    
    public RecipeIngredientBlank(RecipeIngredientDomain recipeIngredient)
    {
        IngredientId = recipeIngredient.Ingredient.Id;
        Count = recipeIngredient.Count;
    }
}