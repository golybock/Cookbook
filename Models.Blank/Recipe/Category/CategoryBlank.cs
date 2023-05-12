using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models.Blank.Recipe.Category;

public class CategoryBlank
{
    [JsonPropertyName("name")]
    [StringLength(150)]
    public string Name { get; set; } = string.Empty;
}