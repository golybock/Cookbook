using Models.Blank.Recipe;
using RecipeCategoryDatabase = Models.Database.Recipe.RecipeCategory;

namespace DatabaseBuilder.Database.Recipe;

public static class RecipeCategoryBlankBuilder
{
    public static RecipeCategoryDatabase Create(RecipeCategoryBlank recipeCategoryBlank)
    {
        var database = new RecipeCategoryDatabase();
        
        database.CategoryId = recipeCategoryBlank.CategoryId;

        return database;
    }

    public static RecipeCategoryDatabase Create(int categoryId)
    {
        var database = new RecipeCategoryDatabase();

        database.CategoryId = categoryId;
        
        return database;
    }
}