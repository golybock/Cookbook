
using Models.Blank.Recipe;
using Models.Domain.Recipe;
using Models.Domain.Recipe.Category;

namespace Models.Builders.DomainBuilder.Domain.Recipe;

public static class RecipeDomainBuilder
{
    public static RecipeDomain Create(RecipeBlank recipeBlank)
    {
        var domain = new RecipeDomain();

        domain.Header = recipeBlank.Header;

        if (recipeBlank.Bju != null)
            domain.Bju = RecipeBjuDomainBuilder.Create(recipeBlank.Bju);

        if (recipeBlank.Info != null)
            domain.Info = RecipeInfoDomainBuilder.Create(recipeBlank.Info);

        foreach (var category in recipeBlank.Categories)
            domain.Categories.Add(
                new CategoryDomain() { Id = category.CategoryId }
            );

        foreach (var ingredient in recipeBlank.Ingredients)
            domain.Ingredients.Add(
                RecipeIngredientDomainBuilder.Create(ingredient)
            );

        foreach (var step in recipeBlank.Steps)
            domain.Steps.Add(
                RecipeStepDomainBuilder.Create(step)
            );

        return domain;
    }

    public static RecipeDomain Create(Database.Recipe.Recipe recipe)
    {
        var domain = new RecipeDomain();

        domain.Header = recipe.Header;

        return domain;
    }
}