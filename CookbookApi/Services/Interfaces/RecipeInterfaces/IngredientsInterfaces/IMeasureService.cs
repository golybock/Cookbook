using CookbookApi.Models.Blank.Recipe.Ingredient;
using CookbookApi.Models.Domain.Recipe.Ingredient;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApi.Services.Interfaces.RecipeInterfaces.IngredientsInterfaces;

public interface IMeasureService
{
    public Task<IActionResult> GetMeasureAsync(int id);
    
    public Task<List<MeasureDomain>> GetMeasuresAsync();
    
    public Task<IActionResult> CreateMeasureAsync(MeasureBlank measure);
    
    // public Task<IActionResult> UpdateMeasureAsync(int id, MeasureBlank measure);
    
    public Task<IActionResult> DeleteMeasureAsync(int id);
}