using CookbookApi.Models.Blank.Recipe;
using CookbookApi.Models.Domain.Recipe.Category;

namespace CookbookApi.Models.Domain.Recipe;

public class RecipeDomain
{
    public int ClientId { get; set; }

    public int TypeId { get; set; }

    public string Header { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? Code { get; set; }
    
    public string? SourceUrl { get; set; }
    
    public bool IsLiked { get; set; }

    public RecipeTypeDomain RecipeType { get; set; } = new RecipeTypeDomain();
    
    public RecipeStatsDomain Stats { get; set; } = new RecipeStatsDomain();

    public List<RecipeIngredientDomain> Ingredients { get; set; } = new List<RecipeIngredientDomain>();

    public List<CategoryDomain> Categories { get; set; } = new List<CategoryDomain>();

    public List<string> Images { get; set; } = new List<string>();

    public RecipeDomain() { }

    public RecipeDomain(Database.Recipe.Recipe recipe)
    {
        ClientId = recipe.ClientId;
        SourceUrl = recipe.SourceUrl;
        TypeId = recipe.TypeId;
        Header = recipe.Header;
        Description = recipe.Description;
        Code = recipe.Code;
    }
    
    public RecipeDomain(RecipeBlank recipe)
    {
        TypeId = recipe.TypeId;
        Header = recipe.Header;
        SourceUrl = recipe.SourceUrl;
        Description = recipe.Description;
    }
}