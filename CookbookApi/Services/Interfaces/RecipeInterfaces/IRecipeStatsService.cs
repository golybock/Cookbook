using CookbookApi.Models.Database.Recipe;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApi.Services.Interfaces.RecipeInterfaces;

public interface IRecipeStatsService
{
    // приватный service для использования внутри других service-ов
    
    public Task<RecipeStats?> GetRecipeStatsAsync(int id);
    
    public Task<int> AddRecipeStatsAsync(RecipeStats recipeStats);
    
    public Task<int> UpdateRecipeStatsAsync(RecipeStats recipeStats);
    
    public Task<int> DeleteRecipeStatsAsync(int id);
}