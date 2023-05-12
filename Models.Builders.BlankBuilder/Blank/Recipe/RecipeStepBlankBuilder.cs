using Models.Blank.Recipe;
using Models.Database.Recipe;
using Models.Domain.Recipe;

namespace Models.Builders.BlankBuilder.Blank.Recipe;

public static class RecipeStepBlankBuilder
{
    public static RecipeStepBlank Create(RecipeStepDomain recipeStepDomain)
    {
        var blank = new RecipeStepBlank();

        blank.Number = recipeStepDomain.Number;
        blank.Text = recipeStepDomain.Text;
        
        return blank;
    }
    
    public static RecipeStepBlank Create(RecipeStep recipeStep)
    {
        var blank = new RecipeStepBlank();
        
        blank.Number = recipeStep.Number;
        blank.Text = recipeStep.Text;
        
        return blank;
    }
    
    public static RecipeStepBlank Create(int number, string text)
    {
        var blank = new RecipeStepBlank();

        blank.Number = number;
        blank.Text = text;
        
        return blank;
    }
}