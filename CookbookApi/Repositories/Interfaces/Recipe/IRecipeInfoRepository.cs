using RecipeInfoDatabase = Models.Database.Recipe.RecipeInfo;

namespace CookbookApi.Repositories.Interfaces.Recipe;

public interface IRecipeInfoRepository
{
    public Task<RecipeInfoDatabase?> GetAsync(int id);

    public Task<int> AddAsync(RecipeInfoDatabase recipeInfo);
    
    public Task<int> UpdateAsync(int id, RecipeInfoDatabase recipeInfo);
    
    public Task<int> DeleteAsync(int id);
} 