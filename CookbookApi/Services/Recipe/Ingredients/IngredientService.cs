using CookbookApi.Models.Blank.Recipe.Ingredient;
using CookbookApi.Models.Database.Recipe.Ingredient;
using CookbookApi.Models.Domain.Recipe.Ingredient;
using CookbookApi.Repositories.Recipe.Ingredients;
using CookbookApi.Services.Interfaces.RecipeInterfaces.IngredientsInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApi.Services.Recipe.Ingredients;

public class IngredientService : IIngredientService
{
    private readonly IngredientRepository _ingredientRepository;

    public IngredientService()
    {
        _ingredientRepository = new IngredientRepository();
    }

    public async Task<List<IngredientDomain>> GetIngredientsAsync()
    {
        var ingredients = await _ingredientRepository.GetIngredientsAsync();

        return ingredients.Select(c => new IngredientDomain(c)).ToList();
    }

    public async Task<IActionResult> CreateIngredientAsync(IngredientBlank ingredient)
    {
        try
        {
            var res = await _ingredientRepository.AddIngredientAsync(new Ingredient(ingredient));
            return new OkObjectResult(res);
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult("Ошибка создания ингридента");
        }
    }

    public async Task<IActionResult> DeleteIngredientAsync(int id)
    {
        var res = await _ingredientRepository.DeleteIngredientAsync(id);

        return res > 0 ? new OkResult() : new NotFoundResult();
    }

    public async Task<IActionResult> GetIngredientAsync(int id)
    {
        var ingredient = await _ingredientRepository.GetIngredientAsync(id);

        if (ingredient == null)
            return new NotFoundResult();

        var ingredientDomain = new IngredientDomain(ingredient);
        
        return new OkObjectResult(ingredientDomain);
    }
    
}