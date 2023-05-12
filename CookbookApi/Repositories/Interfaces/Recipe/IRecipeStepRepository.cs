using RecipeStepDatabase = Models.Database.Recipe.RecipeStep;

namespace CookbookApi.Repositories.Interfaces.Recipe;

public interface IRecipeStepRepository
{
    public Task<List<RecipeStepDatabase>?> GetAsync(int recipeId);
    
    public Task<List<RecipeStepDatabase>?> GetAsync();

    public Task<int> AddAsync(RecipeStepDatabase recipeStep);
    
    public Task<int> UpdateAsync(int id, RecipeStepDatabase recipeStep);
    
    public Task<int> DeleteAsync(int id);
    
    public Task<int> DeleteByRecipeAsync(int recipeId);
}