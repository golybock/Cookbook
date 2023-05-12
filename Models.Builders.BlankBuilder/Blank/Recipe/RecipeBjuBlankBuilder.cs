using Models.Blank.Recipe;
using Models.Database.Recipe;
using Models.Domain.Recipe;

namespace Models.Builders.BlankBuilder.Blank.Recipe;

public static class RecipeBjuBlankBuilder
{
    public static RecipeBjuBlank Create(RecipeBjuDomain recipeBjuDomain)
    {
        var blank = new RecipeBjuBlank();

        blank.Fats = recipeBjuDomain.Fats;
        blank.Squirrels = recipeBjuDomain.Squirrels;
        blank.Carbohydrates = recipeBjuDomain.Carbohydrates;
        blank.Kilocalories = recipeBjuDomain.Kilocalories;

        return blank;
    }
    
    public static RecipeBjuBlank Create(RecipeBju recipeBju)
    {
        var blank = new RecipeBjuBlank();

        blank.Fats = recipeBju.Fats;
        blank.Squirrels = recipeBju.Squirrels;
        blank.Carbohydrates = recipeBju.Carbohydrates;
        blank.Kilocalories = recipeBju.Kilocalories;
        
        return blank;
    }
}