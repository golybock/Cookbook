using CookbookApi.Models.Database.Recipe;
using CookbookApi.Services.Interfaces.RecipeInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApi.Services.Recipe;

public class RecipeImageService : IRecipeImageService
{
    public async Task<IActionResult> GetRecipeImageAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<RecipeImage>> GetRecipeImagesAsync(int recipeId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> AddRecipeImageAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> UpdateRecipeImageAsync(int id, IFormFile file)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> DeleteRecipeImagesAsync(int recipeId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> DeleteRecipeImageAsync(int id)
    {
        throw new NotImplementedException();
    }
}