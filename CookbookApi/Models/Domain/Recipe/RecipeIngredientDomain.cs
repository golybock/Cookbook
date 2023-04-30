using CookbookApi.Models.Blank.Recipe;
using CookbookApi.Models.Database.Recipe;
using CookbookApi.Models.Domain.Recipe.Ingredient;

namespace CookbookApi.Models.Domain.Recipe;

public class RecipeIngredientDomain
{
    public int RecipeId { get; set; }
    
    public int IngredientId { get; set; }
    
    public IngredientDomain? Ingredient { get; set; } = new IngredientDomain();

    public decimal Count { get; set; }

    public RecipeIngredientDomain() { }

    public RecipeIngredientDomain(RecipeIngredient recipeIngredient)
    {
        RecipeId = recipeIngredient.RecipeId;
        IngredientId = recipeIngredient.IngredientId;
        Count = recipeIngredient.Count;
    }
    
    public RecipeIngredientDomain(RecipeIngredientBlank recipeIngredient)
    {
        IngredientId = recipeIngredient.IngredientId;
        Count = recipeIngredient.Count;
    }
}