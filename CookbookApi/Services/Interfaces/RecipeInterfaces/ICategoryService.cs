using CookbookApi.Models.Blank.Recipe.Category;
using CookbookApi.Models.Database.Recipe.Category;
using CookbookApi.Models.Domain.Recipe.Category;

namespace CookbookApi.Services.Interfaces.RecipeInterfaces;

public interface ICategoryService
{
    public Task<CategoryDomain> GetCategoryAsync(int id);
    public Task<List<CategoryDomain>> GetCategories();
    public Task<int> CreateCategoryAsync(CategoryBlank category);
    public Task<int> UpdateCategoryAsync(int id, CategoryBlank category);
    public Task<int> DeleteCategoryAsync(int id);
}