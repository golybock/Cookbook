using Models.Blank.Recipe;
using Models.Database.Recipe;
using Models.Domain.Recipe;

namespace Models.Builder.Blank.Recipe;

public class RecipeIngredientBlankBuilder
{
    public static RecipeIngredientBlank Create(RecipeIngredientDomain recipeIngredientDomain)
    {
        var blank = new RecipeIngredientBlank();

        blank.Count = recipeIngredientDomain.Count;
        blank.IngredientId = recipeIngredientDomain.IngredientId;
        blank.MeasureId = recipeIngredientDomain.MeasureId;

        return blank;
    }
    
    public static RecipeIngredientBlank Create(RecipeIngredient recipeIngredient)
    {
        var blank = new RecipeIngredientBlank();

        blank.Count = recipeIngredient.Count;
        blank.IngredientId = recipeIngredient.IngredientId;
        blank.MeasureId = recipeIngredient.MeasureId;
        
        return blank;
    }
}