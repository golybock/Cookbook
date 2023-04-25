using CookbookApi.Models.Database.Client;
using CookbookApi.Models.Domain.Recipe;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApi.Services.Interfaces.ClientInterfaces;

public interface IClientFavService
{
    public Task<List<RecipeDomain>> GetFavoriteRecipesAsync(string token);
    
    public Task<IActionResult> AddFavoriteRecipeAsync(string token, int recipeId);
    
    public Task<IActionResult> DeleteFavoriteRecipeAsync(string token, int recipeId);
    
    // public Task<int> DeleteClientFavoriteRecipes(string token);
}