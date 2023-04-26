using CookbookApi.Models.Blank.Recipe.Ingredient;
using CookbookApi.Models.Domain.Recipe.Ingredient;
using CookbookApi.Services.Interfaces.RecipeInterfaces.IngredientsInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApi.Services.Recipe.Ingredients;

public class MeasureService : IMeasureService
{
    public async Task<IActionResult> GetMeasureAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<MeasureDomain>> GetMeasuresAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> CreateMeasureAsync(MeasureBlank measure)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> DeleteMeasureAsync(int id)
    {
        throw new NotImplementedException();
    }
}