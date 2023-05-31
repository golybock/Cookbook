using System;
using System.Collections.Generic;

namespace Cookbook.Database;

public partial class RecipeIngredient
{
    public int Id { get; set; }

    public int? RecipeId { get; set; }

    public int? IngredientId { get; set; }

    public decimal? Count { get; set; }

    public virtual Ingredient Ingredient { get; set; } = null!;

    public virtual Recipe Recipe { get; set; } = null!;

    public override string ToString()
    {
        return $"{Ingredient?.Name} {Count} {Ingredient?.Measure?.Name}";
    }
}