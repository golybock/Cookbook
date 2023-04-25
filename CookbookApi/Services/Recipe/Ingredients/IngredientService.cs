using CookbookApi.Services.Interfaces.RecipeInterfaces.IngredientsInterfaces;

namespace CookbookApi.Services.Recipe.Ingredients;

public class IngredientService : IIngredientService
{
    private readonly IngredientRepository _ingredientRepository;
    private readonly MeasureService _measureService;

    public IngredientService()
    {
        _measureService = new MeasureService();
        _ingredientRepository = new IngredientRepository();
    }

    public async Task<Ingredient> GetIngredientAsync(int id)
    {
        if (id <= 0)
            return new Ingredient();

        var ingredient = await _ingredientRepository.GetIngredientAsync(id);

        ingredient!.Measure =
            await _measureService.GetMeasureAsync(ingredient.MeasureId);

        return ingredient;
    }

    public async Task<List<Ingredient>> GetIngredientsAsync()
    {
        var ingredients =
            await _ingredientRepository.GetIngredientsAsync();

        foreach (var ingredient in ingredients)
            ingredient!.Measure =
                await _measureService.GetMeasureAsync(ingredient.MeasureId);

        return ingredients;
    }

    public async Task<CommandResult> AddIngredientAsync(Ingredient ingredient)
    {
        if (ingredient.Measure!.Id <= 0)
            return CommandResults.BadRequest;

        if (string.IsNullOrWhiteSpace(ingredient.Name))
            return CommandResults.BadRequest;

        return await _ingredientRepository.AddIngredientAsync(ingredient);
    }

    public async Task<CommandResult> UpdateIngredientAsync(Ingredient ingredient)
    {
        if (ingredient.Id <= 0)
            return CommandResults.BadRequest;

        if (ingredient.MeasureId <= 0)
            return CommandResults.BadRequest;

        if (string.IsNullOrWhiteSpace(ingredient.Name))
            return CommandResults.BadRequest;

        return await _ingredientRepository.UpdateIngredientAsync(ingredient);
    }

    public async Task<CommandResult> DeleteIngredientAsync(int id)
    {
        if (id <= 0)
            return CommandResults.BadRequest;

        return await _ingredientRepository.DeleteIngredientAsync(id);
    }
}