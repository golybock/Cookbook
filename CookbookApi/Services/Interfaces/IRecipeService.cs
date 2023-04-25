using CookbookApi.Models.Database.Recipe.Category;
using RecipeModel = CookbookApi.Models.Database.Recipe.Recipe;

namespace CookbookApi.Services.Interfaces;

public interface IRecipeService
{
    public Task<RecipeModel> GetRecipeAsync(int id);
    public Task<List<RecipeModel>> GetRecipesAsync();
    public Task<List<Category>> GetCategoriesAsync();
    public Task<List<RecipeModel>> GetClientRecipes(int clientId);
    public Task<List<RecipeModel>> GetClientFavRecipes(int clientId);
    public Task GetRecipeInfo(RecipeModel recipe);
    public Task<List<RecipeModel>> FindRecipesAsync(string searchString);
    public Task<CommandResult> AddRecipeAsync(RecipeModel recipe);
    public Task<CommandResult> UpdateRecipeAsync(RecipeModel recipe);
    public Task<CommandResult> DeleteRecipeInfoAsync(int id);
}