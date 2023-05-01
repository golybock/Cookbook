using System.Text.Json.Serialization;
using Cookbook.Models.Domain.Recipe.Category;

namespace Cookbook.Models.Blank.Recipe.Category;

public class CategoryBlank
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    public CategoryBlank() { }

    public CategoryBlank(string name)
    {
        Name = name;
    }

    public CategoryBlank(CategoryDomain category)
    {
        Name = category.Name;
    }
}