namespace CookbookApi.Models.Database.Client;

public class FavoriteRecipe
{
    public int Id { get; set; }

    public int RecipeId { get; set; }

    public int ClientId { get; set; }
    
}