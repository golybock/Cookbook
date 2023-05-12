using Models.Blank.Recipe.Ingredient;
using Models.Database.Recipe.Ingredient;
using Models.Domain.Recipe.Ingredient;

namespace Models.Builder.Domain.Recipe.Ingredient;

public class MeasureDomainBuilder
{
    public static MeasureDomain Create(MeasureBlank measureBlank)
    {
        var blank = new MeasureDomain();

        blank.Name = measureBlank.Name;

        return blank;
    }
    
    public static MeasureDomain Create(Measure measure)
    {
        var blank = new MeasureDomain();

        blank.Id = measure.Id;
        blank.Name = measure.Name;

        return blank;
    }
    
    public static MeasureDomain Create(int id, string name)
    {
        var blank = new MeasureDomain();

        blank.Id = id;
        blank.Name = name;

        return blank;
    }
}