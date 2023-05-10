using System;
using System.Text.Json.Serialization;
using Cookbook.Models.Blank.Recipe;

namespace Cookbook.Models.Domain.Recipe;

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

    [JsonIgnore] 
    public int CookingTimeMinutes => CookingTime.Minute;

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