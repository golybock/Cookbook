using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookbookApi.Models.Blank.Recipe.Ingredient;
using CookbookApi.Models.Domain.Recipe.Ingredient;
using CookbookApi.Services.Interfaces.RecipeInterfaces.IngredientsInterfaces;
using CookbookApi.Services.Recipe.Ingredients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApi.Controllers.Recipe.Ingredient
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase, IIngredientService
    {
        private readonly IngredientService _ingredientService;

        public IngredientController()
        {
            _ingredientService = new IngredientService();
        }

        [HttpGet("Ingredient")]
        public async Task<IActionResult> GetIngredientAsync(int id)
        {
            return await _ingredientService.GetIngredientAsync(id);
        }

        [HttpGet("Ingredients")]
        public async Task<List<IngredientDomain>> GetIngredientsAsync()
        {
            return await _ingredientService.GetIngredientsAsync();
        }

        [HttpPost("Ingredient")]
        public async Task<IActionResult> CreateIngredientAsync(IngredientBlank ingredient)
        {
            return await _ingredientService.CreateIngredientAsync(ingredient);
        }

        [HttpDelete("Ingredient")]
        public async Task<IActionResult> DeleteIngredientAsync(int id)
        {
            return await _ingredientService.DeleteIngredientAsync(id);
        }
    }
}
