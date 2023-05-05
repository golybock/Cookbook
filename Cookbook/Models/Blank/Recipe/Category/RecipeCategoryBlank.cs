using System.Text.Json.Serialization;
using Cookbook.Models.Domain.Recipe.Category;

namespace Cookbook.Models.Blank.Recipe.Category;

public class RecipeCategoryBlank
{
    [JsonPropertyName("categoryId")] public int CategoryId { get; set; }
    [JsonPropertyName("recipeId")] public int RecipeId { get; set; }

    [JsonIgnore]
    public string Name { get; set; }

    public RecipeCategoryBlank() { }

    public RecipeCategoryBlank(int categoryId, int recipeId)
    {
        RecipeId = recipeId;
        CategoryId = categoryId;
    }
    
    public RecipeCategoryBlank(CategoryDomain recipeCategory)
    {
        CategoryId = recipeCategory.Id;
        Name = recipeCategory.Name;
    }

}