using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookbookApi.Models.Blank.Recipe.Category;
using CookbookApi.Models.Domain.Recipe.Category;
using CookbookApi.Services.Interfaces.RecipeInterfaces;
using CookbookApi.Services.Recipe;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApi.Controllers.Recipe
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase, ICategoryService
    {
        private readonly CategoryService _categoryService;

        public CategoryController()
        {
            _categoryService = new CategoryService();
        }

        [HttpGet("Category")]
        public async Task<IActionResult> GetCategoryAsync(int id)
        {
            return await _categoryService.GetCategoryAsync(id);
        }

        [HttpGet("Categories")]
        public async Task<List<CategoryDomain>> GetCategories()
        {
            return await _categoryService.GetCategories();
        }

        [HttpPost("Category")]
        public async Task<IActionResult> CreateCategoryAsync(CategoryBlank category)
        {
            return await _categoryService.CreateCategoryAsync(category);
        }

        [HttpDelete("Category")]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            return await _categoryService.DeleteCategoryAsync(id);
        }
    }
}
