using CookbookApi.Models.Database.Recipe;

namespace CookbookApi.Repositories.Interfaces.RecipeInterfaces;

public interface IRecipeTypeRepository
{
    public Task<RecipeType?> GetRecipeTypeAsync(int id);
    public Task<List<RecipeType>> GetRecipeTypesAsync();
}