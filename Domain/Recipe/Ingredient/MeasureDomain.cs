using System.Text.Json.Serialization;

namespace Domain.Recipe.Ingredient;

public class MeasureDomain
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    public MeasureDomain() { }

    public MeasureDomain(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public MeasureDomain(MeasureBlank measure)
    {
        Name = measure.Name;
    }
}