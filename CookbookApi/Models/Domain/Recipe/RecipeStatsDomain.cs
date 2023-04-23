namespace CookbookApi.Models.Domain.Recipe;

public class RecipeStatsDomain
{
    public decimal Fats { get; set; }
    
    public decimal Squirrels { get; set; }

    public decimal Carbohydrates { get; set; }

    public decimal Kilocalories { get; set; }
    
    public int Portions { get; set; }
    
    public DateTime CookingTime { get; set; }
}