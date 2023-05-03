﻿using System.Text.Json.Serialization;
using Domain.Recipe.Ingredient;

namespace Domain.Recipe;

public class RecipeIngredientDomain
{
    [JsonPropertyName("recipeId")]
    public int RecipeId { get; set; }
    [JsonPropertyName("ingredientId")]
    public int IngredientId { get; set; }
    [JsonPropertyName("ingredient")]
    public IngredientDomain? Ingredient { get; set; } = new IngredientDomain();
    [JsonPropertyName("count")]
    public decimal Count { get; set; }

    public RecipeIngredientDomain() { }

    public RecipeIngredientDomain(RecipeIngredientBlank recipeIngredient)
    {
        IngredientId = recipeIngredient.IngredientId;
        Count = recipeIngredient.Count;
    }
}