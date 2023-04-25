using CookbookApi.Models.Blank.Recipe.Ingredient;
using CookbookApi.Models.Database.Recipe.Ingredient;
using CookbookApi.Models.Domain.Recipe.Ingredient;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApi.Services.Interfaces.RecipeInterfaces.IngredientsInterfaces;

public interface IIngredientService
{
    public Task<IActionResult> GetIngredientAsync(int id);
    
    public Task<List<IngredientDomain>> GetIngredientsAsync();
    
    public Task<IActionResult> CreateIngredientAsync(IngredientBlank ingredient);
    
    public Task<IActionResult> UpdateIngredientAsync(int id, IngredientBlank ingredient);
    
    public Task<IActionResult> DeleteIngredientAsync(int id);
}