using CookbookApi.Models.Database.Recipe;

namespace CookbookApi.Services.Interfaces.RecipeInterfaces;

public interface IRecipeStatsService
{
    public Task<RecipeStats?> GetRecipeStatsAsync(int id);
    public Task<CommandResult> AddRecipeStatsAsync(RecipeStats recipeStats);
    public Task<CommandResult> UpdateRecipeStatsAsync(RecipeStats recipeStats);
    public Task<CommandResult> DeleteRecipeStatsAsync(int id);
}