using System.Collections.Generic;
using System.Threading.Tasks;
using Cookbook.Database;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.Services;

public class RecipeService : IRecipeService
{
    public async Task<Recipe?> Get(int id)
    {
        return await App.Context.Recipes.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Recipe>> Get()
    {
        throw new System.NotImplementedException();
    }

    public async Task<int> Create(Recipe recipe, List<RecipeIngredient> recipeIngredients, RecipeStat recipeStat, List<RecipeStep> steps)
    {
        await App.Context.Recipes.AddAsync(recipe);
        await App.Context.SaveChangesAsync();

        foreach (var recipeIngredient in recipeIngredients)
        {
            await App.Context.RecipeIngredients.AddAsync(recipeIngredient);
            await App.Context.SaveChangesAsync();
        }
        
        foreach (var step in steps)
        {
            step.RecipeId = recipe.Id;
            await App.Context.RecipeSteps.AddAsync(step);
            await App.Context.SaveChangesAsync();
        }

        recipeStat.Id = recipe.Id;
        
        await App.Context.RecipeStats.AddAsync(recipeStat);
        await App.Context.SaveChangesAsync();
        
        return await App.Context.SaveChangesAsync();
    }

    public async Task<int> Update(Recipe recipe, List<RecipeIngredient> recipeIngredients, RecipeStat recipeStat, List<RecipeStep> steps)
    {
        throw new System.NotImplementedException();
    }

    public async Task<int> Delete(Recipe recipe)
    {
        App.Context.Recipes.Remove(recipe);
        return await App.Context.SaveChangesAsync();
    }
}