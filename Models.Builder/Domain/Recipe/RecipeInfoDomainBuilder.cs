using Models.Blank.Recipe;
using Models.Database.Recipe;
using Models.Domain.Recipe;

namespace Models.Builder.Domain.Recipe;

public static class RecipeInfoDomainBuilder
{
    public static RecipeInfoDomain Create(RecipeInfoBlank recipeInfoBlank)
    {
        var blank = new RecipeInfoDomain();

        blank.SourceUrl = recipeInfoBlank.SourceUrl;
        blank.Description = recipeInfoBlank.Description;
        blank.Portions = recipeInfoBlank.Portions;
        blank.CookingTime = recipeInfoBlank.CookingTime;

        return blank;
    }
    
    public static RecipeInfoDomain Create(RecipeInfo recipeInfo)
    {
        var blank = new RecipeInfoDomain();

        blank.SourceUrl = recipeInfo.SourceUrl;
        blank.Description = recipeInfo.Description;
        blank.Portions = recipeInfo.Portions;
        blank.CookingTime = recipeInfo.CookingTime;
        
        return blank;
    }
}