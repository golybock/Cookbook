using CookbookApi.Models.Blank.Recipe.Ingredient;
using CookbookApi.Models.Domain.Recipe.Ingredient;

namespace CookbookApi.Models.Database.Recipe.Ingredient;

public class Measure
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public Measure() { }

    public Measure(int id)
    {
        Id = id;
    }

    public Measure(MeasureDomain measure)
    {
        Id = measure.Id;
        Name = measure.Name;
    }
    
    public Measure(MeasureBlank measure)
    {
        Name = measure.Name;
    }
}