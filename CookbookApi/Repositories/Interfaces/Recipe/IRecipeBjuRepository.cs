using RecipeBjuDatabase = Models.Database.Recipe.RecipeBju;

namespace CookbookApi.Repositories.Interfaces.Recipe;

public interface IRecipeBjuRepository
{
    public Task<RecipeBjuDatabase?> GetAsync(int id);

    public Task<int> AddAsync(RecipeBjuDatabase recipeBju);
    
    public Task<int> UpdateAsync(int id, RecipeBjuDatabase recipeBju);
    
    public Task<int> DeleteAsync(int id);
}