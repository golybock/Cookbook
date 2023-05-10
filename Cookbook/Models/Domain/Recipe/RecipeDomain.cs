using System.Collections.Generic;
using System.Text.Json.Serialization;
using Cookbook.Models.Blank.Recipe;
using Cookbook.Models.Domain.Recipe.Category;

namespace Cookbook.Models.Domain.Recipe;

public class RecipeDomain
{
    private string? _imagePath;

    [JsonPropertyName("clientOwner")]
    public string? ClientOwner { get; set; }
    [JsonPropertyName("typeId")]
    public int TypeId { get; set; }
    [JsonPropertyName("header")]
    public string Header { get; set; } = string.Empty;
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    [JsonPropertyName("code")]
    public string? Code { get; set; }
    [JsonPropertyName("sourceUrl")]
    public string? SourceUrl { get; set; }

    [JsonPropertyName("imagePath")]
    public string? ImagePath
    {
        get => "https://localhost:7234/RecipeImages/" + _imagePath;
        set => _imagePath = value;
    }

    [JsonPropertyName("isLiked")]
    public bool IsLiked { get; set; }
    [JsonPropertyName("recipeType")]
    public RecipeTypeDomain? RecipeType { get; set; } = new RecipeTypeDomain();
    [JsonPropertyName("stats")]
    public RecipeStatsDomain? Stats { get; set; } = new RecipeStatsDomain();
    [JsonPropertyName("ingredients")]
    public List<RecipeIngredientDomain> Ingredients { get; set; } = new List<RecipeIngredientDomain>();
    [JsonPropertyName("categories")]
    public List<CategoryDomain> Categories { get; set; } = new List<CategoryDomain>();
    [JsonPropertyName("steps")]
    public List<RecipeStepDomain> Steps { get; set; } = new List<RecipeStepDomain>();

    public RecipeDomain() { }
    
    public RecipeDomain(RecipeBlank recipe)
    {
        TypeId = recipe.TypeId;
        Header = recipe.Header;
        SourceUrl = recipe.SourceUrl;
        Description = recipe.Description;
    }
}