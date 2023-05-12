using Models.Blank.Recipe.Category;
using Models.Domain.Recipe.Category;
using CategoryDatabase = Models.Database.Recipe.Category.Category;

namespace DatabaseBuilder.Database.Recipe.Category;

public static class CategoryDomainBuilder
{
    public static CategoryDatabase Create(CategoryDomain categoryDomain)
    {
        var database = new CategoryDatabase();

        database.Id = categoryDomain.Id;
        database.Name = categoryDomain.Name;

        return database;
    }
    
    public static CategoryDatabase Create(CategoryBlank categoryBlank)
    {
        var database = new CategoryDatabase();
        
        database.Name = categoryBlank.Name;

        return database;
    }
    
    public static CategoryDatabase Create(int id, string name)
    {
        var database = new CategoryDatabase();

        database.Id = id;
        database.Name = name;

        return database;
    }
}