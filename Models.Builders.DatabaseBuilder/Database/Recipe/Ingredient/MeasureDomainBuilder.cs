using Models.Blank.Recipe.Ingredient;
using Models.Domain.Recipe.Ingredient;
using MeasureDatabase = Models.Database.Recipe.Ingredient.Measure;

namespace Models.Builders.DatabaseBuilder.Database.Recipe.Ingredient;

public static class MeasureDomainBuilder
{
    public static MeasureDatabase Create(MeasureBlank measureBlank)
    {
        var database = new MeasureDatabase();

        database.Name = measureBlank.Name;

        return database;
    }
    
    public static MeasureDatabase Create(MeasureDomain measureDomain)
    {
        var database = new MeasureDatabase();

        database.Id = measureDomain.Id;
        database.Name = measureDomain.Name;

        return database;
    }
    
    public static MeasureDatabase Create(int id, string name)
    {
        var database = new MeasureDatabase();

        database.Id = id;
        database.Name = name;

        return database;
    }
}