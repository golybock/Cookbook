using CookbookApi.Models.Blank.Recipe.Ingredient;
using CookbookApi.Models.Domain.Recipe.Ingredient;
using CookbookApi.Services.Interfaces.RecipeInterfaces.IngredientsInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApi.Services.Recipe.Ingredients;

public class IngredientService : IIngredientService
{
    async Task<List<IngredientDomain>> IIngredientService.GetIngredientsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> CreateIngredientAsync(IngredientBlank ingredient)
    {
        throw new NotImplementedException();
    }

    async Task<IActionResult> IIngredientService.DeleteIngredientAsync(int id)
    {
        throw new NotImplementedException();
    }

    async Task<IActionResult> IIngredientService.GetIngredientAsync(int id)
    {
        throw new NotImplementedException();
    }
    
}