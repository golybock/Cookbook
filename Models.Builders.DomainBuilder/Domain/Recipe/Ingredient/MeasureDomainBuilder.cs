using Models.Blank.Recipe.Ingredient;
using Models.Database.Recipe.Ingredient;
using Models.Domain.Recipe.Ingredient;

namespace Models.Builders.DomainBuilder.Domain.Recipe.Ingredient;

public static class MeasureDomainBuilder
{
    public static MeasureDomain Create(MeasureBlank measureBlank)
    {
        var domain = new MeasureDomain();

        domain.Name = measureBlank.Name;

        return domain;
    }
    
    public static MeasureDomain Create(Measure measure)
    {
        var domain = new MeasureDomain();

        domain.Id = measure.Id;
        domain.Name = measure.Name;

        return domain;
    }
    
    public static MeasureDomain Create(int id, string name)
    {
        var domain = new MeasureDomain();

        domain.Id = id;
        domain.Name = name;

        return domain;
    }
}