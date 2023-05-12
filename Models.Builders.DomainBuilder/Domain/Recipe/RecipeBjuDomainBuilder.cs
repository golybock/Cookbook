using Models.Blank.Recipe;
using Models.Database.Recipe;
using Models.Domain.Recipe;

namespace Models.Builders.DomainBuilder.Domain.Recipe;

public static class RecipeBjuDomainBuilder
{
    public static RecipeBjuDomain Create(RecipeBjuBlank recipeBjuBlank)
    {
        var domain = new RecipeBjuDomain();

        domain.Fats = recipeBjuBlank.Fats;
        domain.Squirrels = recipeBjuBlank.Squirrels;
        domain.Carbohydrates = recipeBjuBlank.Carbohydrates;
        domain.Kilocalories = recipeBjuBlank.Kilocalories;

        return domain;
    }
    
    public static RecipeBjuDomain Create(RecipeBju recipeBju)
    {
        var domain = new RecipeBjuDomain();
        
        domain.Fats = recipeBju.Fats;
        domain.Squirrels = recipeBju.Squirrels;
        domain.Carbohydrates = recipeBju.Carbohydrates;
        domain.Kilocalories = recipeBju.Kilocalories;
        
        return domain;
    }
}