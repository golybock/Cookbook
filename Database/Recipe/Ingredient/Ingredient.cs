namespace Database.Recipe.Ingredient;

public class Ingredient
{
    public int Id { get; set; }

    public int MeasureId { get; set; }

    public string Name { get; set; } = string.Empty;

    public Ingredient() { }

    public Ingredient(IngredientBlank ingredient)
    {
        MeasureId = ingredient.MeasureId;
        Name = ingredient.Name;
    }
    
    public Ingredient(IngredientDomain ingredient)
    {
        Id = ingredient.Id;
        MeasureId = ingredient.MeasureId;
        Name = ingredient.Name;
    }
}