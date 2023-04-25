using CookbookApi.Models.Database.Recipe;
using CookbookApi.Services.Interfaces.RecipeInterfaces;

namespace CookbookApi.Services.Recipe;

public class RecipeTypeService : IRecipeTypeService
{
    private readonly RecipeTypeRepository _recipeTypeRepository;

    public RecipeTypeService()
    {
        _recipeTypeRepository = new RecipeTypeRepository();
    }

    public async Task<RecipeType> GetRecipeTypeAsync(int id)
    {
        if (id <= 0)
            return new();

        return await _recipeTypeRepository.GetRecipeTypeAsync(id);
    }

    public Task<List<RecipeType>> GetRecipeTypesAsync()
    {
        return _recipeTypeRepository.GetRecipeTypesAsync();
    }

    public Task<CommandResult> AddRecipeTypeAsync(RecipeType recipeType)
    {
        return _recipeTypeRepository.AddRecipeTypeAsync(recipeType);
    }
}