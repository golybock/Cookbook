using Models.Blank.Recipe.Ingredient;
using Models.Domain.Recipe.Ingredient;

namespace Models.Builder.Domain.Recipe.Ingredient;

public class IngredientDomainBuilder
{
    public static IngredientDomain Create(IngredientBlank ingredientBlank)
    {
        var blank = new IngredientDomain();

        blank.Name = ingredientBlank.Name;

        return blank;
    }
    
    public static IngredientDomain Create(Database.Recipe.Ingredient.Ingredient ingredient)
    {
        var blank = new IngredientDomain();

        blank.Id = ingredient.Id;
        blank.Name = ingredient.Name;

        return blank;
    }
    
    public static IngredientDomain Create(int id, string name)
    {
        var blank = new IngredientDomain();

        blank.Id = id;
        blank.Name = name;

        return blank;
    }
}