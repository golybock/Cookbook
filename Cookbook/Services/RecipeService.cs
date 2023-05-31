using System;
using System.Collections.Generic;
using System.IO;
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

    public async Task<int> Create(Recipe recipe, string? image)
    {
        if(image != null)
            recipe.ImagePath = await CopyImageToBin(image);
        
        await App.Context.Recipes.AddAsync(recipe);
        await App.Context.SaveChangesAsync();

        // foreach (var recipeIngredient in recipeIngredients)
        // {
        //     await App.Context.RecipeIngredients.AddAsync(recipeIngredient);
        //     await App.Context.SaveChangesAsync();
        // }
        
        // foreach (var recipeIngredient in recipeIngredients)
        // {
        //     await App.Context.RecipeIngredients.AddAsync(recipeIngredient);
        //     await App.Context.SaveChangesAsync();
        // }

        // foreach (var step in steps)
        // {
        //     step.RecipeId = recipe.Id;
        //     await App.Context.RecipeSteps.AddAsync(step);
        //     await App.Context.SaveChangesAsync();
        // }

        return recipe.Id;
    }

    public async Task<int> Update(Recipe recipe, string? image)
    {
        if (image == null)
            recipe.ImagePath = null;
        
        else if(image != null)
            recipe.ImagePath = await CopyImageToBin(image);
        
        else if(image != recipe.ImagePath)
            recipe.ImagePath = await CopyImageToBin(image);

        App.Context.Recipes.Update(recipe);
        await App.Context.SaveChangesAsync();

        // var oldRecipeIngredients =
        //     await App.Context.RecipeIngredients
        //         .Where(c => c.RecipeId == recipe.Id)
        //         .ToListAsync();
        //
        // App.Context.RecipeIngredients.RemoveRange(oldRecipeIngredients);
        // await App.Context.SaveChangesAsync();
        //
        // foreach (var recipeIngredient in recipeIngredients)
        // {
        //     await App.Context.RecipeIngredients.AddAsync(recipeIngredient);
        //     await App.Context.SaveChangesAsync();
        // }
        //
        // var oldRecipeSteps =
        //     await App.Context.RecipeSteps
        //         .Where(c => c.RecipeId == recipe.Id)
        //         .ToListAsync();
        //
        // App.Context.RecipeSteps.RemoveRange(oldRecipeSteps);
        // await App.Context.SaveChangesAsync();
        //
        // foreach (var step in steps)
        // {
        //     step.RecipeId = recipe.Id;
        //     await App.Context.RecipeSteps.AddAsync(step);
        //     await App.Context.SaveChangesAsync();
        // }

        return recipe.Id;
    }

    private async Task<string> CopyImageToBin(string image)
    {
        string path = Guid.NewGuid() + ".png";
        
        File.Copy(image, path);

        return path;
    }
    
    public async Task<int> Delete(Recipe recipe)
    {
        App.Context.Recipes.Remove(recipe);
        return await App.Context.SaveChangesAsync();
    }
}