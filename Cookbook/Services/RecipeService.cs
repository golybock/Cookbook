using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Database;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.Services;

public class RecipeService : IRecipeService
{
    public async Task<Recipe?> Get(int id)
    {
        var recipe = await App.Context.Recipes
            .Include(c => c.RecipeStat)
            .Include(c => c.RecipeSteps)
            .Include(c => c.RecipeViews)
            .Include(c => c.RecipeCategories)
            .ThenInclude(c => c.Category)
            .Include(c => c.RecipeIngredients)
            .ThenInclude(c => c.Ingredient)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (recipe != null)
        {
            await App.Context.RecipeViews.AddAsync(new RecipeView() {Datetime = DateTime.UtcNow, RecipeId = recipe.Id});
            await App.Context.SaveChangesAsync();
        }

        return recipe;
    }

    public async Task<List<Recipe>> Get()
    {
        return await App.Context.Recipes.ToListAsync();
    }

    public async Task<int> Create(Recipe recipe, List<RecipeIngredient> recipeIngredients, RecipeStat recipeStat,
        List<RecipeStep> steps)
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

    public async Task<int> Update(Recipe recipe, List<RecipeIngredient> recipeIngredients, RecipeStat recipeStat,
        List<RecipeStep> steps)
    {
        App.Context.Recipes.Update(recipe);
        await App.Context.SaveChangesAsync();

        var oldRecipeIngredients =
            await App.Context.RecipeIngredients
                .Where(c => c.RecipeId == recipe.Id)
                .ToListAsync();
        
        App.Context.RecipeIngredients.RemoveRange(oldRecipeIngredients);
        await App.Context.SaveChangesAsync();

        foreach (var recipeIngredient in recipeIngredients)
        {
            await App.Context.RecipeIngredients.AddAsync(recipeIngredient);
            await App.Context.SaveChangesAsync();
        }

        var oldRecipeSteps =
            await App.Context.RecipeSteps
                .Where(c => c.RecipeId == recipe.Id)
                .ToListAsync();
        
        App.Context.RecipeSteps.RemoveRange(oldRecipeSteps);
        await App.Context.SaveChangesAsync();
        
        foreach (var step in steps)
        {
            step.RecipeId = recipe.Id;
            await App.Context.RecipeSteps.AddAsync(step);
            await App.Context.SaveChangesAsync();
        }

        App.Context.RecipeStats.Remove(recipeStat);
        await App.Context.SaveChangesAsync();
        
        await App.Context.RecipeStats.AddAsync(recipeStat);
        await App.Context.SaveChangesAsync();

        return await App.Context.SaveChangesAsync();
    }

    public async Task<int> Delete(Recipe recipe)
    {
        App.Context.Recipes.Remove(recipe);
        return await App.Context.SaveChangesAsync();
    }
}