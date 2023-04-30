using CookbookApi.Models.Database.Recipe;
using CookbookApi.Models.Domain.Recipe;
using CookbookApi.Repositories.Recipe;
using CookbookApi.Services.Interfaces.RecipeInterfaces;

namespace CookbookApi.Services.Recipe;

public class RecipeTypeService : IRecipeTypeService
{
    private readonly RecipeTypeRepository _recipeTypeRepository;

    public RecipeTypeService()
    {
        _recipeTypeRepository = new RecipeTypeRepository();
    }

    // public async Task<RecipeType?> GetRecipeTypeAsync(int id)
    // {
    //     var recipeType = await _recipeTypeRepository.GetRecipeTypeAsync(id);
    //
    //     return recipeType;
    // }

    public async Task<List<RecipeTypeDomain>> GetRecipeTypesAsync()
    {
        var recipeTypes = await _recipeTypeRepository.GetRecipeTypesAsync();

        var recipeTypesDomain = recipeTypes
            .Select(c => new RecipeTypeDomain(c))
            .ToList();

        return recipeTypesDomain;
    }
}