using System.Text.Json.Serialization;
using Models.Domain.Client;
using Models.Domain.Recipe.Category;
using Models.Domain.Recipe.Type;

namespace Models.Domain.Recipe;

public class RecipeDomain
{
    [JsonPropertyName("clientOwner")]
    public ClientDomain? ClientOwner { get; set; }
    
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("header")]
    public string Header { get; set; } = string.Empty;

    [JsonPropertyName("views")]
    public int Views { get; set; }
    
    [JsonPropertyName("type")]
    public TypeDomain? Type { get; set; }

    [JsonPropertyName("info")]
    public RecipeInfoDomain? Info { get; set; }
    
    [JsonPropertyName("categories")]
    public List<CategoryDomain> Categories { get; set; } = new List<CategoryDomain>();

    [JsonPropertyName("ingredients")]
    public List<RecipeIngredientDomain> Ingredients { get; set; } = new List<RecipeIngredientDomain>();

    [JsonPropertyName("steps")]
    public List<RecipeStepDomain> Steps { get; set; } = new List<RecipeStepDomain>();
}