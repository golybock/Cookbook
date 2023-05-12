using System.Text.Json.Serialization;

namespace Models.Domain.Recipe;

public class RecipeBjuDomain
{
    [JsonPropertyName("fats")]
    public decimal Fats { get; set; }
    [JsonPropertyName("squirrels")]
    public decimal Squirrels { get; set; }
    [JsonPropertyName("carbohydrates")]
    public decimal Carbohydrates { get; set; }
    [JsonPropertyName("kilocalories")]
    public decimal Kilocalories { get; set; }
}