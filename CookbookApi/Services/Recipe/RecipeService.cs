using CookbookApi.Models.Blank.Recipe;
using CookbookApi.Models.Blank.Recipe.Category;
using CookbookApi.Models.Database.Recipe;
using CookbookApi.Models.Database.Recipe.Category;
using CookbookApi.Models.Domain.Recipe;
using CookbookApi.Models.Domain.Recipe.Category;
using CookbookApi.Models.Domain.Recipe.Ingredient;
using CookbookApi.Repositories.Client;
using CookbookApi.Repositories.Recipe;
using CookbookApi.Repositories.Recipe.Ingredients;
using CookbookApi.Services.Interfaces.RecipeInterfaces;
using Microsoft.AspNetCore.Mvc;
using RecipeModel = CookbookApi.Models.Database.Recipe.Recipe;

namespace CookbookApi.Services.Recipe;

public class RecipeService : IRecipeService
{
    private readonly RecipeRepository _recipeRepository;
    private readonly RecipeStatsRepository _recipeStatsRepository;
    private readonly RecipeIngredientRepository _recipeIngredientRepository;
    private readonly RecipeCategoryRepository _recipeCategoryRepository;
    private readonly TypeRepository _typeRepository;
    private readonly ClientFavRepository _clientFavRepository;
    private readonly ClientRepository _clientRepository;
    private readonly CategoryRepository _categoryRepository;
    private readonly IngredientRepository _ingredientRepository;
    private readonly MeasureRepository _measureRepository;
    private readonly RecipeStepRepository _recipeStepRepository;

    public RecipeService()
    {
        _recipeRepository = new RecipeRepository();
        _recipeStatsRepository = new RecipeStatsRepository();
        _recipeIngredientRepository = new RecipeIngredientRepository();
        _recipeCategoryRepository = new RecipeCategoryRepository();
        _typeRepository = new TypeRepository();
        _clientFavRepository = new ClientFavRepository();
        _clientRepository = new ClientRepository();
        _categoryRepository = new CategoryRepository();
        _ingredientRepository = new IngredientRepository();
        _measureRepository = new MeasureRepository();
        _recipeStepRepository = new RecipeStepRepository();
    }

    public async Task<IActionResult> GetRecipeAsync(string recipeCode)
    {
        var recipe = await _recipeRepository.GetRecipeAsync(recipeCode);

        if (recipe == null)
            return new NotFoundResult();

        var recipeDomain = await GetRecipeDomain(recipe);

        return new OkObjectResult(recipeDomain);
    }

    public async Task<List<RecipeDomain>> GetRecipesAsync()
    {
        var recipes = await _recipeRepository.GetRecipesAsync();
        
        var recipesDomain = recipes
            .Select(async c => await GetRecipeDomain(c))
            .Where(r => r != null)
            .Select(c => c.Result)
            .ToList();

        return recipesDomain;
    }

    public async Task<IActionResult> GetClientLikedRecipesAsync(string token)
    {
        var client = await _clientRepository.GetClientAsync(token);

        if (client == null)
            return new UnauthorizedResult();

        var favRecipes = await _clientFavRepository.GetFavoriteRecipesAsync(client.Id);

        List<RecipeDomain> likedRecipes = new List<RecipeDomain>();
        
        foreach (var favRecipe in favRecipes)
        {
            var recipe = await _recipeRepository.GetRecipeAsync(favRecipe.RecipeId);

            if (recipe != null)
                likedRecipes.Add(await GetRecipeDomain(recipe));
        }

        return new OkObjectResult(likedRecipes);
    }

    public async Task<IActionResult> GetClientRecipesAsync(string token)
    {
        var client = await _clientRepository.GetClientAsync(token);

        if (client == null)
            return new UnauthorizedResult();

        var clientRecipes = await _recipeRepository.GetClientRecipesAsync(client.Id);
        
        var recipesDomain = clientRecipes
            .Select(async c => await GetRecipeDomain(c))
            .Where(r => r != null)
            .Select(c => c.Result)
            .ToList();

        return new OkObjectResult(recipesDomain);
    }

    public async Task<IActionResult> CreateRecipeAsync(string token, RecipeBlank recipe)
    {
        var client = await _clientRepository.GetClientAsync(token);

        if (client == null)
            return new UnauthorizedResult();

        var code = await CreateRecipeAsync(client.Id, recipe);

        if (code == null)
            return new BadRequestResult();

        await SetRecipeIngredients(recipe.Ingredients, code);

        await SetRecipeCategories(recipe.Categories, code);

        await SetRecipeSteps(recipe.Steps, code);

        // если присутствуют
        if (recipe.RecipeStats != null) 
            await CreateRecipeStatsAsync(recipe.RecipeStats, code);

        return new OkObjectResult(code);
    }

    public async Task<IActionResult> UpdateRecipeAsync(string token, string recipeCode, RecipeBlank recipeBlank)
    {
        var client = await _clientRepository.GetClientAsync(token);

        if (client == null)
            return new UnauthorizedResult();

        var recipe = await _recipeRepository.GetRecipeAsync(recipeCode);

        if (recipe == null)
            return new NotFoundResult();

        if (recipe.ClientId != client.Id)
            return new BadRequestObjectResult("Отказано в доступе");

        var res = await UpdateRecipeAsync(recipeCode, recipeBlank);

        if (res == null)
            return new BadRequestObjectResult("Не удалось обновить");
        
        await SetRecipeIngredients(recipeBlank.Ingredients, recipeCode);

        await SetRecipeCategories(recipeBlank.Categories, recipeCode);

        await SetRecipeSteps(recipeBlank.Steps, recipeCode);
        
        // если присутствуют
        if (recipeBlank.RecipeStats != null) 
            await CreateRecipeStatsAsync(recipeBlank.RecipeStats, recipeCode);

        return new OkObjectResult(recipeCode);
    }

    public async Task<IActionResult> UploadRecipeImageAsync(string token, string code, IFormFile file)
    {
        var client = await _clientRepository.GetClientAsync(token);

        if (client == null)
            return new UnauthorizedResult();

        var recipe = await _recipeRepository.GetRecipeAsync(code);

        if (recipe == null)
            return new NotFoundResult();
        
        var path = await SaveImageAsync(file);

        var res = await _recipeRepository.UpdateRecipeImageAsync(recipe.Id, path);

        return res > 0 ? new OkObjectResult(path) : new BadRequestResult();
    }

    public async Task<IActionResult> DeleteRecipeAsync(string token, string recipeCode)
    {
        var client = await _clientRepository.GetClientAsync(token);

        if (client == null)
            return new UnauthorizedResult();

        var recipe = await _recipeRepository.GetRecipeAsync(recipeCode);

        if (recipe == null)
            return new NotFoundResult();

        var res = await DeleteRecipeAsync(recipe.Id);

        return res > 0 ? new OkResult() : new BadRequestResult();
    }

    public async Task<IActionResult> DeleteRecipeImageAsync(string token, string recipeCode)
    {
        var client = await _clientRepository.GetClientAsync(token);

        if (client == null)
            return new UnauthorizedResult();
        
        var recipe = await _recipeRepository.GetRecipeAsync(recipeCode);

        if (recipe == null)
            return new NotFoundResult();

        if (recipe.ClientId != client.Id)
            return new BadRequestObjectResult("Отказано в доступе");

        var res = await _recipeRepository.DeleteRecipeImageAsync(recipe.Id);

        return res > 0 ? new OkResult() : new BadRequestResult();
    }

    private async Task<int> DeleteRecipeAsync(int id)
    {
        // удаляем из связанных таблиц
        var deleteFromFavorites = _clientFavRepository.DeleteRecipeFromFavoritesAsync(id);
        var deleteFromIngredients = _recipeIngredientRepository.DeleteRecipeIngredientsAsync(id);
        var deleteFromCategories = _recipeCategoryRepository.DeleteRecipeCategoriesAsync(id);
        var deleteFromStats = _recipeStatsRepository.DeleteRecipeStatsAsync(id);
        var deleteFromSteps = _recipeStepRepository.DeleteRecipeSteps(id);

        // ждем завершения удаления
        await deleteFromFavorites;
        await deleteFromIngredients;
        await deleteFromCategories;
        await deleteFromStats;
        await deleteFromSteps;

        // удаляем рецепт
        return await _recipeRepository.DeleteRecipeAsync(id);
    }

    private async Task<RecipeDomain> GetRecipeDomain(RecipeModel recipe)
    {
        var recipeDomain = new RecipeDomain(recipe);

        var recipeStatsTask = _recipeStatsRepository.GetRecipeStatsAsync(recipe.Id);
        var recipeTypeTask = _typeRepository.GetRecipeTypeAsync(recipe.TypeId);
        var recipeCategoriesTask = _recipeCategoryRepository.GetRecipeCategoriesAsync(recipe.Id);
        var recipeIngredientsTask = _recipeIngredientRepository.GetRecipeIngredientsAsync(recipe.Id);
        var ownerTask = _clientRepository.GetClientAsync(recipe.ClientId);

        var recipeStats = await recipeStatsTask;
        var recipeType = await recipeTypeTask;
        var recipeCategories = await recipeCategoriesTask;
        var owner = await ownerTask;
        var recipeIngredients = await recipeIngredientsTask;

        if (recipeStats != null)
            recipeDomain.Stats = new RecipeStatsDomain(recipeStats);

        if (recipeType != null)
            recipeDomain.RecipeType = new RecipeTypeDomain(recipeType);

        if (owner != null) 
            recipeDomain.ClientOwner = owner.Login;

        recipeDomain.Categories = await GetCategoriesDomain(recipeCategories);
        recipeDomain.Ingredients = await GetIngredientsDomain(recipeIngredients);
        recipeDomain.Steps = await GetStepsDomain(recipe.Id);
        
        
        return recipeDomain;
    }

    private async Task<List<CategoryDomain>> GetCategoriesDomain(List<RecipeCategory> recipeCategories)
    {
        List<CategoryDomain> categoryDomains = new List<CategoryDomain>();

        foreach (var recipeCategory in recipeCategories)
        {
            var category = await _categoryRepository.GetCategoryAsync(recipeCategory.CategoryId);

            if (category != null)
                categoryDomains.Add(new CategoryDomain(category));
        }

        return categoryDomains;
    }
    
    private async Task<List<RecipeStepDomain>> GetStepsDomain(int recipeId)
    {
        List<RecipeStep> recipeStepsDb = await _recipeStepRepository.GetRecipeSteps(recipeId);

        var recipeSteps = recipeStepsDb
            .Select(c => new RecipeStepDomain(c))
            .ToList();
        
        return recipeSteps;
    }

    private async Task<List<RecipeIngredientDomain>> GetIngredientsDomain(List<RecipeIngredient> recipeIngredients)
    {
        List<RecipeIngredientDomain> ingredientDomains = new List<RecipeIngredientDomain>();

        foreach (var recipeIngredient in recipeIngredients)
        {
            RecipeIngredientDomain recipeIngredientDomain = new RecipeIngredientDomain(recipeIngredient);
            
            var ingredient = await _ingredientRepository.GetIngredientAsync(recipeIngredient.IngredientId);

            if (ingredient != null)
            {
                var measure = await _measureRepository.GetMeasureAsync(ingredient.MeasureId);

                var ingredientDomain = new IngredientDomain(ingredient);

                if (measure != null)
                    ingredientDomain.Measure = new MeasureDomain(measure);
                
                recipeIngredientDomain.Ingredient = ingredientDomain;
            }

            ingredientDomains.Add(recipeIngredientDomain);
        }
        
        return ingredientDomains;
    }

    private async Task SetRecipeIngredients(List<RecipeIngredientBlank> ingredients, int recipeId)
    {
        // очищаем список ингредиентов в бд
        await _recipeIngredientRepository.DeleteRecipeIngredientsAsync(recipeId);

        foreach (var recipeIngredient in ingredients)
        {
            // создаем ингредиент
            RecipeIngredient ingredient = new RecipeIngredient(recipeIngredient);
            // устангавливеам recipe_id
            ingredient.RecipeId = recipeId;
            // сохраняем в бд
            await _recipeIngredientRepository.AddRecipeIngredientAsync(ingredient);
        }
    }
    
    private async Task SetRecipeIngredients(List<RecipeIngredientBlank> ingredients, string recipeCode)
    {
        var recipe = await _recipeRepository.GetRecipeAsync(recipeCode);
        
        if(recipe == null)
            return;

        // очищаем список ингредиентов в бд
        await _recipeIngredientRepository.DeleteRecipeIngredientsAsync(recipe.Id);

        foreach (var recipeIngredient in ingredients)
        {
            // создаем ингредиент
            RecipeIngredient ingredient = new RecipeIngredient(recipeIngredient);
            // устангавливеам recipe_id
            ingredient.RecipeId = recipe.Id;
            // сохраняем в бд
            await _recipeIngredientRepository.AddRecipeIngredientAsync(ingredient);
        }
    }
    
    private async Task SetRecipeCategories(List<RecipeCategoryBlank> categories, int recipeId)
    {
        // очищаем список категорий в бд
        await _recipeCategoryRepository.DeleteRecipeCategoriesAsync(recipeId);

        foreach (var recipeCategory in categories)
        {
            // создаем категорию
            RecipeCategory category = new RecipeCategory(recipeCategory);
            // устангавливеам recipe_id
            category.RecipeId = recipeId;
            // сохраняем в бд
            await _recipeCategoryRepository.AddRecipeCategoryAsync(category);
        }
    }

    private async Task SetRecipeCategories(List<RecipeCategoryBlank> categories, string recipeCode)
    {
        var recipe = await _recipeRepository.GetRecipeAsync(recipeCode);
        
        if(recipe == null)
            return;
        
        // очищаем список категорий в бд
        await _recipeCategoryRepository.DeleteRecipeCategoriesAsync(recipe.Id);

        foreach (var recipeCategory in categories)
        {
            // создаем категорию
            RecipeCategory category = new RecipeCategory(recipeCategory);
            // устангавливеам recipe_id
            category.RecipeId = recipe.Id;
            // сохраняем в бд
            await _recipeCategoryRepository.AddRecipeCategoryAsync(category);
        }
    }
    
    private async Task SetRecipeSteps(List<RecipeStepBlank> recipeSteps, int recipeId)
    {
        var recipe = await _recipeRepository.GetRecipeAsync(recipeId);
        
        if(recipe == null)
            return;
        
        // очищаем список шагов в бд
        await _recipeStepRepository.DeleteRecipeSteps(recipe.Id);

        foreach (var recipeStepBlank in recipeSteps)
        {
            // создаем шаг
            RecipeStep recipeStep = new RecipeStep(recipeStepBlank);
            // устангавливеам recipe_id
            recipeStep.RecipeId = recipe.Id;
            // сохраняем в бд
            await _recipeStepRepository.AddRecipeStep(recipeStep);
        }
    }
    
    private async Task SetRecipeSteps(List<RecipeStepBlank> recipeSteps, string recipeCode)
    {
        var recipe = await _recipeRepository.GetRecipeAsync(recipeCode);
        
        if(recipe == null)
            return;
        
        // очищаем список шагов в бд
        await _recipeStepRepository.DeleteRecipeSteps(recipe.Id);

        foreach (var recipeStepBlank in recipeSteps)
        {
            // создаем шаг
            RecipeStep recipeStep = new RecipeStep(recipeStepBlank);
            // устангавливеам recipe_id
            recipeStep.RecipeId = recipe.Id;
            // сохраняем в бд
            await _recipeStepRepository.AddRecipeStep(recipeStep);
        }
    }
    
    private async Task<string?> CreateRecipeAsync(int clientId, RecipeBlank recipeBlank)
    {
        string code = Guid.NewGuid().ToString();

        RecipeModel recipe = new RecipeModel(recipeBlank);

        recipe.Code = code;
        recipe.ClientId = clientId;

        var res = await _recipeRepository.AddRecipeAsync(recipe);

        return res > 0 ? code : null;
    }
    
    private async Task CreateRecipeStatsAsync(RecipeStatsBlank recipeStatsBlank, int recipeId)
    {
        await _recipeStatsRepository.DeleteRecipeStatsAsync(recipeId);
        
        RecipeStats recipeStats = new RecipeStats(recipeStatsBlank);

        recipeStats.Id = recipeId;

        await _recipeStatsRepository.AddRecipeStatsAsync(recipeStats);
    }
    
    private async Task CreateRecipeStatsAsync(RecipeStatsBlank recipeStatsBlank, string recipeCode)
    {
        var recipe = await _recipeRepository.GetRecipeAsync(recipeCode);
        
        if(recipe == null)
            return;
        
        await _recipeStatsRepository.DeleteRecipeStatsAsync(recipe.Id);
        
        RecipeStats recipeStats = new RecipeStats(recipeStatsBlank);

        recipeStats.Id = recipe.Id;

        await _recipeStatsRepository.AddRecipeStatsAsync(recipeStats);
    }
    
    private async Task<string?> UpdateRecipeAsync(int recipeId, RecipeBlank recipeBlank)
    {
        var recipe = await _recipeRepository.GetRecipeAsync(recipeId);

        if (recipe == null)
            return null;
        
        var res = await _recipeRepository.UpdateRecipeAsync(recipe);

        return res > 0 ? recipe.Code : null;
    }
    
    private async Task<string?> UpdateRecipeAsync(string recipeCode, RecipeBlank recipeBlank)
    {
        var recipe = await _recipeRepository.GetRecipeAsync(recipeCode);

        if (recipe == null)
            return null;
        
        var res = await _recipeRepository.UpdateRecipeAsync(recipe);

        return res > 0 ? recipe.Code : null;
    }
    
    private async Task<string> SaveImageAsync(IFormFile file)
    {
        string directory = "wwwroot/RecipeImages/";
        
        string path = $"{Guid.NewGuid()}.png";

        using StreamWriter sw = new StreamWriter(directory + path);
        
        await file.CopyToAsync(sw.BaseStream);

        return path;
    }
}