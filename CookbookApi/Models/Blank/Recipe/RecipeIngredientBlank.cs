using CookbookApi.Models.Database.Recipe;
using CookbookApi.Models.Domain.Recipe;

namespace CookbookApi.Models.Blank.Recipe;

public class RecipeIngredientBlank
{
    public int IngredientId { get; set; }
    
    public int RecipeId { get; set; }
    
    public decimal Count { get; set; } = 1;

    public RecipeIngredientBlank()  { }

    public RecipeIngredientBlank(int ingredientId, int recipeId, decimal count)
    {
        IngredientId = ingredientId;
        RecipeId = RecipeId;
        Count = count;
    }

    public RecipeIngredientBlank(RecipeIngredient recipeIngredient)
    {
        IngredientId = recipeIngredient.IngredientId;
        RecipeId = recipeIngredient.RecipeId;
        Count = recipeIngredient.Count;
    }
    
    public RecipeIngredientBlank(RecipeIngredientDomain recipeIngredient)
    {
        IngredientId = recipeIngredient.Ingredient.Id;
        RecipeId = recipeIngredient.RecipeId;
        Count = recipeIngredient.Count;
    }
}