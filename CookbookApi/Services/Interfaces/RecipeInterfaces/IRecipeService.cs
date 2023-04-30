using CookbookApi.Models.Blank.Recipe;
using CookbookApi.Models.Database.Recipe.Category;
using CookbookApi.Models.Domain.Recipe;
using CookbookApi.Models.Domain.Recipe.Category;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApi.Services.Interfaces.RecipeInterfaces;

public interface IRecipeService
{
    public Task<IActionResult> GetRecipeAsync(string recipeCode);
    
    public Task<List<RecipeDomain>> GetRecipesAsync();

    public Task<IActionResult> GetClientLikedRecipesAsync(string token);

    public Task<IActionResult> GetClientRecipesAsync(string token);
    
    public Task<IActionResult> CreateRecipeAsync(string token, RecipeBlank recipe);
    
    public Task<IActionResult> UpdateRecipeAsync(string token, string recipeCode, RecipeBlank recipe);

    public Task<IActionResult> UploadRecipeImageAsync(string token, string code, IFormFile file);
    
    public Task<IActionResult> DeleteRecipeAsync(string token, string recipeCode);
    
    public Task<IActionResult> DeleteRecipeImageAsync(string token, string recipeCode);
}