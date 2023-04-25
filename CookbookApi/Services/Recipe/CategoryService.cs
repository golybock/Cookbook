using CookbookApi.Models.Database.Recipe.Category;
using CookbookApi.Services.Interfaces.RecipeInterfaces;

namespace CookbookApi.Services.Recipe;

public class CategoryService : ICategoryService
{
    private readonly CategoryRepository _categoryRepository;

    public CategoryService()
    {
        _categoryRepository = new CategoryRepository();
    }

    public Task<Category> GetCategoryAsync(int id)
    {
        return _categoryRepository.GetCategoryAsync(id);
    }

    public Task<List<Category>> GetCategories()
    {
        return _categoryRepository.GetCategoriesAsync();
    }

    public Task<CommandResult> AddCategoryAsync(Category category)
    {
        return _categoryRepository.AddCategoryAsync(category);
    }

    public Task<CommandResult> UpdateCategoryAsync(Category category)
    {
        return _categoryRepository.UpdateCategoryAsync(category);
    }

    public Task<CommandResult> DeleteCategoryAsync(int id)
    {
        return _categoryRepository.DeleteCategoryAsync(id);
    }
}