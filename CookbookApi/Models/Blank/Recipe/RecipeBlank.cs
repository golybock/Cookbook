using CookbookApi.Models.Blank.Recipe.Category;
using CookbookApi.Models.Blank.Recipe.Ingredient;
using CookbookApi.Models.Domain.Recipe;

namespace CookbookApi.Models.Blank.Recipe;

public class RecipeBlank
{
    public int TypeId { get; set; }

    public string Header { get; set; } = string.Empty;

    public string? Description { get; set; }
    
    public string? SourceUrl { get; set; }
    
    public RecipeStatsBlank? RecipeStats { get; set; }

    public List<RecipeIngredientBlank> Ingredients { get; set; } = new List<RecipeIngredientBlank>();

    public List<RecipeCategoryBlank> Categories { get; set; } = new List<RecipeCategoryBlank>();

    public List<RecipeStepBlank> Steps { get; set; } = new List<RecipeStepBlank>();

    public RecipeBlank() { }

    public RecipeBlank(RecipeDomain recipe)
    {
        TypeId = recipe.TypeId;
        Header = recipe.Header;
        Description = recipe.Description;
        SourceUrl = recipe.SourceUrl;
        RecipeStats = new(recipe.Stats);

        Categories = recipe.Categories
            .Select(c => new RecipeCategoryBlank(c))
            .ToList();
    }
    
    public RecipeBlank(Database.Recipe.Recipe recipe)
    {
        TypeId = recipe.TypeId;
        Header = recipe.Header;
        SourceUrl = recipe.SourceUrl;
        Description = recipe.Description;
    }
}