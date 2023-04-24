using CookbookApi.Models.Database.Recipe;
using CookbookApi.Models.Domain.Recipe;

namespace CookbookApi.Models.Blank.Recipe;

public class RecipeTypeBlank
{
    public string Name { get; set; } = string.Empty;

    public RecipeTypeBlank() { }

    public RecipeTypeBlank(string name)
    {
        Name = name;
    }

    public RecipeTypeBlank(RecipeType recipeType)
    {
        Name = recipeType.Name;
    }
    
    public RecipeTypeBlank(RecipeTypeDomain recipeType)
    {
        Name = recipeType.Name;
    }
}