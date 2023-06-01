using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Cookbook.Database;

public partial class Recipe
{
    private string? _imagePath;
    
    public int Id { get; set; }

    public int? ClientId { get; set; }

    public string Header { get; set; } = null!;

    public string? SourceUrl { get; set; }

    public string? Description { get; set; }

    public virtual Client? Client { get; set; }

    public virtual ICollection<FavoriteRecipe> FavoriteRecipes { get; set; } = new List<FavoriteRecipe>();

    public virtual ICollection<RecipeCategory> RecipeCategories { get; set; } = new List<RecipeCategory>();

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    public virtual RecipeStat? RecipeStats { get; set; } = new RecipeStat();

    public virtual ICollection<RecipeStep> RecipeSteps { get; set; } = new List<RecipeStep>();

    public virtual ICollection<RecipeView> RecipeViews { get; set; } = new List<RecipeView>();

    public string? ImagePath
    {
        get => _imagePath != null
            ? System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + _imagePath
            : null;
        set => _imagePath = value;
    }

    public int Views => RecipeViews.Count;

    public override string ToString()
    {
        var res = "";

        res += $"{Header}\n";

        res += $"\nОписание:\n";
        res += $"{Description}\n";

        res += $"\nШаги приготовления:\n";
        res += string.Join("\n", RecipeSteps.Select(c => c.Text));

        res += $"\nИнгредиенты:\n";
        res += string.Join("\n", RecipeIngredients.Select(c => c.Ingredient?.ToString()));

        res += $"\nКатегории:\n";
        res += string.Join("\n", RecipeCategories.Select(c => c.Category?.Name));

        res += "\nИнформация\n";
        res += $"{RecipeStats}\n";

        return res;
    }
}