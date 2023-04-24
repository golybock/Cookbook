using CookbookApi.Models.Blank.Recipe;
using CookbookApi.Models.Domain.Recipe;

namespace CookbookApi.Models.Database.Recipe;

public class RecipeStats
{
    public int Id { get; set; } // recipe id
    
    public decimal Fats { get; set; }
    
    public decimal Squirrels { get; set; }

    public decimal Carbohydrates { get; set; }

    public decimal Kilocalories { get; set; }
    
    public int Portions { get; set; }
    
    public DateTime CookingTime { get; set; }

    public RecipeStats() { }

    public RecipeStats(RecipeStatsDomain recipeStats)
    {
        Fats = recipeStats.Fats;
        Squirrels = recipeStats.Squirrels;
        Carbohydrates = recipeStats.Carbohydrates;
        Kilocalories = recipeStats.Kilocalories;
        Portions = recipeStats.Portions;
        CookingTime = recipeStats.CookingTime;
    }
    
    public RecipeStats(RecipeStatsBlank recipeStats)
    {
        Fats = recipeStats.Fats;
        Squirrels = recipeStats.Squirrels;
        Carbohydrates = recipeStats.Carbohydrates;
        Kilocalories = recipeStats.Kilocalories;
        Portions = recipeStats.Portions;
        CookingTime = recipeStats.CookingTime;
    }
}