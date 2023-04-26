using CookbookApi.Models.Database.Recipe;
using CookbookApi.Services.Interfaces.RecipeInterfaces;
using CookbookApi.Services.Recipe.Ingredients;

namespace CookbookApi.Services.Recipe;

public class RecipeIngredientService : IRecipeIngredientService
{
    public async Task<RecipeIngredient> GetRecipeIngredientAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<RecipeIngredient>> GetRecipeIngredientsAsync(int recipeId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddRecipeIngredientAsync(RecipeIngredient recipeIngredient)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateRecipeIngredientAsync(RecipeIngredient recipeIngredient)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteRecipeIngredientAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteRecipeIngredientsAsync(int recipeId)
    {
        throw new NotImplementedException();
    }
}