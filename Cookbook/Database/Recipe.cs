using System;
using System.Collections.Generic;
using System.Reflection;

namespace Cookbook.Database;

public partial class Recipe
{
    public int Id { get; set; }

    public int? ClientId { get; set; }

    public string Header { get; set; } = null!;

    private string? _imagePath;
    
    public string? ImagePath
    {
        get
        {
            if (_imagePath == null)
                return null;

            return System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/" + _imagePath;
        }
        set => _imagePath = value;
    }

    public string? SourceUrl { get; set; }

    public string? Description { get; set; }

    public virtual Client? Client { get; set; }

    public virtual ICollection<FavoriteRecipe> FavoriteRecipes { get; set; } = new List<FavoriteRecipe>();

    public virtual ICollection<RecipeCategory> RecipeCategories { get; set; } = new List<RecipeCategory>();

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    public virtual RecipeStat RecipeStat { get; set; } = new RecipeStat();

    public virtual ICollection<RecipeStep> RecipeSteps { get; set; } = new List<RecipeStep>();

    public virtual ICollection<RecipeView> RecipeViews { get; set; } = new List<RecipeView>();
    
    public int Views => RecipeViews.Count;
}
