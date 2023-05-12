using Models.Blank.Recipe;
using Models.Database.Recipe;

namespace Models.Builders.DomainBuilder.Domain.Recipe;

public static class RecipeCategoryBlankBuilder
{
    public static RecipeCategoryBlank Create(RecipeCategory recipeCategory)
    {
        var domain = new RecipeCategoryBlank();

        domain.CategoryId = recipeCategory.CategoryId;

        return domain;
    }
    
    public static RecipeCategoryBlank Create(int categoryId)
    {
        var domain = new RecipeCategoryBlank();

        domain.CategoryId = categoryId;
        
        return domain;
    }
}