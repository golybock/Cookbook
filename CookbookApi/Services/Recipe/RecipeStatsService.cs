using CookbookApi.Models.Database.Recipe;
using CookbookApi.Services.Interfaces.RecipeInterfaces;

namespace CookbookApi.Services.Recipe;

public class RecipeStatsService : IRecipeStatsService
{
    public async Task<RecipeStats?> GetRecipeStatsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddRecipeStatsAsync(RecipeStats recipeStats)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateRecipeStatsAsync(RecipeStats recipeStats)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteRecipeStatsAsync(int id)
    {
        throw new NotImplementedException();
    }
}