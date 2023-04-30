using CookbookApi.Models.Blank;
using CookbookApi.Models.Blank.Recipe;
using CookbookApi.Models.Domain.Recipe;

namespace CookbookApi.Models.Database.Recipe;

public class RecipeStep
{
    public int Id { get; set; }
    
    public int RecipeId { get; set; }
    
    public int Number { get; set; }

    public string Text { get; set; } = string.Empty;

    public RecipeStep() { }

    public RecipeStep(RecipeStepBlank recipeStep)
    {
        RecipeId = recipeStep.RecipeId;
        Number = recipeStep.Number;
        Text = recipeStep.Text;
    }

    public RecipeStep(RecipeStepDomain recipeStep)
    {
        RecipeId = recipeStep.RecipeId;
        Number = recipeStep.Number;
        Text = recipeStep.Text;
    }
}