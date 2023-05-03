using Blank.Recipe.Category;
using Domain.Recipe.Category;

namespace Builders.Blank.Recipe.Category;

public class CategoryBlankBuilder
{
    public CategoryBlank Create(string name)
    {
        return new CategoryBlank() {Name = name};
    }
    
    public CategoryBlank Create(CategoryDomain categoryDomain)
    {
        return new CategoryBlank() {Name = categoryDomain.Name};
    }
}