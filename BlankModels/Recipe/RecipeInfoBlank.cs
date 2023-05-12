using System.Text.Json.Serialization;

namespace BlankModels.Recipe;

public class RecipeInfoBlank
{
    [JsonPropertyName("sourceUrl")]
    public string? SourceUrl { get; set; }
    
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    
    [JsonPropertyName("portions")]
    public int Portions { get; set; }
    
    [JsonPropertyName("cookingTime")]
    public int CookingTime { get; set; }
}