using CookbookApi.Models.Database.Recipe;

namespace CookbookApi.Repositories.Interfaces.RecipeInterfaces;

public interface IRecipeIngredientRepository
{
    public Task<RecipeIngredient?> GetRecipeIngredientAsync(int id);

    public Task<List<RecipeIngredient>> GetRecipeIngredientsAsync(int recipeId);

    public Task<int> AddRecipeIngredientAsync(RecipeIngredient recipeIngredient);

    public Task<int> UpdateRecipeIngredientAsync(RecipeIngredient recipeIngredient);

    public Task<int> DeleteRecipeIngredientAsync(int id);

    // delete recipe_ingredient where recipe_id == recipeId
    public Task<int> DeleteRecipeIngredientsAsync(int recipeId);
}