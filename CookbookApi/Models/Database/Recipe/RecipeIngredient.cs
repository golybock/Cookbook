using CookbookApi.Models.Blank.Recipe;
using CookbookApi.Models.Domain.Recipe;

namespace CookbookApi.Models.Database.Recipe;

public class RecipeIngredient
{
    public int Id { get; set; }

    public int RecipeId { get; set; }

    public int IngredientId { get; set; }
    
    public decimal Count { get; set; }

    public RecipeIngredient() { }

    public RecipeIngredient(RecipeIngredientBlank recipeIngredient)
    {
        IngredientId = recipeIngredient.IngredientId;
        Count = recipeIngredient.Count;
    }
    
    public RecipeIngredient(RecipeIngredientDomain recipeIngredient)
    {
        IngredientId = recipeIngredient.IngredientId;
        RecipeId = recipeIngredient.RecipeId;
        Count = recipeIngredient.Count;
    }
}
