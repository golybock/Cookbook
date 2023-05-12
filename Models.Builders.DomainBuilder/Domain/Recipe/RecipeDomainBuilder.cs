using Models.Blank.Recipe;
using Models.Domain.Recipe;
using Models.Domain.Recipe.Category;

namespace Models.Builders.DomainBuilder.Domain.Recipe;

public static class RecipeDomainBuilder
{
    public static RecipeDomain Create(RecipeBlank recipeBlank)
    {
        var blank = new RecipeDomain();

        blank.Header = recipeBlank.Header;

        if (recipeBlank.Bju != null)
            blank.Bju = RecipeBjuDomainBuilder.Create(recipeBlank.Bju);

        if (recipeBlank.Info != null)
            blank.Info = RecipeInfoDomainBuilder.Create(recipeBlank.Info);

        foreach (var category in recipeBlank.Categories)
            blank.Categories.Add(
                new CategoryDomain() { Id = category.CategoryId }
            );

        foreach (var ingredient in recipeBlank.Ingredients)
            blank.Ingredients.Add(
                RecipeIngredientDomainBuilder.Create(ingredient)
            );

        foreach (var step in recipeBlank.Steps)
            blank.Steps.Add(
                RecipeStepDomainBuilder.Create(step)
            );

        return blank;
    }

    public static RecipeDomain Create(Database.Recipe.Recipe recipe)
    {
        var blank = new RecipeDomain();

        blank.Header = recipe.Header;

        return blank;
    }
}