namespace DatabaseModels.Recipe;

public class RecipeInfo
{
    // recipeId
    public int Id { get; set; }
    
    public string? ImagePath { get; set; }
    
    public string? SourceUrl { get; set; }
    
    public string? Description { get; set; }
    
    public int Portions { get; set; }
    
    // minutes
    public int CookingTime { get; set; }
}