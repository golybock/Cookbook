using System.Text.Json.Serialization;
using Cookbook.Models.Domain.Recipe.Ingredient;

namespace Cookbook.Models.Blank.Recipe.Ingredient;

public class MeasureBlank
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    public MeasureBlank() { }

    public MeasureBlank(string name)
    {
        Name = name;
    }

    public MeasureBlank(MeasureDomain measure)
    {
        Name = measure.Name;
    }
}