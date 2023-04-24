using CookbookApi.Models.Blank.Recipe.Category;

namespace CookbookApi.Models.Domain.Recipe.Category;

public class CategoryDomain
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public CategoryDomain() { }

    public CategoryDomain(Database.Recipe.Category.Category category)
    {
        Id = category.Id;
        Name = category.Name;
    }
    
    public CategoryDomain(CategoryBlank category)
    {
        Name = category.Name;
    }
}