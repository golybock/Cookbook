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

    public override string ToString()
    {
        string res = "";

        res += $"Жиры: {Fats}\n";
        res += $"Белки: {Squirrels}\n";
        res += $"Углеводы: {Carbohydrates}\n";
        res += $"Ккал: {Kilocalories}\n";
        res += $"Порций: {Portions}\n";
        res += $"Время приготовления: {CookingTime} минут\n";
        
        return res;
    }
}
