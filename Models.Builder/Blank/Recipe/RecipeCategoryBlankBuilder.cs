using Models.Blank.Recipe;
using Models.Database.Recipe;

namespace Models.Builder.Blank.Recipe;

public class RecipeCategoryBlankBuilder
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