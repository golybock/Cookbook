using CookbookApi.Models.Database.Recipe;
using CookbookApi.Services.Interfaces.RecipeInterfaces;

namespace CookbookApi.Services.Recipe;

public class RecipeTypeService : IRecipeTypeService
{
    public async Task<RecipeType> GetRecipeTypeAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<RecipeType>> GetRecipeTypesAsync()
    {
        throw new NotImplementedException();
    }
}