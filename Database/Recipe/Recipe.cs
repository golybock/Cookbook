namespace Database.Recipe;

public partial class Recipe
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int TypeId { get; set; }

    public string Header { get; set; } = string.Empty;

    public string? Description { get; set; }
    
    public string? ImagePath { get; set; }

    public string? SourceUrl { get; set; }
    public string? Code { get; set; }

    public Recipe() { }

    public Recipe(RecipeDomain recipe)
    {
        ClientId = recipe.ClientId;
        TypeId = recipe.TypeId;
        Header = recipe.Header;
        Description = recipe.Description;
        SourceUrl = recipe.SourceUrl;
        Code = recipe.Code;
    }
    
    public Recipe(RecipeBlank recipe)
    {
        TypeId = recipe.TypeId;
        Header = recipe.Header;
        SourceUrl = recipe.SourceUrl;
        Description = recipe.Description;
    }
}