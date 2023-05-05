using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Cookbook.Models.Blank.Recipe.Category;
using Cookbook.Models.Domain.Recipe;

namespace Cookbook.Models.Blank.Recipe;

public class RecipeBlank
{
    [JsonPropertyName("typeId")] 
    public int TypeId { get; set; }
    [JsonPropertyName("header")] 
    public string Header { get; set; } = string.Empty;
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    [JsonPropertyName("sourceUrl")] 
    public string? SourceUrl { get; set; }
    [JsonPropertyName("recipeStats")] 
    public RecipeStatsBlank? Stats { get; set; }

    [JsonPropertyName("ingredients")]
    public List<RecipeIngredientBlank> Ingredients { get; set; } = new List<RecipeIngredientBlank>();

    [JsonPropertyName("categories")]
    public List<RecipeCategoryBlank> Categories { get; set; } = new List<RecipeCategoryBlank>();

    [JsonPropertyName("steps")] public List<RecipeStepBlank> Steps { get; set; } = new List<RecipeStepBlank>();

    public RecipeBlank()
    {
    }

    public RecipeBlank(RecipeDomain recipe)
    {
        TypeId = recipe.TypeId;
        Header = recipe.Header;
        Description = recipe.Description;
        SourceUrl = recipe.SourceUrl;

        if (recipe.Stats != null) 
            Stats = new RecipeStatsBlank(recipe.Stats);

        Categories = recipe.Categories
            .Select(c => new RecipeCategoryBlank(c))
            .ToList();

        Ingredients = recipe.Ingredients
            .Select(c => new RecipeIngredientBlank(c))
            .ToList();

        Steps = recipe.Steps
            .Select(c => new RecipeStepBlank(c))
            .ToList();
    }
}