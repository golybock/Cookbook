namespace Database.Recipe.Category;

public class RecipeCategory
{
    public int Id { get; set; }

    public int RecipeId { get; set; }

    public int CategoryId { get; set; }

    public RecipeCategory() { }

    public RecipeCategory(RecipeCategoryBlank recipeCategory)
    {
        CategoryId = recipeCategory.CategoryId;
        RecipeId = recipeCategory.RecipeId;
    }
}