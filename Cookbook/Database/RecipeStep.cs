using System;
using System.Collections.Generic;

namespace Cookbook.Database;

public partial class RecipeStep
{
    public int Id { get; set; }

    public int RecipeId { get; set; }

    public string Text { get; set; } = null!;

    public virtual Recipe Recipe { get; set; } = null!;
}
