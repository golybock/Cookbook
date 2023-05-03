using System.Text.Json.Serialization;
using Domain.Recipe;

namespace Blank.Recipe;

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