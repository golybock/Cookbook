using Models.Blank.Recipe;
using Models.Database.Recipe;
using Models.Domain.Recipe;

namespace Models.Builders.DomainBuilder.Domain.Recipe;

public static class RecipeIngredientDomainBuilder
{
    public static RecipeIngredientDomain Create(RecipeIngredientBlank recipeIngredientBlank)
    {
        var domain = new RecipeIngredientDomain();

        domain.Count = recipeIngredientBlank.Count;
        domain.IngredientId = recipeIngredientBlank.IngredientId;
        domain.MeasureId = recipeIngredientBlank.MeasureId;

        return domain;
    }
    
    public static RecipeIngredientDomain Create(RecipeIngredient recipeIngredient)
    {
        var domain = new RecipeIngredientDomain();
        
        domain.Count = recipeIngredient.Count;
        domain.IngredientId = recipeIngredient.IngredientId;
        domain.MeasureId = recipeIngredient.MeasureId;
        
        return domain;
    }
}