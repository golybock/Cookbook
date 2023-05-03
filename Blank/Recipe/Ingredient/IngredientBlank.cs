using System.Text.Json.Serialization;
using Domain.Recipe.Ingredient;

namespace Blank.Recipe.Ingredient;

public class IngredientBlank
{
    [JsonPropertyName("measureId")]
    public int MeasureId { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    public IngredientBlank() { }

    public IngredientBlank(int measureId, string name)
    {
        MeasureId = measureId;
        Name = name;
    }

    public IngredientBlank(IngredientDomain ingredient)
    {
        MeasureId = ingredient.MeasureId;
        Name = ingredient.Name;
    }
}