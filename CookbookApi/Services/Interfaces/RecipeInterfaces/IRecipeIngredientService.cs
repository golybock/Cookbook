using CookbookApi.Models.Database.Recipe;

namespace CookbookApi.Services.Interfaces.RecipeInterfaces;

public interface IRecipeIngredientService
{
    // приватный service для использования внутри других service-ов
    public Task<RecipeIngredient> GetRecipeIngredientAsync(int id);
    
    public Task<List<RecipeIngredient>> GetRecipeIngredientsAsync(int recipeId);

    public Task<int> AddRecipeIngredientAsync(RecipeIngredient recipeIngredient);
    
    public Task<int> UpdateRecipeIngredientAsync(RecipeIngredient recipeIngredient);
    
    public Task<int> DeleteRecipeIngredientAsync(int id);
                                              
    public Task<int> DeleteRecipeIngredientsAsync(int recipeId);
}