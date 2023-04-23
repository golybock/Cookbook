using CookbookApi.Models.Database.Recipe.Category;

namespace CookbookApi.Repositories.Interfaces.RecipeInterfaces;

public interface IRecipeCategoryRepository
{
    public Task<RecipeCategory> GetRecipeCategoryAsync(int id);
    
    public Task<List<RecipeCategory>> GetRecipeCategoriesAsync(int recipeId);

    public Task<int> AddRecipeCategoryAsync(RecipeCategory recipeCategory);
    
    public Task<int> UpdateRecipeCategoryAsync(RecipeCategory recipeCategory);
    
    public Task<int> DeleteRecipeCategoryAsync(int id);
    
    // delete recipe_category where recipe_id == recipeId
    public Task<int> DeleteRecipeCategoriesAsync(int recipeId);
}