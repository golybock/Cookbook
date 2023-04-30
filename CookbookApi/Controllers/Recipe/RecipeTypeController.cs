using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookbookApi.Models.Database.Recipe;
using CookbookApi.Models.Domain.Recipe;
using CookbookApi.Services.Interfaces.RecipeInterfaces;
using CookbookApi.Services.Recipe;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApi.Controllers.Recipe
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeTypeController : ControllerBase, IRecipeTypeService
    {
        private readonly RecipeTypeService _recipeTypeService;

        public RecipeTypeController()
        {
            _recipeTypeService = new RecipeTypeService();
        }

        [HttpGet("RecipeTypes")]
        public async Task<List<RecipeTypeDomain>> GetRecipeTypesAsync()
        {
            return await _recipeTypeService.GetRecipeTypesAsync();
        }
    }
}
