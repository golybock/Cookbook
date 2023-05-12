using Models.Blank.Recipe;
using Models.Blank.Recipe.Ingredient;
using Models.Database.Recipe;
using Models.Database.Recipe.Ingredient;
using Models.Domain.Recipe;
using Models.Domain.Recipe.Ingredient;

namespace Models.Builders.DomainBuilder.Domain.Recipe;

public static class RecipeIngredientDomainBuilder
{
    public static RecipeIngredientDomain Create(RecipeIngredientBlank recipeIngredientBlank)
    {
        var domain = new RecipeIngredientDomain();

        domain.Count = recipeIngredientBlank.Count;
        domain.IngredientId = recipeIngredientBlank.IngredientId;
        domain.MeasureId = recipeIngredientBlank.MeasureId;

        return domain;
    }
    
    public static RecipeIngredientDomain Create(RecipeIngredient recipeIngredient)
    {
        var domain = new RecipeIngredientDomain();
        
        domain.Count = recipeIngredient.Count;
        domain.IngredientId = recipeIngredient.IngredientId;
        domain.MeasureId = recipeIngredient.MeasureId;
        
        return domain;
    }
}