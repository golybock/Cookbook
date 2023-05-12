using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Models.Blank.Recipe.Category;
using Models.Blank.Recipe.Ingredient;

namespace Models.Blank.Recipe;

public class RecipeBlank
{
    [StringLength(150)]
    [JsonPropertyName("header")] 
    public string Header { get; set; } = string.Empty;
    
    [JsonPropertyName("bju")] 
    public RecipeBjuBlank? Bju { get; set; }
    
    [JsonPropertyName("info")] 
    public RecipeInfoBlank? Info { get; set; }

    [JsonPropertyName("categories")]
    public List<RecipeCategoryBlank> Categories { get; set; } = new List<RecipeCategoryBlank>();

    [JsonPropertyName("ingredients")]
    public List<RecipeIngredientBlank> Ingredients { get; set; } = new List<RecipeIngredientBlank>();

    [JsonPropertyName("steps")]
    public List<RecipeStepBlank> Steps { get; set; } = new List<RecipeStepBlank>();
}