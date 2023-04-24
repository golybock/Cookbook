using CookbookApi.Models.Database.Recipe.Ingredient;
using CookbookApi.Models.Domain.Recipe.Ingredient;

namespace CookbookApi.Models.Blank.Recipe.Ingredient;

public class MeasureBlank
{
    public string Name { get; set; } = string.Empty;

    public MeasureBlank() { }

    public MeasureBlank(string name)
    {
        Name = name;
    }

    public MeasureBlank(Measure measure)
    {
        Name = measure.Name;
    }
    
    public MeasureBlank(MeasureDomain measure)
    {
        Name = measure.Name;
    }
}