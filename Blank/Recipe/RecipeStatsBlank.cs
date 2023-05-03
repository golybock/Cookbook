using System.Text.Json.Serialization;

namespace Blank.Recipe;

public class RecipeStatsBlank
{
    [JsonPropertyName("fats")]
    public decimal Fats { get; set; }
    [JsonPropertyName("squirrels")]
    public decimal Squirrels { get; set; }
    [JsonPropertyName("carbohydrates")]
    public decimal Carbohydrates { get; set; }
    [JsonPropertyName("kilocalories")]
    public decimal Kilocalories { get; set; }
    [JsonPropertyName("portions")]
    public int Portions { get; set; }
    [JsonPropertyName("cookingTime")]
    public DateTime CookingTime { get; set; }
}