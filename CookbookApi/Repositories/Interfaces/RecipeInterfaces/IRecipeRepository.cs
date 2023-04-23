using RecipeModel = CookbookApi.Models.Database.Recipe.Recipe;

namespace CookbookApi.Repositories.Interfaces.RecipeInterfaces;

public interface IRecipeRepository
{
    public Task<RecipeModel> GetRecipeAsync(int id);
    public Task<List<RecipeModel>> GetRecipesAsync();
    public Task<List<RecipeModel>> GetClientRecipesAsync(int clientId);
    public Task<int> AddRecipeAsync(RecipeModel recipe);
    public Task<int> UpdateRecipeAsync(RecipeModel recipe);
    public Task<int> DeleteRecipeAsync(int id);
}