using CookbookApi.Models.Domain.Recipe.Ingredient;

namespace CookbookApi.Models.Blank.Recipe.Ingredient;

public class IngredientBlank
{
    public int MeasureId { get; set; }

    public string Name { get; set; } = string.Empty;

    public IngredientBlank() { }

    public IngredientBlank(int measureId, string name)
    {
        MeasureId = measureId;
        Name = name;
    }

    public IngredientBlank(Database.Recipe.Ingredient.Ingredient ingredient)
    {
        MeasureId = ingredient.MeasureId;
        Name = ingredient.Name;
    }

    public IngredientBlank(IngredientDomain ingredient)
    {
        MeasureId = ingredient.MeasureId;
        Name = ingredient.Name;
    }
}