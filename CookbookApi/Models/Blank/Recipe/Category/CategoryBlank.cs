using CookbookApi.Models.Domain.Recipe.Category;

namespace CookbookApi.Models.Blank.Recipe.Category;

public class CategoryBlank
{
    public string Name { get; set; } = string.Empty;

    public CategoryBlank() { }

    public CategoryBlank(string name)
    {
        Name = name;
    }

    public CategoryBlank(Database.Recipe.Category.Category category)
    {
        Name = category.Name;
    }

    public CategoryBlank(CategoryDomain category)
    {
        Name = category.Name;
    }
}