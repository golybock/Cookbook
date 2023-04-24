using CookbookApi.Models.Blank.Recipe;
using CookbookApi.Models.Database.Recipe;

namespace CookbookApi.Models.Domain.Recipe;

public class RecipeStatsDomain
{
    public decimal Fats { get; set; }
    
    public decimal Squirrels { get; set; }

    public decimal Carbohydrates { get; set; }

    public decimal Kilocalories { get; set; }
    
    public int Portions { get; set; }
    
    public DateTime CookingTime { get; set; }

    public RecipeStatsDomain() { }

    public RecipeStatsDomain(RecipeStats recipeStats)
    {
        Fats = recipeStats.Fats;
        Squirrels = recipeStats.Squirrels;
        Carbohydrates = recipeStats.Carbohydrates;
        Kilocalories = recipeStats.Kilocalories;
        Portions = recipeStats.Portions;
        CookingTime = recipeStats.CookingTime;
    }
    
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