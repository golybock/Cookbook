using Models.Blank.Recipe.Ingredient;
using Models.Database.Recipe.Ingredient;
using Models.Domain.Recipe.Ingredient;

namespace Models.Builders.BlankBuilder.Blank.Recipe.Ingredient;

public static class MeasureBlankBuilder
{
    public static MeasureBlank Create(MeasureDomain measureDomain)
    {
        var blank = new MeasureBlank();

        blank.Name = measureDomain.Name;

        return blank;
    }
    
    public static MeasureBlank Create(Measure measure)
    {
        var blank = new MeasureBlank();

        blank.Name = measure.Name;

        return blank;
    }
    
    public static MeasureBlank Create(string name)
    {
        var blank = new MeasureBlank();

        blank.Name = name;

        return blank;
    }
}