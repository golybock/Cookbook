using CookbookApi.Models.Database.Recipe;

namespace CookbookApi.Services.Interfaces.RecipeInterfaces;

public interface IRecipeTypeService
{
    public Task<RecipeType> GetRecipeTypeAsync(int id);
    public Task<List<RecipeType>> GetRecipeTypesAsync();
    public Task<CommandResult> AddRecipeTypeAsync(RecipeType recipeType);
}