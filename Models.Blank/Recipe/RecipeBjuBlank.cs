using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models.Blank.Recipe;

public class RecipeBjuBlank
{
    [Range(0, double.MaxValue)]
    [JsonPropertyName("fats")]
    public decimal Fats { get; set; }
    
    [Range(0, double.MaxValue)]
    [JsonPropertyName("squirrels")]
    public decimal Squirrels { get; set; }
    
    [Range(0, double.MaxValue)]
    [JsonPropertyName("carbohydrates")]
    public decimal Carbohydrates { get; set; }
    
    [Range(0, double.MaxValue)]
    [JsonPropertyName("kilocalories")]
    public decimal Kilocalories { get; set; }
}