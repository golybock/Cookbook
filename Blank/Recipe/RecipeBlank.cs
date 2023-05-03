using System.Text.Json.Serialization;
using Blank.Recipe.Category;

namespace Blank.Recipe;

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
    public RecipeStatsBlank? RecipeStats { get; set; }

    [JsonPropertyName("ingredients")]
    public List<RecipeIngredientBlank> Ingredients { get; set; } = new List<RecipeIngredientBlank>();

    [JsonPropertyName("categories")]
    public List<RecipeCategoryBlank> Categories { get; set; } = new List<RecipeCategoryBlank>();

    [JsonPropertyName("steps")] public List<RecipeStepBlank> Steps { get; set; } = new List<RecipeStepBlank>();
    
}