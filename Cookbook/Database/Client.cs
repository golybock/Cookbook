using System;
using System.Collections.Generic;
using System.Reflection;

namespace Cookbook.Database;

public partial class Client
{
    private string? _imagePath;
    public int Id { get; set; }

    public string Password { get; set; } = null!;

    public string? Description { get; set; }

    public string? Name { get; set; }

    public string Email { get; set; } = null!;

    public string? ImagePath
    {
        get => System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/" + _imagePath;
        set => _imagePath = value;
    }

    public virtual ICollection<FavoriteRecipe> FavoriteRecipes { get; set; } = new List<FavoriteRecipe>();

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
