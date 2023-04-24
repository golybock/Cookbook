using CookbookApi.Models.Blank.Recipe.Category;
using CookbookApi.Models.Domain.Recipe.Category;

namespace CookbookApi.Models.Database.Recipe.Category;

public class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public Category() { }

    public Category(int id, string name)
    {
        Id = id;
        Name = name;
    }
    
    public Category(CategoryDomain category)
    {
        Id = category.Id;
        Name = category.Name;
    }
    
    public Category(CategoryBlank category)
    {
        Name = category.Name;
    }
}