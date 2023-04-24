using CookbookApi.Models.Blank.Recipe.Category;
using CookbookApi.Models.Blank.Recipe.Ingredient;
using CookbookApi.Models.Domain.Recipe;

namespace CookbookApi.Models.Blank.Recipe;

public class RecipeBlank
{
    public int TypeId { get; set; }

    public string Header { get; set; } = string.Empty;

    public string? Description { get; set; }
    
    public RecipeStatsBlank? RecipeStats { get; set; }

    public List<RecipeIngredientBlank> Ingredients { get; set; } = new List<RecipeIngredientBlank>();

    public List<RecipeCategoryBlank> Categories { get; set; } = new List<RecipeCategoryBlank>();

    public RecipeBlank() { }

    public RecipeBlank(RecipeDomain recipe)
    {
        TypeId = recipe.TypeId;
        Header = recipe.Header;
        Description = recipe.Description;
        RecipeStats = new(recipe.Stats);

        Categories = recipe.Categories
            .Select(c => new RecipeCategoryBlank(c))
            .ToList();
        
        Ingredients = recipe.Ingredients
            .Select(c => new RecipeIngredientBlank(c))
            .ToList();
    }
    
    public RecipeBlank(Database.Recipe.Recipe recipe)
    {
        TypeId = recipe.TypeId;
        Header = recipe.Header;
        Description = recipe.Description;
    }
}