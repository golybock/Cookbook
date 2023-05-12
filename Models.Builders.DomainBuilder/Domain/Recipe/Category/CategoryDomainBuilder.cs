using Models.Blank.Recipe.Category;
using Models.Domain.Recipe.Category;

namespace Models.Builders.DomainBuilder.Domain.Recipe.Category;

public static class CategoryDomainBuilder
{
    public static CategoryDomain Create(CategoryBlank categoryBlank)
    {
        var domain = new CategoryDomain();

        domain.Name = categoryBlank.Name;

        return domain;
    }
    
    public static CategoryDomain Create(Database.Recipe.Category.Category category)
    {
        var domain = new CategoryDomain();

        domain.Id = category.Id;
        domain.Name = category.Name;

        return domain;
    }
    
    public static CategoryDomain Create(int id, string name)
    {
        var domain = new CategoryDomain();

        domain.Id = id;
        domain.Name = name;

        return domain;
    }
}