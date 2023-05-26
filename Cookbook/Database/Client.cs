using System;
using System.Collections.Generic;

namespace Cookbook.Database;

public partial class Client
{
    public int Id { get; set; }

    public string? Password { get; set; }

    public string? Description { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? ImagePath { get; set; }

    public virtual ICollection<FavoriteRecipe> FavoriteRecipes { get; set; } = new List<FavoriteRecipe>();

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
