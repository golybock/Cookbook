using Models.Blank.Recipe;
using Models.Database.Recipe;
using Models.Domain.Recipe;

namespace Models.Builders.DomainBuilder.Domain.Recipe;

public static class RecipeIngredientDomainBuilder
{
    public static RecipeIngredientDomain Create(RecipeIngredientBlank recipeIngredientBlank)
    {
        var blank = new RecipeIngredientDomain();

        blank.Count = recipeIngredientBlank.Count;
        blank.IngredientId = recipeIngredientBlank.IngredientId;
        blank.MeasureId = recipeIngredientBlank.MeasureId;

        return blank;
    }
    
    public static RecipeIngredientDomain Create(RecipeIngredient recipeIngredient)
    {
        var blank = new RecipeIngredientDomain();
        
        blank.Count = recipeIngredient.Count;
        blank.IngredientId = recipeIngredient.IngredientId;
        blank.MeasureId = recipeIngredient.MeasureId;
        
        return blank;
    }
}