using Blank.Recipe;
using Blank.Recipe.Category;
using Domain.Recipe;

namespace Builders.Blank.Recipe;

public class RecipeBlankBuilder
{
    public RecipeBlank Create(RecipeDomain recipeDomain)
    {
        var recipe = new RecipeBlank();
        
        recipe.TypeId = recipeDomain.TypeId;
        recipe.Header = recipeDomain.Header;
        recipe.Description = recipeDomain.Description;
        recipe.SourceUrl = recipeDomain.SourceUrl;
        
        if (recipeDomain.Stats != null)
            recipe.RecipeStats = RecipeStatsBuilder.Create(recipeDomain.Stats);
        
        return recipe;
    }
}