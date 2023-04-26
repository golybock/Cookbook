using CookbookApi.Models.Blank.Recipe.Category;
using CookbookApi.Models.Database.Recipe.Category;
using CookbookApi.Models.Domain.Recipe.Category;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApi.Services.Interfaces.RecipeInterfaces;

public interface ICategoryService
{
    public Task<IActionResult> GetCategoryAsync(int id);
    
    public Task<List<CategoryDomain>> GetCategories();
    
    public Task<IActionResult> CreateCategoryAsync(CategoryBlank category);
    
    // public Task<int> UpdateCategoryAsync(int id, CategoryBlank category);
    
    public Task<IActionResult> DeleteCategoryAsync(int id);
}