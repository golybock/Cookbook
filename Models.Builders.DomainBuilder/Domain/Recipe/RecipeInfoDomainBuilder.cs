using Models.Blank.Recipe;
using Models.Database.Recipe;
using Models.Domain.Recipe;

namespace Models.Builders.DomainBuilder.Domain.Recipe;

public static class RecipeInfoDomainBuilder
{
    public static RecipeInfoDomain Create(RecipeInfoBlank recipeInfoBlank)
    {
        var domain = new RecipeInfoDomain();

        domain.SourceUrl = recipeInfoBlank.SourceUrl;
        domain.Description = recipeInfoBlank.Description;
        domain.Portions = recipeInfoBlank.Portions;
        domain.CookingTime = recipeInfoBlank.CookingTime;

        return domain;
    }
    
    public static RecipeInfoDomain Create(RecipeInfo recipeInfo)
    {
        var domain = new RecipeInfoDomain();

        domain.SourceUrl = recipeInfo.SourceUrl;
        domain.Description = recipeInfo.Description;
        domain.Portions = recipeInfo.Portions;
        domain.CookingTime = recipeInfo.CookingTime;
        
        return domain;
    }
}