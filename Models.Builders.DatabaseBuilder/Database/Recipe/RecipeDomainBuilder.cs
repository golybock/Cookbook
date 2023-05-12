using Models.Blank.Recipe;
using Models.Domain.Recipe;
using Models.Domain.Recipe.Category;
using RecipeDatabase = Models.Database.Recipe.Recipe;

namespace Models.Builders.DatabaseBuilder.Database.Recipe;

public static class RecipeDomainBuilder
{
    public static RecipeDatabase Create(RecipeBlank recipeBlank)
    {
        var database = new RecipeDatabase();

        database.Header = recipeBlank.Header;
        

        return database;
    }

    public static RecipeDatabase Create(RecipeDomain recipeDomain)
    {
        var database = new RecipeDatabase();

        database.Header = recipeDomain.Header;

        return database;
    }
}