using System.Text.Json.Serialization;
using Cookbook.Models.Domain.Recipe;

namespace Cookbook.Models.Blank.Recipe;

public class RecipeTypeBlank
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    public RecipeTypeBlank() { }

    public RecipeTypeBlank(string name)
    {
        Name = name;
    }

    public RecipeTypeBlank(RecipeTypeDomain recipeType)
    {
        Name = recipeType.Name;
    }
}