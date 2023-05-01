using System.Text.Json.Serialization;

namespace Cookbook.Models.Domain.Recipe.Ingredient;

public class IngredientDomain
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("measureId")]
    public int MeasureId { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    public MeasureDomain? Measure = new MeasureDomain();

    public IngredientDomain() { }

    public IngredientDomain(IngredientDomain ingredient)
    {
        Id = ingredient.Id;
        Name = ingredient.Name;
        MeasureId = ingredient.MeasureId;
    }
}