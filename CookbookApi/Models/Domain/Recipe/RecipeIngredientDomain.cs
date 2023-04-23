using CookbookApi.Models.Domain.Recipe.Ingredient;

namespace CookbookApi.Models.Domain.Recipe;

public class RecipeIngredientDomain
{
    public IngredientDomain Ingredient { get; set; } = new IngredientDomain();

    public decimal Count { get; set; }
}