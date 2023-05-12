using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models.Blank.Recipe;

public class RecipeStepBlank
{
    [Range(0, Int32.MaxValue)]
    [JsonPropertyName("number")]
    public int Number { get; set; }
    
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;
}