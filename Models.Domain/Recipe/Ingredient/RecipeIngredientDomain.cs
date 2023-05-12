using System.Text.Json.Serialization;

namespace Models.Domain.Recipe.Ingredient;

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