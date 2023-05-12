using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models.Blank.Recipe.Category;

public class RecipeCategoryBlank
{
    [Range(1, Int32.MaxValue)]
    [JsonPropertyName("categoryId")]
    public int CategoryId { get; set; }
}