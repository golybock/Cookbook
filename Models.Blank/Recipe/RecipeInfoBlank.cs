using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models.Blank.Recipe;

public class RecipeInfoBlank
{
    [StringLength(500)]
    [JsonPropertyName("sourceUrl")]
    public string? SourceUrl { get; set; }
    
    [StringLength(200)]
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    
    [Range(1, Int32.MaxValue)]
    [JsonPropertyName("portions")]
    public int Portions { get; set; }
    
    [Range(0, Int32.MaxValue)]
    [JsonPropertyName("cookingTime")]
    public int CookingTime { get; set; }
}