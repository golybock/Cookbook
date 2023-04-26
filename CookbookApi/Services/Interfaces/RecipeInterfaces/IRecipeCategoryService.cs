using CookbookApi.Models.Blank.Recipe.Category;
using CookbookApi.Models.Database.Recipe.Category;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApi.Services.Interfaces.RecipeInterfaces;

public interface IRecipeCategoryService
{
    // приватный service для использования внутри других service-ов
    public Task<RecipeCategory> GetRecipeCategoryAsync(int id);

    public Task<List<RecipeCategory>> GetRecipeCategoriesAsync(int recipeId);
    
    public Task<int> CreateRecipeCategoryAsync(RecipeCategoryBlank recipeCategory);
    
    public Task<int> UpdateRecipeCategoryAsync(int id, RecipeCategoryBlank recipeCategory);
    
    public Task<int> DeleteRecipeCategoryAsync(int id);
    
    public Task<int> DeleteRecipeCategoriesAsync(int recipeId);
}