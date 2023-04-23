namespace CookbookApi.Models.Domain.Recipe.Ingredient;

public class IngredientDomain
{
    public int Id { get; set; }

    public int MeasureId { get; set; }

    public string Name { get; set; } = string.Empty;
}