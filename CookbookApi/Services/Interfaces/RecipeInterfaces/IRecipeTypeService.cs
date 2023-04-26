using CookbookApi.Models.Database.Recipe;

namespace CookbookApi.Services.Interfaces.RecipeInterfaces;

public interface IRecipeTypeService
{
    // приватный service для использования внутри других service-ов
    public Task<RecipeType> GetRecipeTypeAsync(int id);
    
    public Task<List<RecipeType>> GetRecipeTypesAsync();
    
    // public Task<int> AddRecipeTypeAsync(RecipeType recipeType);
}