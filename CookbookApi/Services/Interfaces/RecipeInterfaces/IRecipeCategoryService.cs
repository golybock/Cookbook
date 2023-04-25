using CookbookApi.Models.Blank.Recipe.Category;
using CookbookApi.Models.Database.Recipe.Category;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApi.Services.Interfaces.RecipeInterfaces;

public interface IRecipeCategoryService
{
    public Task<IActionResult> GetRecipeCategoryAsync(int id);

    public Task<List<RecipeCategory>> GetRecipeCategoriesAsync(int recipeId);
    
    public Task<IActionResult> CreateRecipeCategoryAsync(RecipeCategoryBlank recipeCategory);
    
    public Task<IActionResult> UpdateRecipeCategoryAsync(int id, RecipeCategoryBlank recipeCategory);
    
    public Task<IActionResult> DeleteRecipeCategoryAsync(int id);
    
    public Task<IActionResult> DeleteRecipeCategoriesAsync(int recipeId);
}