using RecipeViewDatabase = Models.Database.Recipe.RecipeView;

namespace CookbookApi.Repositories.Interfaces.Recipe;

public interface IRecipeViewRepository
{
    public Task<List<RecipeViewDatabase>?> GetAsync(int recipeId);
    
    public Task<List<RecipeViewDatabase>?> GetAsync();

    public Task<int> AddAsync(RecipeViewDatabase recipeView);
    
    public Task<int> AddAsync(int recipeId);

    public Task<int> DeleteByRecipeAsync(int recipeId);
}