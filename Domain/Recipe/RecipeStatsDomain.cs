using System.Text.Json.Serialization;

namespace Domain.Recipe;

public class RecipeStatsDomain
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

    public RecipeStatsDomain() { }

    public RecipeStatsDomain(RecipeStatsBlank recipeStats)
    {
        Fats = recipeStats.Fats;
        Squirrels = recipeStats.Squirrels;
        Carbohydrates = recipeStats.Carbohydrates;
        Kilocalories = recipeStats.Kilocalories;
        Portions = recipeStats.Portions;
        CookingTime = recipeStats.CookingTime;
    }
}