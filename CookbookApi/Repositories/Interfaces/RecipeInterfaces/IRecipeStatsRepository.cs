using CookbookApi.Models.Database.Recipe;

namespace CookbookApi.Repositories.Interfaces.RecipeInterfaces;

public interface IRecipeStatsRepository
{
    public Task<RecipeStats> GetRecipeStatsAsync(int id);
    public Task<int> AddRecipeStatsAsync(RecipeStats recipeStats);
    public Task<int> UpdateRecipeStatsAsync(RecipeStats recipeStats);
    public Task<int> DeleteRecipeStatsAsync(int id);
}