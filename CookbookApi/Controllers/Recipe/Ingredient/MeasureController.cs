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
    public class MeasureController : ControllerBase, IMeasureService
    {
        private readonly MeasureService _measureService;

        public MeasureController()
        {
            _measureService = new MeasureService();
        }

        [HttpGet("Measure")]
        public async Task<IActionResult> GetMeasureAsync(int id)
        {
            return await _measureService.GetMeasureAsync(id);
        }

        [HttpGet("Measures")]
        public async Task<List<MeasureDomain>> GetMeasuresAsync()
        {
            return await _measureService.GetMeasuresAsync();
        }

        [HttpPost("Measure")]
        public async Task<IActionResult> CreateMeasureAsync(MeasureBlank measure)
        {
            return await _measureService.CreateMeasureAsync(measure);
        }

        [HttpDelete("Measure")]
        public async Task<IActionResult> DeleteMeasureAsync(int id)
        {
            return await _measureService.DeleteMeasureAsync(id);
        }
    }
}
