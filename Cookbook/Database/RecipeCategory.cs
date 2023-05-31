using System;
using System.Collections.Generic;

namespace Cookbook.Database;

public partial class RecipeCategory
{
    public int Id { get; set; }

    public int? RecipeId { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Recipe? Recipe { get; set; }
}