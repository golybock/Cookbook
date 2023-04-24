using CookbookApi.Models.Database.Recipe.Category;
using CookbookApi.Models.Domain.Recipe.Category;

namespace CookbookApi.Models.Blank.Recipe.Category;

public class RecipeCategoryBlank
{
    public int CategoryId { get; set; }
    
    public int RecipeId { get; set; }

    public RecipeCategoryBlank() { }

    public RecipeCategoryBlank(int categoryId, int recipeId)
    {
        RecipeId = recipeId;
        CategoryId = categoryId;
    }

    public RecipeCategoryBlank(RecipeCategory recipeCategory)
    {
        CategoryId = recipeCategory.CategoryId;
        RecipeId = recipeCategory.RecipeId;
    }
    
    public RecipeCategoryBlank(CategoryDomain recipeCategory)
    {
        CategoryId = recipeCategory.Id;
    }

}