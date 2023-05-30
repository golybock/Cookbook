using System;
using System.Collections.Generic;

namespace Cookbook.Database;

public partial class RecipeStat
{
    public int Id { get; set; }

    public decimal Fats { get; set; }

    public decimal Squirrels { get; set; }

    public decimal Carbohydrates { get; set; }

    public decimal Kilocalories { get; set; }

    public int Portions { get; set; }

    public int CookingTime { get; set; }

    public virtual Recipe IdNavigation { get; set; } = null!;
}
