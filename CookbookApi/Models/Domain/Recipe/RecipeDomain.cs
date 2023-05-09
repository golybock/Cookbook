using CookbookApi.Models.Blank.Recipe;
using CookbookApi.Models.Domain.Recipe.Category;

namespace CookbookApi.Models.Domain.Recipe;

public class RecipeDomain
{
    public int ClientId { get; set; }

    public string? ClientOwner { get; set; }
    
    public int TypeId { get; set; }

    public string Header { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? Code { get; set; }
    
    public string? SourceUrl { get; set; }
    
    public string? ImagePath { get; set; }
    
    public bool IsLiked { get; set; }

    public RecipeTypeDomain? RecipeType { get; set; } = new RecipeTypeDomain();
    
    public RecipeStatsDomain? Stats { get; set; } = new RecipeStatsDomain();

    public List<RecipeIngredientDomain> Ingredients { get; set; } = new List<RecipeIngredientDomain>();

    public List<CategoryDomain> Categories { get; set; } = new List<CategoryDomain>();

    public List<RecipeStepDomain> Steps { get; set; } = new List<RecipeStepDomain>();

    public RecipeDomain() { }

    public RecipeDomain(Database.Recipe.Recipe recipe)
    {
        ClientId = recipe.ClientId;
        SourceUrl = recipe.SourceUrl;
        ImagePath = recipe.ImagePath;
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