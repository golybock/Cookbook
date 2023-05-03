using Blank.Recipe;
using Database.Recipe;
using Domain.Recipe;

namespace Builders.Blank.Recipe;

public class RecipeStatsBuilder
{
    public static RecipeStatsBlank Create(RecipeStatsDomain recipeStatsDomain)
    {
        var recipeStats = new RecipeStatsBlank();
        
        recipeStats.Fats = recipeStatsDomain.Fats;
        recipeStats.Squirrels = recipeStatsDomain.Squirrels;
        recipeStats.Carbohydrates = recipeStatsDomain.Carbohydrates;
        recipeStats.Kilocalories = recipeStatsDomain.Kilocalories;
        recipeStats.Portions = recipeStatsDomain.Portions;
        recipeStats.CookingTime = recipeStatsDomain.CookingTime;

        return recipeStats;
    }
    
    public static RecipeStatsBlank Create(RecipeStats recipeStatsDatabase)
    {
        var recipeStats = new RecipeStatsBlank();
        
        recipeStats.Fats = recipeStatsDatabase.Fats;
        recipeStats.Squirrels = recipeStatsDatabase.Squirrels;
        recipeStats.Carbohydrates = recipeStatsDatabase.Carbohydrates;
        recipeStats.Kilocalories = recipeStatsDatabase.Kilocalories;
        recipeStats.Portions = recipeStatsDatabase.Portions;
        recipeStats.CookingTime = recipeStatsDatabase.CookingTime;

        return recipeStats;
    }
}