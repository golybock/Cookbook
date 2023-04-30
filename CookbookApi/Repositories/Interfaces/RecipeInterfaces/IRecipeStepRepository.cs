using CookbookApi.Models.Database.Recipe;

namespace CookbookApi.Repositories.Interfaces.RecipeInterfaces;

public interface IRecipeStepRepository
{
    public Task<RecipeStep?> GetRecipeStep(int id);
    
    public Task<List<RecipeStep>> GetRecipeSteps(int recipeId);

    public Task<int> AddRecipeStep(RecipeStep recipeStep);

    public Task<int> DeleteRecipeStep(int id);
    
    public Task<int> DeleteRecipeSteps(int recipeId);
}