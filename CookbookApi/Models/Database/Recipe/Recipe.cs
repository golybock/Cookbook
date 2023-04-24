using CookbookApi.Models.Domain.Recipe;

namespace CookbookApi.Models.Database.Recipe;

public partial class Recipe
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int TypeId { get; set; }

    public string Header { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? PathToText { get; set; }
    
    public string? Code { get; set; }

    public Recipe() { }

    public Recipe(RecipeDomain recipe)
    {
        ClientId = recipe.ClientId;
        TypeId = recipe.TypeId;
        Header = recipe.Header;
        Description = recipe.Description;
        Code = recipe.Code;
        
    }
}