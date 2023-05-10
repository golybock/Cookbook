using System;
using System.Text.Json.Serialization;
using Cookbook.Models.Domain.Recipe;

namespace Cookbook.Models.Blank.Recipe;

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
    [JsonIgnore] 
    public int CookingTimeMinutes
    {
        get => CookingTime.Minute;
        set => CookingTime = new DateTime(0, 0, 0, 0, value, 0);
    }

    public RecipeStatsBlank() { }

    public RecipeStatsBlank(RecipeStatsDomain recipeStats)
    {
        Fats = recipeStats.Fats;
        Squirrels = recipeStats.Squirrels;
        Carbohydrates = recipeStats.Carbohydrates;
        Kilocalories = recipeStats.Kilocalories;
        Portions = recipeStats.Portions;
        CookingTime = recipeStats.CookingTime;
    }
}