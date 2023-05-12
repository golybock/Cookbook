using Models.Blank.Recipe;
using Models.Database.Recipe;
using Models.Domain.Recipe;

namespace Models.Builder.Blank.Recipe;

public class RecipeInfoBlankBuilder
{
    public static RecipeInfoBlank Create(RecipeInfoDomain recipeInfoDomain)
    {
        var blank = new RecipeInfoBlank();

        blank.SourceUrl = recipeInfoDomain.SourceUrl;
        blank.Description = recipeInfoDomain.Description;
        blank.Portions = recipeInfoDomain.Portions;
        blank.CookingTime = recipeInfoDomain.CookingTime;

        return blank;
    }
    
    public static RecipeInfoBlank Create(RecipeInfo recipeInfo)
    {
        var blank = new RecipeInfoBlank();

        blank.SourceUrl = recipeInfo.SourceUrl;
        blank.Description = recipeInfo.Description;
        blank.Portions = recipeInfo.Portions;
        blank.CookingTime = recipeInfo.CookingTime;
        
        return blank;
    }
}