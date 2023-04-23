namespace CookbookApi.Models.Database.Recipe.Ingredient;

public class Ingredient
{
    public int Id { get; set; }

    public int MeasureId { get; set; }

    public string Name { get; set; } = string.Empty;
}