using CategoryDatabase = Models.Database.Recipe.Category.Category;

namespace CookbookApi.Repositories.Interfaces.Recipe.Category;

public interface ICategoryRepository
{
    public Task<CategoryDatabase?> GetAsync(int id);

    public Task<List<CategoryDatabase>> GetAsync();

    public Task<int> AddAsync(CategoryDatabase category);
    
    public Task<int> DeleteAsync(int id);
}