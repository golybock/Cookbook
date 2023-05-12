using Models.Blank.Recipe;
using Models.Domain.Recipe;
using RecipeBjuDatabase = Models.Database.Recipe.RecipeBju;

namespace Models.Builders.DatabaseBuilder.Database.Recipe;

public static class RecipeBjuDomainBuilder
{
    public static RecipeBjuDatabase Create(RecipeBjuDomain recipeBjuDomain)
    {
        var database = new RecipeBjuDatabase();

        database.Fats = recipeBjuDomain.Fats;
        database.Squirrels = recipeBjuDomain.Squirrels;
        database.Carbohydrates = recipeBjuDomain.Carbohydrates;
        database.Kilocalories = recipeBjuDomain.Kilocalories;

        return database;
    }
    
    public static RecipeBjuDatabase Create(RecipeBjuBlank recipeBjuBlank)
    {
        var database = new RecipeBjuDatabase();
        
        database.Fats = recipeBjuBlank.Fats;
        database.Squirrels = recipeBjuBlank.Squirrels;
        database.Carbohydrates = recipeBjuBlank.Carbohydrates;
        database.Kilocalories = recipeBjuBlank.Kilocalories;
        
        return database;
    }
}