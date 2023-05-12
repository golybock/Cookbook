using Models.Blank.Recipe;
using Models.Database.Recipe;
using Models.Domain.Recipe;

namespace Models.Builders.DomainBuilder.Domain.Recipe;

public static class RecipeStepDomainBuilder
{
    public static RecipeStepDomain Create(RecipeStepBlank recipeStepBlank)
    {
        var domain = new RecipeStepDomain();

        domain.Number = recipeStepBlank.Number;
        domain.Text = recipeStepBlank.Text;
        
        return domain;
    }
    
    public static RecipeStepDomain Create(RecipeStep recipeStep)
    {
        var domain = new RecipeStepDomain();
        
        domain.Number = recipeStep.Number;
        domain.Text = recipeStep.Text;
        
        return domain;
    }
    
    public static RecipeStepDomain Create(int number, string text)
    {
        var domain = new RecipeStepDomain();

        domain.Number = number;
        domain.Text = text;
        
        return domain;
    }
}