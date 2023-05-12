using System.Text.Json.Serialization;
using Models.Domain.Recipe.Ingredient;

namespace Models.Domain.Recipe;

public class RecipeIngredientDomain
{
    [JsonPropertyName("ingredientId")]
    public int IngredientId { get; set; }
    
    [JsonPropertyName("ingredient")]
    public IngredientDomain? Ingredient { get; set; }
    
    [JsonPropertyName("measureId")]
    public int MeasureId { get; set; }
    
    [JsonPropertyName("measure")]
    public MeasureDomain? Measure { get; set; }
    
    [JsonPropertyName("count")]
    public decimal Count { get; set; }
}