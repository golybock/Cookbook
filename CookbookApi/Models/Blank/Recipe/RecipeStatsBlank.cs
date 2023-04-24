using CookbookApi.Models.Database.Recipe;
using CookbookApi.Models.Domain.Recipe;

namespace CookbookApi.Models.Blank.Recipe;

public class RecipeStatsBlank
{
    public decimal Fats { get; set; }
    
    public decimal Squirrels { get; set; }

    public decimal Carbohydrates { get; set; }

    public decimal Kilocalories { get; set; }
    
    public int Portions { get; set; }
    
    public DateTime CookingTime { get; set; }

    public RecipeStatsBlank() { }

    public RecipeStatsBlank(RecipeStats recipeStats)
    {
        Fats = recipeStats.Fats;
        Squirrels = recipeStats.Squirrels;
        Carbohydrates = recipeStats.Carbohydrates;
        Kilocalories = recipeStats.Kilocalories;
        Portions = recipeStats.Portions;
        CookingTime = recipeStats.CookingTime;
    }
    
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