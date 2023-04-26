using CookbookApi.Models.Blank.Recipe;
using CookbookApi.Models.Domain.Recipe;
using CookbookApi.Services.Interfaces.RecipeInterfaces;
using Microsoft.AspNetCore.Mvc;
using RecipeModel = CookbookApi.Models.Database.Recipe.Recipe;

namespace CookbookApi.Services.Recipe;

public class RecipeService : IRecipeService
{
    public async Task<IActionResult> GetRecipeAsync(string recipeCode)
    {
        throw new NotImplementedException();
    }

    public async Task<List<RecipeDomain>> GetRecipesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> GetClientLikedRecipesAsync(string token)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> GetClientRecipesAsync(string token)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> CreateRecipeAsync(string token, RecipeBlank recipe)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> UpdateRecipeAsync(string token, string recipeCode, RecipeBlank recipe)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> DeleteRecipeAsync(string token, string recipeCode)
    {
        throw new NotImplementedException();
    }
}