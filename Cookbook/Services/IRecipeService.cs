using System.Collections.Generic;
using System.Threading.Tasks;
using Cookbook.Database;

namespace Cookbook.Services;

public interface IRecipeService
{
    public Task<Recipe?> Get(int id);

    public Task<List<Recipe>> Get();

    public Task<int> Create(Recipe recipe, IEnumerable<RecipeIngredient> recipeIngredients,
        IEnumerable<RecipeStep> steps, IEnumerable<RecipeCategory> categories, string? image);

    public Task<int> Update(Recipe recipe, IEnumerable<RecipeIngredient> recipeIngredients, IEnumerable<RecipeCategory> categories,
        IEnumerable<RecipeStep> steps, string? image);

    public Task<int> Delete(Recipe recipe);
}