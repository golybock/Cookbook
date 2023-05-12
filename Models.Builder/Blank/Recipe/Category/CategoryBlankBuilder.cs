using Models.Blank.Recipe.Category;
using Models.Domain.Recipe.Category;

namespace Models.Builder.Blank.Recipe.Category;

public class CategoryBlankBuilder
{
    public static CategoryBlank Create(CategoryDomain categoryDomain)
    {
        var blank = new CategoryBlank();

        blank.Name = categoryDomain.Name;

        return blank;
    }
    
    public static CategoryBlank Create(Database.Recipe.Category.Category category)
    {
        var blank = new CategoryBlank();

        blank.Name = category.Name;

        return blank;
    }
    
    public static CategoryBlank Create(string name)
    {
        var blank = new CategoryBlank();

        blank.Name = name;

        return blank;
    }
}