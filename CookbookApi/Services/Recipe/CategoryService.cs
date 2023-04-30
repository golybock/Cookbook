using CookbookApi.Models.Blank.Recipe.Category;
using CookbookApi.Models.Database.Recipe.Category;
using CookbookApi.Models.Domain.Recipe.Category;
using CookbookApi.Repositories.Recipe;
using CookbookApi.Services.Interfaces.RecipeInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApi.Services.Recipe;

public class CategoryService : ICategoryService
{
    private readonly CategoryRepository _categoryRepository;

    public CategoryService()
    {
        _categoryRepository = new CategoryRepository();
    }

    public async Task<IActionResult> GetCategoryAsync(int id)
    {
        var category = await _categoryRepository.GetCategoryAsync(id);

        if (category == null)
            return new NotFoundResult();

        return new OkObjectResult(category);
    }

    public async Task<List<CategoryDomain>> GetCategories()
    {
        var categories = await _categoryRepository.GetCategoriesAsync();

        var categoriesDomain = categories
            .Select(c => new CategoryDomain(c))
            .ToList();

        return categoriesDomain;
    }

    public async Task<IActionResult> CreateCategoryAsync(CategoryBlank category)
    {
        if (string.IsNullOrEmpty(category.Name))
            return new BadRequestObjectResult("Наименование не может быть пустым");

        var res = await _categoryRepository.AddCategoryAsync(new Category(category));

        return res > 0 ? new OkObjectResult(res) : new BadRequestObjectResult("Не удалось создать категорию");
    }

    public async Task<IActionResult> DeleteCategoryAsync(int id)
    {
        var res = await _categoryRepository.DeleteCategoryAsync(id);

        return res > 0 ? new OkResult() : new NotFoundResult();
    }
}