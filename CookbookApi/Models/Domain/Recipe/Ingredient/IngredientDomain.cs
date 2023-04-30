namespace CookbookApi.Models.Domain.Recipe.Ingredient;

public class IngredientDomain
{
    public int Id { get; set; }

    public int MeasureId { get; set; }

    public string Name { get; set; } = string.Empty;

    public MeasureDomain? Measure = new MeasureDomain();

    public IngredientDomain() { }

    public IngredientDomain(Database.Recipe.Ingredient.Ingredient ingredient)
    {
        Id = ingredient.Id;
        Name = ingredient.Name;
        MeasureId = ingredient.MeasureId;
    }
    
    public IngredientDomain(IngredientDomain ingredient)
    {
        Id = ingredient.Id;
        Name = ingredient.Name;
        MeasureId = ingredient.MeasureId;
    }
}