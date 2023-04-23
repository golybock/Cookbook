namespace CookbookApi.Models.Domain.Recipe;

public class RecipeDomain
{
    public int ClientId { get; set; }

    public int TypeId { get; set; }

    public string Header { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? Code { get; set; }

    public RecipeTypeDomain RecipeType { get; set; } = new RecipeTypeDomain();
    
    public RecipeStatsDomain RecipeStats { get; set; } = new RecipeStatsDomain();

    public List<RecipeIngredientDomain> RecipeIngredients { get; set; } = new List<RecipeIngredientDomain>();

    public List<string> Images { get; set; } = new List<string>();
}