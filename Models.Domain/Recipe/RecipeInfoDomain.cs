using System.Text.Json.Serialization;

namespace Models.Domain.Recipe;

public class RecipeInfoDomain
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