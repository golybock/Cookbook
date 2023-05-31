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
            var view = new RecipeView() {Datetime = DateTime.UtcNow, RecipeId = recipe.Id};

            await App.Context.RecipeViews.AddAsync(view);
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
        if (image != null)
            recipe.ImagePath = CopyImageToBin(image);

        await App.Context.Recipes.AddAsync(recipe);
        await App.Context.SaveChangesAsync();

        return recipe.Id;
    }

    public async Task Update(Recipe recipe, string? image)
    {
        if (image == null)
            recipe.ImagePath = null;

        if (image != null && image != recipe.ImagePath)
            recipe.ImagePath = CopyImageToBin(image);

        App.Context.Recipes.Update(recipe);
        await App.Context.SaveChangesAsync();
    }

    private string CopyImageToBin(string image)
    {
        var path = Guid.NewGuid() + ".png";

        File.Copy(image, path);

        return path;
    }

    public async Task Delete(Recipe recipe)
    {
        recipe.RecipeCategories.Clear();
        recipe.RecipeStat = null!;
        recipe.RecipeIngredients.Clear();
        recipe.RecipeSteps.Clear();
        recipe.RecipeViews.Clear();
        recipe.FavoriteRecipes.Clear();

        App.Context.Recipes.Update(recipe);
        await App.Context.SaveChangesAsync();

        App.Context.Recipes.Remove(recipe);
        await App.Context.SaveChangesAsync();
    }
}