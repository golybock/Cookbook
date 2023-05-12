using FavoriteRecipeDatabase = Models.Database.Recipe.FavoriteRecipe;

namespace CookbookApi.Repositories.Interfaces.Recipe;

public interface IFavoriteRecipeRepository
{
    public Task<FavoriteRecipeDatabase?> GetAsync(int id);
    
    public Task<List<FavoriteRecipeDatabase>> GetByClientAsync(int clientId);
    
    public Task<List<FavoriteRecipeDatabase>> GetByRecipeAsync(int recipeId);

    public Task<int> AddAsync(FavoriteRecipeDatabase favoriteRecipe);

    public Task<int> DeleteAsync(int id);
    
    public Task<int> DeleteByRecipeAsync(int recipeId);
    
    public Task<int> DeleteByClientAsync(int cientId);
}