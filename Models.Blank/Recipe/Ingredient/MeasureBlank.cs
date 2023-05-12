using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models.Blank.Recipe.Ingredient;

public class MeasureBlank
{
    [JsonPropertyName("name")]
    [StringLength(150, ErrorMessage = "Максимум 150 символов")]
    public string Name { get; set; } = string.Empty;
}