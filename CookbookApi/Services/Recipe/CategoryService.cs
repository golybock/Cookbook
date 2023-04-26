using CookbookApi.Models.Blank.Recipe.Category;
using CookbookApi.Models.Database.Recipe.Category;
using CookbookApi.Models.Domain.Recipe.Category;
using CookbookApi.Services.Interfaces.RecipeInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApi.Services.Recipe;

public class CategoryService : ICategoryService
{
    public async Task<IActionResult> GetCategoryAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<CategoryDomain>> GetCategories()
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> CreateCategoryAsync(CategoryBlank category)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> DeleteCategoryAsync(int id)
    {
        throw new NotImplementedException();
    }
}