using System;
using System.Collections.Generic;
using System.Net.Http;
using Cookbook.Api.Client;
using Cookbook.Api.Recipe;
using Cookbook.Command;
using Cookbook.Pages.Auth;
using Cookbook.Pages.Client;
using Cookbook.Pages.Notify;
using Cookbook.Pages.Recipe;
using Cookbook.Pages.Settings;
using Cookbook.Services;
using ModernWpf.Controls;
using Page = System.Windows.Controls.Page;


namespace Cookbook.ViewModel.Navigation;

public class NavigationViewModel : ViewModelBase, INavHost
{
    private readonly ClientApi _clientApi = new ClientApi();
    private readonly RecipeApi _recipeApi = new RecipeApi();
    
    private string? _searchText;
    
    private bool _backVisible = false;

    public bool BackVisible
    {
        get => _backVisible;
        set
        {
            if (value == _backVisible) return;
            OnPropertyChanged();
        }
    }

    public NavigationViewModel()
    {
        BackVisible = false;
        NavController.Navigate(new RecipesPage(this));
    }
    

    public string? SearchText
    {
        get => _searchText;
        set
        {
            if (value == _searchText) return;
            _searchText = value;
            OnPropertyChanged();
        }
    }

    public CommandHandler<NavigationViewItemInvokedEventArgs> NavigationViewItemInvokedCommand =>
        new(NavigationViewItemInvoked);

    public CommandHandler QuerySubmittedCommand =>
        new(QuerySubmitted);

    public CommandHandler TextChangedCommand =>
        new(TextChanged);

    public CommandHandler SuggestionChosenCommand =>
        new(SuggestionChosen);

    private async void NavigationViewItemInvoked(NavigationViewItemInvokedEventArgs args)
    {
        if (args.IsSettingsInvoked)
        {
            NavController.Navigate(new SettingsPage());
            return;
        }

        var selected = args.InvokedItemContainer as NavigationViewItem;

        if (ReferenceEquals(selected?.Tag.ToString(), NavController.CurrentPage?.Tag))
            return;
        
        if (selected?.Tag.ToString() == "Recipes")
            NavController.Navigate(new RecipesPage(this));

        if (selected?.Tag.ToString() == "Liked")
            NavController.Navigate(new RecipesPage(this));

        if (selected?.Tag.ToString() == "Profile")
            ShowProfile();
    }

    private async void ShowProfile()
    {
        NavController.Navigate(new LoadingPage());

        try
        {
            var client = await _clientApi.GetClientAsync();

            if (client == null)
            {
                NavController.Navigate(new NoAuthPage(this));
                return;
            }
        }
        catch (HttpRequestException e)
        {
            NavController.Navigate(new ConnectionErrorPage());
            return;
        }
        catch (Exception e)
        {
            NavController.Navigate(new ErrorPage());
        }
        
        NavController.Navigate(new ClientPage(this));
    }

    private void SetRecipes()
    {
        var recipes = await _recipeApi.
    }

    private void SetRecipes(string search)
    {
        
    }
    
    private async void QuerySubmitted()
    {

    }

    private async void TextChanged()
    {
        
    }

    private async void SuggestionChosen()
    {
        
    }

    public NavController NavController { get; set; } = new NavController();
}