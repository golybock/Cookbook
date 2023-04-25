using CookbookApi.Models.Database.Recipe;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApi.Services.Interfaces.RecipeInterfaces;

public interface IRecipeImageService
{
    public Task<IActionResult> GetRecipeImageAsync(int id);
    
    public Task<List<RecipeImage>> GetRecipeImagesAsync(int recipeId);
    
    public Task<IActionResult> AddRecipeImageAsync();
    
    public Task<IActionResult> UpdateRecipeImageAsync(int id, IFormFile file);
    
    public Task<IActionResult> DeleteRecipeImagesAsync(int recipeId);
    
    public Task<IActionResult> DeleteRecipeImageAsync(int id);
}