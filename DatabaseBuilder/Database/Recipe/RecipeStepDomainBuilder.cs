using Models.Blank.Recipe;
using Models.Domain.Recipe;
using RecipeStepDatabase = Models.Database.Recipe.RecipeStep;

namespace DatabaseBuilder.Database.Recipe;

public static class RecipeStepDomainBuilder
{
    public static RecipeStepDatabase Create(RecipeStepBlank recipeStepBlank)
    {
        var blank = new RecipeStepDatabase();

        blank.Number = recipeStepBlank.Number;
        blank.Text = recipeStepBlank.Text;
        
        return blank;
    }
    
    public static RecipeStepDatabase Create(RecipeStepDomain recipeStepDomain)
    {
        var blank = new RecipeStepDatabase();
        
        blank.Number = recipeStepDomain.Number;
        blank.Text = recipeStepDomain.Text;
        
        return blank;
    }
    
    public static RecipeStepDatabase Create(int number, string text)
    {
        var blank = new RecipeStepDatabase();

        blank.Number = number;
        blank.Text = text;
        
        return blank;
    }
}