using CookbookApi.Models.Blank;
using CookbookApi.Models.Blank.Recipe;
using CookbookApi.Models.Database.Recipe;

namespace CookbookApi.Models.Domain.Recipe;

public class RecipeStepDomain
{
    public int RecipeId { get; set; }
    
    public int Number { get; set; }

    public string Text { get; set; } = string.Empty;

    public RecipeStepDomain() { }

    public RecipeStepDomain(RecipeStep recipeStep)
    {
        RecipeId = recipeStep.RecipeId;
        Number = recipeStep.Number;
        Text = recipeStep.Text;
    }
    
    public RecipeStepDomain(RecipeStepBlank recipeStep)
    {
        RecipeId = recipeStep.RecipeId;
        Number = recipeStep.Number;
        Text = recipeStep.Text;
    }
}