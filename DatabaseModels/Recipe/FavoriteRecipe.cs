namespace DatabaseModels.Recipe;

public class FavoriteRecipe
{
    public int Id { get; set; }
    
    public int RecipeId { get; set; }
    
    public int ClientId { get; set; }
}