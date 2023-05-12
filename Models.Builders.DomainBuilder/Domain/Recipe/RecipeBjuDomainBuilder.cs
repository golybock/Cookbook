using Models.Blank.Recipe;
using Models.Database.Recipe;
using Models.Domain.Recipe;

namespace Models.Builders.DomainBuilder.Domain.Recipe;

public static class RecipeBjuDomainBuilder
{
    public static RecipeBjuDomain Create(RecipeBjuBlank recipeBjuBlank)
    {
        var blank = new RecipeBjuDomain();

        blank.Fats = recipeBjuBlank.Fats;
        blank.Squirrels = recipeBjuBlank.Squirrels;
        blank.Carbohydrates = recipeBjuBlank.Carbohydrates;
        blank.Kilocalories = recipeBjuBlank.Kilocalories;

        return blank;
    }
    
    public static RecipeBjuDomain Create(RecipeBju recipeBju)
    {
        var blank = new RecipeBjuDomain();
        
        blank.Fats = recipeBju.Fats;
        blank.Squirrels = recipeBju.Squirrels;
        blank.Carbohydrates = recipeBju.Carbohydrates;
        blank.Kilocalories = recipeBju.Kilocalories;
        
        return blank;
    }
}