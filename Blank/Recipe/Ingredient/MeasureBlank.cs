using System.Text.Json.Serialization;
using Domain.Recipe.Ingredient;

namespace Blank.Recipe.Ingredient;

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