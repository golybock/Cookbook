using CookbookApi.Models.Blank.Recipe.Category;
using CookbookApi.Models.Database.Recipe.Category;
using CookbookApi.Services.Interfaces.RecipeInterfaces;

namespace CookbookApi.Services.Recipe;

public class RecipeCategoryService : IRecipeCategoryService
{
    public async Task<RecipeCategory> GetRecipeCategoryAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<RecipeCategory>> GetRecipeCategoriesAsync(int recipeId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateRecipeCategoryAsync(RecipeCategoryBlank recipeCategory)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateRecipeCategoryAsync(int id, RecipeCategoryBlank recipeCategory)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteRecipeCategoryAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteRecipeCategoriesAsync(int recipeId)
    {
        throw new NotImplementedException();
    }
}