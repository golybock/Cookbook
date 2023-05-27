using System;
using System.Diagnostics.CodeAnalysis;
using Cookbook.Command;
using Cookbook.Pages.Recipe;
using Cookbook.Services;
using Cookbook.ViewModel.Navigation;
using Microsoft.EntityFrameworkCore;
using ModernWpf.Controls;

namespace Cookbook.ViewModel.Recipe;

public class RecipeViewModel : ViewModelBase, INavItem
{
    private RecipeService _recipeService = new RecipeService();
    
    private bool _canEdit = false;
    private Database.Recipe? _recipe;

    private int _recipeId;
    
    public INavHost Host { get; set; }

    public Database.Recipe? Recipe
    {
        get => _recipe;
        set
        {
            if (Equals(value, _recipe)) return;
            _recipe = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(RecipeIngredientsVisible));
            OnPropertyChanged(nameof(RecipeCategoriesVisible));
            OnPropertyChanged(nameof(RecipeStepsVisible));
        }
    }

    public RecipeViewModel(INavHost host, Database.Recipe recipe)
    {
        Host = host;
        _recipeId = recipe.Id;
    
        LoadAccess();
        LoadRecipe();
    }
    
    [SuppressMessage("ReSharper.DPA", "DPA0007: Large number of DB records", MessageId = "count: 135")]
    private async void LoadRecipe()
    {
        Recipe = await _recipeService.Get(_recipeId);
    }
    
    public bool RecipeIngredientsVisible =>
        Recipe.RecipeIngredients.Count > 0;
    
    public bool RecipeCategoriesVisible =>
        Recipe.RecipeCategories.Count > 0;
    
    public bool RecipeStepsVisible =>
        Recipe.RecipeSteps.Count > 0;
    
    public bool RecipeStepsNotVisible =>
        !RecipeStepsVisible;
    
    public bool RecipeCategoriesNotVisible =>
        !RecipeCategoriesVisible;
    
    public bool RecipeIngredientsNotVisible =>
        !RecipeIngredientsVisible;
    
    public CommandHandler EditCommand =>
        new CommandHandler(Edit);
    
    public CommandHandler SaveCommand =>
        new CommandHandler(Save);
    
    public CommandHandler DeleteCommand =>
        new CommandHandler(Delete);
    
    public CommandHandler LikeCommand =>
        new CommandHandler(Like);
    
    private async void LoadAccess()
    {
        CanEdit = false;
    
        try
        {
            // if (client?.Login != null)
            //     if (client?.Login == Recipe.ClientOwner)
            //         CanEdit = true;
        }
        catch (Exception e)
        {
            CanEdit = false;
        }
    }
    
    public bool CanEdit
    {
        get => _canEdit;
        set
        {
            if (value == _canEdit) return;
            _canEdit = value;
            OnPropertyChanged();
        }
    }
    
    private async void Delete()
    {
        try
        {
            var recipe = await App.Context.Recipes.FirstOrDefaultAsync(c => c.Id == Recipe.Id);

            if (recipe != null)
            {
                App.Context.Recipes.Remove(recipe);
                await App.Context.SaveChangesAsync();
            }

            var notify = new ContentDialog()
            {
                Title = "Удалено",
                Content = "Рецепт успешно удален!",
                CloseButtonText = "Закрыть"
            };
    
            await notify.ShowAsync();
    
            Host.NavController.GoBack();
        }
        catch (Exception e)
        {
            var notify = new ContentDialog()
            {
                Title = "Ошибка",
                Content = "Возникла ошибка при удалении",
                CloseButtonText = "Закрыть"
            };
    
            await notify.ShowAsync();
        }
    }

    private void Like()
    {
        throw new NotImplementedException();
    }

    private void Edit() =>
        Host.NavController.Navigate(new EditRecipePage(Host, Recipe));

    private void Save()
    {
        throw new NotImplementedException();
    }
}