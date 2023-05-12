using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models.Blank.Recipe.Ingredient;

public class RecipeIngredientBlank
{
    [JsonPropertyName("ingredientId")]
    public int IngredientId { get; set; }
    
    [JsonPropertyName("measureId")]
    public int MeasureId { get; set; }
    
    [JsonPropertyName("count")]
    public decimal Count { get; set; }
}