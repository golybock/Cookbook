using CookbookApi.Models.Blank.Recipe;
using CookbookApi.Models.Domain.Recipe;
using CookbookApi.Services.Interfaces.RecipeInterfaces;
using CookbookApi.Services.Recipe;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApi.Controllers.Recipe
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase, IRecipeService
    {
        private readonly RecipeService _recipeService;

        public RecipeController()
        {
            _recipeService = new RecipeService();
        }

        [HttpGet("Recipe")]
        public async Task<IActionResult> GetRecipeAsync(string recipeCode)
        {
            return await _recipeService.GetRecipeAsync(recipeCode);
        }

        [HttpGet("Recipes")]
        public async Task<List<RecipeDomain>> GetRecipesAsync()
        {
            return await _recipeService.GetRecipesAsync();
        }

        [HttpGet("LikedRecipe")]
        public async Task<IActionResult> GetClientLikedRecipesAsync([FromHeader] string token)
        {
            return await _recipeService.GetClientLikedRecipesAsync(token);
        }

        [HttpGet("ClientRecipe")]
        public async Task<IActionResult> GetClientRecipesAsync([FromHeader] string token)
        {
            return await _recipeService.GetClientRecipesAsync(token);
        }

        [HttpPost("Recipe")]
        public async Task<IActionResult> CreateRecipeAsync([FromHeader] string token, RecipeBlank recipe)
        {
            return await _recipeService.CreateRecipeAsync(token, recipe);
        }

        [HttpPost("Recipe")]
        public async Task<IActionResult> UpdateRecipeAsync([FromHeader] string token, string recipeCode, RecipeBlank recipe)
        {
            return await _recipeService.UpdateRecipeAsync(token, recipeCode, recipe);
        }

        [HttpPost("RecipeImage")]
        public async Task<IActionResult> UploadRecipeImageAsync(string token, string code, IFormFile file)
        {
            return await _recipeService.UploadRecipeImageAsync(token, code, file);
        }

        [HttpDelete("Recipe")]
        public async Task<IActionResult> DeleteRecipeAsync([FromHeader] string token, string recipeCode)
        {
            return await _recipeService.DeleteRecipeAsync(token, recipeCode);
        }

        [HttpDelete("RecipeImage")]
        public async Task<IActionResult> DeleteRecipeImageAsync(string token, string recipeCode)
        {
            return await _recipeService.DeleteRecipeImageAsync(token, recipeCode);
        }
    }
}
