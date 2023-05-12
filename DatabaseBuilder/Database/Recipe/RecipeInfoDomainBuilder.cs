using Models.Blank.Recipe;
using Models.Domain.Recipe;
using RecipeInfoDatabase = Models.Database.Recipe.RecipeInfo;

namespace DatabaseBuilder.Database.Recipe;

public static class RecipeInfoDomainBuilder
{
    public static RecipeInfoDatabase Create(RecipeInfoBlank recipeInfoBlank)
    {
        var database = new RecipeInfoDatabase();

        database.SourceUrl = recipeInfoBlank.SourceUrl;
        database.Description = recipeInfoBlank.Description;
        database.Portions = recipeInfoBlank.Portions;
        database.CookingTime = recipeInfoBlank.CookingTime;

        return database;
    }
    
    public static RecipeInfoDatabase Create(RecipeInfoDomain recipeInfoDomain)
    {
        var database = new RecipeInfoDatabase();

        database.SourceUrl = recipeInfoDomain.SourceUrl;
        database.Description = recipeInfoDomain.Description;
        database.Portions = recipeInfoDomain.Portions;
        database.CookingTime = recipeInfoDomain.CookingTime;
        
        return database;
    }
}