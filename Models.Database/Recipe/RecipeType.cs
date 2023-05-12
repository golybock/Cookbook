namespace Models.Database.Recipe;

public class RecipeType
{
    public int Id { get; set; }
    
    public int RecipeId { get; set;}
    
    public int TypeId { get; set; }
    
    public DateTime Timestamp { get; set; }
}