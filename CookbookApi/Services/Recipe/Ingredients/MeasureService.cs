using CookbookApi.Models.Blank.Recipe.Ingredient;
using CookbookApi.Models.Database.Recipe.Ingredient;
using CookbookApi.Models.Domain.Recipe.Ingredient;
using CookbookApi.Repositories.Recipe.Ingredients;
using CookbookApi.Services.Interfaces.RecipeInterfaces.IngredientsInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApi.Services.Recipe.Ingredients;

public class MeasureService : IMeasureService
{
    private readonly MeasureRepository _measureRepository;

    public MeasureService()
    {
        _measureRepository = new MeasureRepository();
    }

    public async Task<IActionResult> GetMeasureAsync(int id)
    {
        var measure = await _measureRepository.GetMeasureAsync(id);

        if (measure == null)
            return new NotFoundResult();

        var measureDomain = new MeasureDomain(measure);
        
        return new OkObjectResult(measureDomain);
    }

    public async Task<List<MeasureDomain>> GetMeasuresAsync()
    {
        var measures = await _measureRepository.GetMeasuresAsync();

        var measuresDomain = measures
            .Select(c => new MeasureDomain(c))
            .ToList();

        return measuresDomain;
    }

    public async Task<IActionResult> CreateMeasureAsync(MeasureBlank measure)
    {
        var res = await _measureRepository.AddMeasureAsync(new Measure(measure));

        return res > 0 ? new OkObjectResult(res) : new BadRequestResult();
    }

    public async Task<IActionResult> DeleteMeasureAsync(int id)
    {
        var res = await _measureRepository.DeleteMeasureAsync(id);

        return res > 0 ? new OkResult() : new BadRequestResult();
    }
}