using CookbookApi.Models.Database.Recipe;

namespace CookbookApi.Repositories.Interfaces.RecipeInterfaces;

public interface IRecipeImageRepository
{
    public Task<RecipeImage> GetRecipeImageAsync(int id);
    
    public Task<List<RecipeImage>> GetRecipeImagesAsync(int recipeId);
    
    public Task<int> AddRecipeImageAsync(RecipeImage recipeImage);
    
    public Task<int> UpdateRecipeImageAsync(RecipeImage recipeImage);
    
    // delete recipe_image where recipe_id == recipeId
    public Task<int> DeleteRecipeImagesAsync(int recipeId);
    
    // delete recipe_image where id == id
    public Task<int> DeleteRecipeImageAsync(int id);
}