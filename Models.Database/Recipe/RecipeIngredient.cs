namespace Models.Database.Recipe;

public class RecipeIngredient
{
    public int Id { get; set; }

    public int RecipeId { get; set; }
    
    public int IngredientId { get; set; }
    
    public int MeasureId { get; set; }
    
    public decimal Count { get; set; }
}