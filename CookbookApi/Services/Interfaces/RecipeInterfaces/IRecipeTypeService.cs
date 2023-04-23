using System.Collections.Generic;
using System.Threading.Tasks;
using CookbookApi.Models.Database;
using CookbookApi.Models.Database.Recipe;

namespace Cookbook.Database.Services.Interfaces.RecipeInterfaces;

public interface IRecipeTypeService
{
    public Task<RecipeType> GetRecipeTypeAsync(int id);
    public Task<List<RecipeType>> GetRecipeTypesAsync();
    public Task<CommandResult> AddRecipeTypeAsync(RecipeType recipeType);
}