using Models.Blank.Recipe;
using Models.Domain.Recipe;

namespace Models.Builder.Blank.Recipe;

public class RecipeBlankBuilder
{
    public static RecipeBlank Create(RecipeDomain recipeDomain)
    {
        var blank = new RecipeBlank();

        blank.Header = recipeDomain.Header;

        if (recipeDomain.Bju != null)
            blank.Bju = RecipeBjuBlankBuilder.Create(recipeDomain.Bju);

        if (recipeDomain.Info != null)
            blank.Info = RecipeInfoBlankBuilder.Create(recipeDomain.Info);

        foreach (var category in recipeDomain.Categories)
            blank.Categories.Add(
                new RecipeCategoryBlank() { CategoryId = category.Id }
            );

        foreach (var ingredient in recipeDomain.Ingredients)
            blank.Ingredients.Add(
                RecipeIngredientBlankBuilder.Create(ingredient)
            );

        foreach (var step in recipeDomain.Steps)
            blank.Steps.Add(
                RecipeStepBlankBuilder.Create(step)
            );

        return blank;
    }

    public static RecipeBlank Create(Database.Recipe.Recipe recipe)
    {
        var blank = new RecipeBlank();

        blank.Header = recipe.Header;

        return blank;
    }
}