using System;
using System.Collections.Generic;
using Cookbook.Models.Domain.Recipe;
using Cookbook.Models.Domain.Recipe.Ingredient;
using Cookbook.ViewModel.Navigation;

namespace Cookbook.ViewModel.Recipe;

public class RecipeViewModel : ViewModelBase, INavItem
{
    public RecipeViewModel(INavHost host)
    {
        Host = host;
    }

    public RecipeViewModel(INavHost host, RecipeDomain recipe)
    {
        Host = host;
        Recipe = recipe;
    }
    
    public INavHost Host { get; set; }

    public RecipeDomain Recipe { get; set; } = new RecipeDomain()
    {
        SourceUrl = "Beba",
        RecipeType = new RecipeTypeDomain() { Name = "TestType"},
        Header = "Header",
        Description = "Description",
        Steps = new List<RecipeStepDomain>()
        {
            new RecipeStepDomain() { Text = "aa" },
            new RecipeStepDomain() { Text = "aa" },
            new RecipeStepDomain() { Text = "aa" },
            new RecipeStepDomain() { Text = "aa" },
            new RecipeStepDomain() { Text = "aa" },
            new RecipeStepDomain() { Text = "aa" },
            new RecipeStepDomain() { Text = "aa" },
            new RecipeStepDomain() { Text = "aa" },
            new RecipeStepDomain() { Text = "aa" }
        },
        Stats = new RecipeStatsDomain()
        {
            Carbohydrates = 10,
            CookingTime = DateTime.Now,
            Fats = 11,
            Kilocalories = 12,
            Portions = 2,
            Squirrels = 13
        },
        Ingredients = new List<RecipeIngredientDomain>()
        {
            new RecipeIngredientDomain()
            {
                Ingredient = new IngredientDomain(){ Name = "beb"},
                Count = 10
            },
            new RecipeIngredientDomain()
            {
                Ingredient = new IngredientDomain(){ Name = "beb"},
                Count = 10
            },
            new RecipeIngredientDomain()
            {
                Ingredient = new IngredientDomain(){ Name = "beb"},
                Count = 10
            },
            new RecipeIngredientDomain()
            {
                Ingredient = new IngredientDomain(){ Name = "beb"},
                Count = 10
            }
        }
    };
}