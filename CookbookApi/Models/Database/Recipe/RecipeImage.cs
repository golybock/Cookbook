using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CookbookApi.Models.Database.Recipe;

public class RecipeImage
{
    public int Id { get; set; }

    public int RecipeId { get; set; }
    
    public string Path { get; set; } = string.Empty;
}