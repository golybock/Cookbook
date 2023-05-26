using System.Collections.Generic;
using System.Threading.Tasks;
using Cookbook.Database;

namespace Cookbook.Services;

public interface IRecipeService
{
    public Task<Recipe?> Get(int id);
    
    public Task<List<Recipe>> Get();

    public Task<int> Create(Recipe recipe, List<RecipeIngredient> recipeIngredients, RecipeStat recipeStat, List<RecipeStep> steps);
    
    public Task<int> Update(Recipe recipe, List<RecipeIngredient> recipeIngredients, RecipeStat recipeStat, List<RecipeStep> steps);

    public Task<int> Delete(Recipe recipe);
}