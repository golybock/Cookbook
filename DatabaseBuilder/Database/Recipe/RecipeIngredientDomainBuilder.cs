using Models.Blank.Recipe;
using Models.Domain.Recipe;
using RecipeIngredientDatabase = Models.Database.Recipe.RecipeIngredient;

namespace DatabaseBuilder.Database.Recipe;

public static class RecipeIngredientDomainBuilder
{
    public static RecipeIngredientDatabase Create(RecipeIngredientBlank recipeIngredientBlank)
    {
        var database = new RecipeIngredientDatabase();

        database.Count = recipeIngredientBlank.Count;
        database.IngredientId = recipeIngredientBlank.IngredientId;
        database.MeasureId = recipeIngredientBlank.MeasureId;

        return database;
    }
    
    public static RecipeIngredientDatabase Create(RecipeIngredientDomain recipeIngredientDomain)
    {
        var database = new RecipeIngredientDatabase();
        
        database.Count = recipeIngredientDomain.Count;
        database.IngredientId = recipeIngredientDomain.IngredientId;
        database.MeasureId = recipeIngredientDomain.MeasureId;
        
        return database;
    }
}