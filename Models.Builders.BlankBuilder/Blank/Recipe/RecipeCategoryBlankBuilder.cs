using Models.Blank.Recipe;
using Models.Blank.Recipe.Category;
using Models.Database.Recipe;
using Models.Database.Recipe.Category;

namespace Models.Builders.BlankBuilder.Blank.Recipe;

public static class RecipeCategoryBlankBuilder
{
    public static RecipeCategoryBlank Create(RecipeCategory recipeCategory)
    {
        var blank = new RecipeCategoryBlank();

        blank.CategoryId = recipeCategory.CategoryId;

        return blank;
    }
    
    public static RecipeCategoryBlank Create(int categoryId)
    {
        var blank = new RecipeCategoryBlank();

        blank.CategoryId = categoryId;
        
        return blank;
    }
}