using CookbookApi.Models.Database.Recipe;
using CookbookApi.Models.Domain.Recipe;

namespace CookbookApi.Services.Interfaces.RecipeInterfaces;

public interface IRecipeTypeService
{
    // useless
    
    // приватный service для использования внутри других service-ов
    // public Task<RecipeType?> GetRecipeTypeAsync(int id);
    
    public Task<List<RecipeTypeDomain>> GetRecipeTypesAsync();
    
    // public Task<int> AddRecipeTypeAsync(RecipeType recipeType);
}