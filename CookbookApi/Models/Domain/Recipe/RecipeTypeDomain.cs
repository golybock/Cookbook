using CookbookApi.Models.Blank.Recipe;
using CookbookApi.Models.Database.Recipe;

namespace CookbookApi.Models.Domain.Recipe;

public class RecipeTypeDomain
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public RecipeTypeDomain() { }

    public RecipeTypeDomain(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public RecipeTypeDomain(RecipeTypeBlank recipeType)
    {
        Name = recipeType.Name;
    }
    
    public RecipeTypeDomain(RecipeType recipeType)
    {
        Id = recipeType.Id;
        Name = recipeType.Name;
    }
}