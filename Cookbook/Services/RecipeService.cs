using System.Collections.Generic;
using System.Threading.Tasks;
using Cookbook.Api.Recipe;
using Cookbook.Api.Recipe.Category;
using Cookbook.Api.Recipe.Ingredient;
using Cookbook.Models.Blank.Recipe;
using Cookbook.Models.Blank.Recipe.Category;
using Cookbook.Models.Blank.Recipe.Ingredient;
using Cookbook.Models.Domain.Recipe;
using Cookbook.Models.Domain.Recipe.Category;
using Cookbook.Models.Domain.Recipe.Ingredient;

namespace Cookbook.Services;

public class RecipeService
{
    public Category Category { get; set; } = new Category();

    public Measure Measure { get; set; } = new Measure();

    public Ingredient Ingredient { get; set; } = new Ingredient();

    public RecipeType RecipeType { get; set; } = new RecipeType();

    public Recipe Recipe { get; set; } = new Recipe();
}

public class Category
{
    private readonly CategoryApi _categoryApi = new CategoryApi();

    /// <summary>
    /// Получение категоии по id
    /// </summary>
    /// <param name="id">Id категории рецепта</param>
    /// <returns>Категоиря рецепта, если такова найдена</returns>
    public Task<CategoryDomain?> Get(int id) =>
        _categoryApi.GetCategoryAsync(id);

    /// <summary>
    /// Получение списка всех категорий
    /// </summary>
    /// <returns>Список категорий рецептов</returns>
    public Task<List<CategoryDomain>?> Get() =>
        _categoryApi.GetCategoriesAsync();

    /// <summary>
    /// Создает категорию рецепта на сервере
    /// </summary>
    /// <param name="categoryBlank">Бланк категории</param>
    /// <returns>Возвращает id созданной категории, если она была создана</returns>
    public Task<int?> Create(CategoryBlank categoryBlank) =>
        _categoryApi.PostCategoryAsync(categoryBlank);

    /// <summary>
    /// Удаляет категорию на сервере, может будет пока не реализованно
    /// </summary>
    /// <param name="id">Id удаляемой категории</param>
    /// <returns>Возвращает булево значение, было ли удалено на стороне сервера</returns>
    public Task<bool> Delete(int id) =>
        _categoryApi.DeleteCategoryAsync(id);
}

public class Measure
{
    private readonly MeasureApi _measureApi = new MeasureApi();

    /// <summary>
    /// Получение меры измерения по id
    /// </summary>
    /// <param name="id">Id меры измерениния</param>
    /// <returns>Мера измерения ингредиента, если такова найдена</returns>
    public Task<MeasureDomain?> Get(int id) =>
        _measureApi.GetMeasureAsync(id);

    /// <summary>
    /// Получение списка всех мер измерения
    /// </summary>
    /// <returns>Список мер измерений для ингредиентов</returns>
    public Task<List<MeasureDomain>?> Get() =>
        _measureApi.GetMeasuresAsync();

    /// <summary>
    /// Создает меру измерения ингредиента на сервере
    /// </summary>
    /// <param name="measureBlank"></param>
    /// <returns>Возвращает id созданной меры измерения, если она была создана</returns>
    public Task<int?> Create(MeasureBlank measureBlank) =>
        _measureApi.PostMeasureAsync(measureBlank);

    /// <summary>
    /// Удаляет меру измерения на сервере, может будет пока не реализованно
    /// </summary>
    /// <param name="id">Id удаляемой меры измерения</param>
    /// <returns>Возвращает булево значение, было ли удалено на стороне сервера</returns>
    public Task<bool> Delete(int id) =>
        _measureApi.DeleteMeasureAsync(id);
}

public class Ingredient
{
    private readonly IngredientApi _ingredientApi = new IngredientApi();

    /// <summary>
    /// Получение ингредиента по id
    /// </summary>
    /// <param name="id">Id ингредиента</param>
    /// <returns>Ингредиент, если такова найден</returns>
    public Task<IngredientDomain?> Get(int id) =>
        _ingredientApi.GetIngredientAsync(id);

    /// <summary>
    /// Получение списка всех ингредиентов
    /// </summary>
    /// <returns>Список ингредиентов</returns>
    public Task<List<IngredientDomain>?> Get() =>
        _ingredientApi.GetIngredientsAsync();

    /// <summary>
    /// Создает ингредиент на сервере
    /// </summary>
    /// <param name="ingredientBlank"></param>
    /// <returns>Возвращает id созданного игредиента, если он был создан</returns>
    public Task<int?> Create(IngredientBlank ingredientBlank) =>
        _ingredientApi.PostIngredientAsync(ingredientBlank);

    /// <summary>
    /// Удаляет ингредиент на сервере, может будет пока не реализованно
    /// </summary>
    /// <param name="id">Id удаляемого ингредиента</param>
    /// <returns>Возвращает булево значение, было ли удалено на стороне сервера</returns>
    public Task<bool> Delete(int id) =>
        _ingredientApi.DeleteIngredientAsync(id);
}

public class RecipeType
{
    private readonly RecipeTypeApi _recipeTypeApi = new RecipeTypeApi();

    /// <summary>
    /// Получение списка всех типов рецепта
    /// </summary>
    /// <returns>Список типов рецепта</returns>
    public Task<List<RecipeTypeDomain>?> Get() =>
        _recipeTypeApi.GetRecipeTypesAsync();
}

public class Recipe
{
    private readonly RecipeApi _recipeApi = new RecipeApi();

    /// <summary>
    /// Получение рецепта
    /// </summary>
    /// <returns>Рецепт, если такой найден</returns>
    public Task<RecipeDomain?> Get(string code) =>
        _recipeApi.GetRecipeAsync(code);

    /// <summary>
    /// Создание рецепта
    /// </summary>
    /// <param name="recipeBlank">Бланк рецепта с данными</param>
    /// <returns>Код созданного рецепта</returns>
    public Task<string?> Create(RecipeBlank recipeBlank) =>
        _recipeApi.PostRecipeAsync(recipeBlank);

    /// <summary>
    /// Обновление рецепта
    /// </summary>
    /// <param name="recipeBlank">Бланк рецепта с данными</param>
    /// <param name="code">Идентификатор обновляемого рецепта</param>
    /// <returns>Идентификатор обновляемого рецепта, при успешном обновлении</returns>
    public Task<string?> Update(RecipeBlank recipeBlank, string code) =>
        _recipeApi.UpdateRecipeAsync(recipeBlank, code);

    /// <summary>
    /// Удаление рецепта
    /// </summary>
    /// <param name="code">Идентификатор удаляемого рецепта</param>
    /// <returns>Булевое значение, удален ли рецепт на сервере</returns>
    public Task<bool?> Delete(string code) =>
        _recipeApi.DeleteRecipeAsync(code);

    /// <summary>
    /// Получение всех рецептов с сервера
    /// </summary>
    /// <returns>Список рецептов на сервере</returns>
    public Task<List<RecipeDomain>?> Get() =>
        _recipeApi.GetRecipesAsync();

    /// <summary>
    /// Получение всех сохраненных рецептов с сервера
    /// </summary>
    /// <returns>Список сохранных пользователем рецептов на сервере</returns>
    public Task<List<RecipeDomain>?> GetLiked() =>
        _recipeApi.GetLikedRecipesAsync();

    /// <summary>
    /// Получение всех рецептов пользователя с сервера
    /// </summary>
    /// <returns>Список рецептов пользователя на сервере</returns>
    public Task<List<RecipeDomain>?> GetClient() =>
        _recipeApi.GetClientRecipesAsync();

    /// <summary>
    /// Загрузка фотографии рецепта
    /// </summary>
    /// <param name="path">Путь до файла с изображением</param>
    /// <param name="code">Идентификатор рецепта</param>
    /// <returns>Url на загруженное изображение</returns>
    public Task<string?> UploadRecipeImage(string path, string code) =>
        _recipeApi.UploadRecipeImageAsync(path, code);

    /// <summary>
    /// Удаляет фотографию рецепта на сервере
    /// </summary>
    /// <param name="code">Идентификатор рецепта</param>
    /// <returns>Булево значение, удалена ли фотография</returns>
    public Task<bool> DeleteRecipeImage(string code) =>
        _recipeApi.DeleteRecipeImageAsync(code);
}