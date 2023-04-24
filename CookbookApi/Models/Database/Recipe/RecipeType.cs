using CookbookApi.Models.Blank.Recipe;
using CookbookApi.Models.Domain.Recipe;

namespace CookbookApi.Models.Database.Recipe;

public class RecipeType
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public RecipeType() { }

    public RecipeType(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public RecipeType(RecipeTypeBlank recipeType)
    {
        Name = recipeType.Name;
    }
    
    public RecipeType(RecipeTypeDomain recipeType)
    {
        Id = recipeType.Id;
        Name = recipeType.Name;
    }
}