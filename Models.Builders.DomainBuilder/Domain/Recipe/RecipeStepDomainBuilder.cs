using Models.Blank.Recipe;
using Models.Database.Recipe;
using Models.Domain.Recipe;

namespace Models.Builders.DomainBuilder.Domain.Recipe;

public static class RecipeStepDomainBuilder
{
    public static RecipeStepDomain Create(RecipeStepBlank recipeStepBlank)
    {
        var blank = new RecipeStepDomain();

        blank.Number = recipeStepBlank.Number;
        blank.Text = recipeStepBlank.Text;
        
        return blank;
    }
    
    public static RecipeStepDomain Create(RecipeStep recipeStep)
    {
        var blank = new RecipeStepDomain();
        
        blank.Number = recipeStep.Number;
        blank.Text = recipeStep.Text;
        
        return blank;
    }
    
    public static RecipeStepDomain Create(int number, string text)
    {
        var blank = new RecipeStepDomain();

        blank.Number = number;
        blank.Text = text;
        
        return blank;
    }
}