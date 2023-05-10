using System;
using System.Collections.Generic;
using System.Windows;
using Cookbook.Api.Client;
using Cookbook.Command;
using Cookbook.Models.Domain.Recipe;
using Cookbook.Models.Domain.Recipe.Category;
using Cookbook.Models.Domain.Recipe.Ingredient;
using Cookbook.Pages.Recipe;
using Cookbook.Services;
using Cookbook.ViewModel.Navigation;
using ModernWpf.Controls;

namespace Cookbook.ViewModel.Recipe;

public class RecipeViewModel : ViewModelBase, INavItem
{
    private readonly ClientApi _clientApi = new ClientApi();
    private readonly RecipeService _recipeService = new RecipeService();

    private bool _canEdit = false;
    

    public INavHost Host { get; set; }

    public RecipeDomain Recipe { get; set; } = new RecipeDomain();




    public RecipeViewModel(INavHost host)
    {
        Host = host;

        LoadAccess();
    }

    public RecipeViewModel(INavHost host, RecipeDomain recipe)
    {
        Host = host;
        Recipe = recipe;

        LoadAccess();
    }


    public bool RecipeIngredientsVisible =>
        Recipe.Ingredients.Count > 0;

    public bool RecipeCategoriesVisible =>
        Recipe.Categories.Count > 0;

    public bool RecipeStepsVisible =>
        Recipe.Steps.Count > 0;

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
            var client = await _clientApi.GetClientAsync();

            if (client?.Login != null)
                if (client?.Login == Recipe.ClientOwner)
                    CanEdit = true;
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
            if (Recipe.Code != null)
                await _recipeService.Recipe.Delete(Recipe.Code);

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