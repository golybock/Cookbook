using System;
using System.Collections.Generic;

namespace Cookbook.Database;

public partial class RecipeView
{
    public int Id { get; set; }

    public int? RecipeId { get; set; }

    public DateTime Datetime { get; set; }

    public virtual Recipe? Recipe { get; set; }
}