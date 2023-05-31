using System;
using System.Collections.Generic;

namespace Cookbook.Database;

public partial class Ingredient
{
    public int Id { get; set; }

    public int? MeasureId { get; set; }

    public string? Name { get; set; }

    public virtual Measure? Measure { get; set; }

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
}