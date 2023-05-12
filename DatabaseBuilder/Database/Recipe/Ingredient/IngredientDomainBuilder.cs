using Models.Blank.Recipe.Ingredient;
using Models.Domain.Recipe.Ingredient;
using IngredientDatabase = Models.Database.Recipe.Ingredient.Ingredient;

namespace DatabaseBuilder.Database.Recipe.Ingredient;

public static class IngredientDomainBuilder
{
    public static IngredientDatabase Create(IngredientBlank ingredientBlank)
    {
        var database = new IngredientDatabase();

        database.Name = ingredientBlank.Name;

        return database;
    }
    
    public static IngredientDatabase Create(IngredientDomain ingredientDomain)
    {
        var database = new IngredientDatabase();

        database.Id = ingredientDomain.Id;
        database.Name = ingredientDomain.Name;

        return database;
    }
    
    public static IngredientDatabase Create(int id, string name)
    {
        var database = new IngredientDatabase();

        database.Id = id;
        database.Name = name;

        return database;
    }
}