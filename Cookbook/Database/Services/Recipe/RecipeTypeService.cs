﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Cookbook.Database.Repositories.Recipe;
using Cookbook.Database.Services.Interfaces.RecipeInterfaces;
using Cookbook.Models.Database;
using Cookbook.Models.Database.Recipe;

namespace Cookbook.Database.Services.Recipe;

public class RecipeTypeService : IRecipeTypeService
{
    private readonly RecipeTypeRepository _recipeTypeRepository;

    public RecipeTypeService()
    {
        _recipeTypeRepository = new RecipeTypeRepository();
    }

    public async Task<RecipeType> GetRecipeTypeAsync(int id)
    {
        if (id <= 0)
            return new();

        return await _recipeTypeRepository.GetRecipeTypeAsync(id);
    }

    public Task<List<RecipeType>> GetRecipeTypesAsync()
    {
        return _recipeTypeRepository.GetRecipeTypesAsync();
    }

    public Task<CommandResult> AddRecipeTypeAsync(RecipeType recipeType)
    {
        return _recipeTypeRepository.AddRecipeTypeAsync(recipeType);
    }
}