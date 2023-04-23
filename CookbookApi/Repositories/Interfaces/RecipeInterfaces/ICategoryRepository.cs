using CookbookApi.Models.Database.Recipe.Category;

namespace CookbookApi.Repositories.Interfaces.RecipeInterfaces;

public interface ICategoryRepository
{
    public Task<Category> GetCategoryAsync(int id);
    
    public Task<List<Category>> GetCategoriesAsync();
    
    public Task<int> AddCategoryAsync(Category category);
    
    public Task<int> UpdateCategoryAsync(Category category);
    
    public Task<int> DeleteCategoryAsync(int id);
}