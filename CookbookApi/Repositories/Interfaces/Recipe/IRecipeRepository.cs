using RecipeDatabase = Models.Database.Recipe.Recipe;

namespace CookbookApi.Repositories.Interfaces.Recipe;

public interface IRecipeRepository
{
    public Task<RecipeDatabase?> GetAsync(int id);
    
    public Task<RecipeDatabase?> GetAsync(string recipeCode);
    
    public Task<List<RecipeDatabase>> GetAsync();
    
    public Task<List<RecipeDatabase>> GetClientAsync(int clientId);
    
    public Task<int> AddAsync(RecipeDatabase recipe);
    
    public Task<int> UpdateAsync(int id, RecipeDatabase recipe);

    public Task<int> UpdateImageAsync(int id, string imagePath);
    
    public Task<int> DeleteAsync(int id);
    
    public Task<int> DeleteImageAsync(int id);
}