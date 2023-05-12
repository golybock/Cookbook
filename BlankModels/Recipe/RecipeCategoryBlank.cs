using System.Text.Json.Serialization;

namespace BlankModels.Recipe;

public class RecipeCategoryBlank
{
    [JsonPropertyName("categoryId")]
    public int CategoryId { get; set; }
}