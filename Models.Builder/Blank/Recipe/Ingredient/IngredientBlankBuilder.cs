using Models.Blank.Recipe.Ingredient;
using Models.Domain.Recipe.Ingredient;

namespace Models.Builder.Blank.Recipe.Ingredient;

public class IngredientBlankBuilder
{
    public static IngredientBlank Create(IngredientDomain ingredientDomain)
    {
        var blank = new IngredientBlank();

        blank.Name = ingredientDomain.Name;

        return blank;
    }
    
    public static IngredientBlank Create(Database.Recipe.Ingredient.Ingredient ingredient)
    {
        var blank = new IngredientBlank();

        blank.Name = ingredient.Name;

        return blank;
    }
    
    public static IngredientBlank Create(string name)
    {
        var blank = new IngredientBlank();

        blank.Name = name;

        return blank;
    }
}