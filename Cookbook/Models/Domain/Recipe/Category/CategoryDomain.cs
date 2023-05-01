using System.Text.Json.Serialization;
using Cookbook.Models.Blank.Recipe.Category;

namespace Cookbook.Models.Domain.Recipe.Category;

public class CategoryDomain
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    public CategoryDomain() { }

    public CategoryDomain(CategoryBlank category)
    {
        Name = category.Name;
    }
}