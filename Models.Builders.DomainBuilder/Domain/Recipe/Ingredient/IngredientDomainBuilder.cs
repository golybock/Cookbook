using Models.Blank.Recipe.Ingredient;
using Models.Domain.Recipe.Ingredient;

namespace Models.Builders.DomainBuilder.Domain.Recipe.Ingredient;

public static class IngredientDomainBuilder
{
    public static IngredientDomain Create(IngredientBlank ingredientBlank)
    {
        var domain = new IngredientDomain();

        domain.Name = ingredientBlank.Name;

        return domain;
    }
    
    public static IngredientDomain Create(Database.Recipe.Ingredient.Ingredient ingredient)
    {
        var domain = new IngredientDomain();

        domain.Id = ingredient.Id;
        domain.Name = ingredient.Name;

        return domain;
    }
    
    public static IngredientDomain Create(int id, string name)
    {
        var domain = new IngredientDomain();

        domain.Id = id;
        domain.Name = name;

        return domain;
    }
}