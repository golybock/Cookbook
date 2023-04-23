namespace CookbookApi.Models.Database.Recipe;

public class RecipeStats
{
    public int Id { get; set; } // recipe id
    
    public decimal Fats { get; set; }
    
    public decimal Squirrels { get; set; }

    public decimal Carbohydrates { get; set; }

    public decimal Kilocalories { get; set; }
    
    public int Portions { get; set; }
    
    public DateTime CookingTime { get; set; }
}