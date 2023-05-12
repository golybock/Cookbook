using Models.Blank.Recipe.Category;
using Models.Domain.Recipe.Category;

namespace Models.Builder.Domain.Recipe.Category;

public class CategoryDomainBuilder
{
    public static CategoryDomain Create(CategoryBlank categoryBlank)
    {
        var blank = new CategoryDomain();

        blank.Name = categoryBlank.Name;

        return blank;
    }
    
    public static CategoryDomain Create(Database.Recipe.Category.Category category)
    {
        var blank = new CategoryDomain();

        blank.Id = category.Id;
        blank.Name = category.Name;

        return blank;
    }
    
    public static CategoryDomain Create(int id, string name)
    {
        var blank = new CategoryDomain();

        blank.Id = id;
        blank.Name = name;

        return blank;
    }
}