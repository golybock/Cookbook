using CookbookApi.Models.Blank.Recipe.Category;

namespace CookbookApi.Models.Blank.Recipe;

public class RecipeBlank
{
    public int TypeId { get; set; }

    public string Header { get; set; } = string.Empty;

    public string? Description { get; set; }
    
    public RecipeStatsBlank? RecipeStats { get; set; }

    public List<RecipeIngredientBlank> Ingredients { get; set; } = new List<RecipeIngredientBlank>();

    public List<RecipeCategoryBlank> Categories { get; set; } = new List<RecipeCategoryBlank>();
}