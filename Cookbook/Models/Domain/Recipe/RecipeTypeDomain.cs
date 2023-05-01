using System.Text.Json.Serialization;
using Cookbook.Models.Blank.Recipe;

namespace Cookbook.Models.Domain.Recipe;

public class RecipeTypeDomain
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
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

}