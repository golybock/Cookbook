using CookbookApi.Models.Database.Recipe;
using CookbookApi.Models.Domain.Recipe;

namespace CookbookApi.Models.Blank.Recipe;

public class RecipeStepBlank
{
    public int RecipeId { get; set; }
    
    public int Number { get; set; }

    public string Text { get; set; } = string.Empty;

    public RecipeStepBlank() { }

    public RecipeStepBlank(RecipeStep recipeStep)
    {
        RecipeId = recipeStep.RecipeId;
        Number = recipeStep.Number;
        Text = recipeStep.Text;
    }
    
    public RecipeStepBlank(RecipeStepDomain recipeStep)
    {
        RecipeId = recipeStep.RecipeId;
        Number = recipeStep.Number;
        Text = recipeStep.Text;
    }
}