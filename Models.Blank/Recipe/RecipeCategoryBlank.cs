using System.Text.Json.Serialization;

namespace Models.Blank.Recipe;

public class RecipeCategoryBlank
{
    [JsonPropertyName("categoryId")]
    public int CategoryId { get; set; }
}