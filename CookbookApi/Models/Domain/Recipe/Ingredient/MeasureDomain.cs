using CookbookApi.Models.Blank.Recipe.Ingredient;
using CookbookApi.Models.Database.Recipe.Ingredient;

namespace CookbookApi.Models.Domain.Recipe.Ingredient;

public class MeasureDomain
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public MeasureDomain() { }

    public MeasureDomain(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public MeasureDomain(Measure measure)
    {
        Id = measure.Id;
        Name = measure.Name;
    }
    
    public MeasureDomain(MeasureBlank measure)
    {
        Name = measure.Name;
    }
}