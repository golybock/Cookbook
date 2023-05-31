using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Command;
using Cookbook.Pages.Auth;
using Cookbook.Pages.Client;
using Cookbook.Pages.Notify;
using Cookbook.Pages.Recipe;
using Cookbook.Pages.Settings;
using Cookbook.Services;
using Microsoft.EntityFrameworkCore;
using ModernWpf.Controls;


namespace Cookbook.ViewModel.Navigation;

public class NavigationViewModel : ViewModelBase, INavHost
{
    private readonly RecipeService _recipeService = new();

    public ObservableCollection<string> RecipesSuggestions
    {
        get => _recipesSuggestions;
        set
        {
            if (Equals(value, _recipesSuggestions)) return;
            _recipesSuggestions = value;
            OnPropertyChanged();
        }
    }

    private string? _searchText;

    private bool _backVisible = false;

    private ObservableCollection<string> _recipesSuggestions;

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
        LoadSuggestions();
    }

    private async void LoadSuggestions()
    {
        var recipes = await _recipeService.Get();

        RecipesSuggestions = new ObservableCollection<string>(recipes
            .Select(c => c.Header)
            .Take(5));

        await SetRecipes();
    }

    private async void LoadSuggestions(string search)
    {
        var recipes = await _recipeService.Get();

        var searchList = recipes
            .Where(c => c.Header.ToLower()
                .Contains(search.ToLower()))
            .Select(c => c.Header)
            .Take(5);

        RecipesSuggestions = new ObservableCollection<string>(searchList);
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
            await SetRecipes();

        if (selected?.Tag.ToString() == "Liked")
            await SetLikedRecipes();

        if (selected?.Tag.ToString() == "Profile")
            ShowProfile();
    }

    private async void ShowProfile()
    {
        try
        {
            var login = App.Settings.Email;
            var password = App.Settings.Password;

            if (login == null || password == null)
            {
                NavController.Navigate(new NoAuthPage(this));
                return;
            }

            var client = await App.Context.Clients.FirstOrDefaultAsync(c => c.Email == login);

            if (client == null)
            {
                NavController.Navigate(new NoAuthPage(this));
                return;
            }

            NavController.Navigate(new ClientPage(this));
        }
        catch (Exception e)
        {
            NavController.Navigate(new ErrorPage());
        }
    }

    [SuppressMessage("ReSharper.DPA", "DPA0007: Large number of DB records", MessageId = "count: 103")]
    private async Task SetRecipes()
    {
        NavController.Navigate(new LoadingPage());

        try
        {
            var recipes = await App.Context.Recipes
                .Include(c => c.RecipeViews)
                .Include(c => c.RecipeCategories)
                .ToListAsync();

            if (recipes.Count == 0)
                NavController.Navigate(new NotFoundPage());
            else
                NavController.Navigate(new RecipesPage(this, recipes));
        }
        catch
        {
            NavController.Navigate(new ErrorPage());
        }
    }

    private async Task SetLikedRecipes()
    {
        NavController.Navigate(new LoadingPage());

        try
        {
            var email = App.Settings.Email;

            var client = await App.Context.Clients.FirstOrDefaultAsync(c => c.Email == email);

            if (client == null)
            {
                NavController.Navigate(new NoAuthPage(this));
                return;
            }

            var recipes = await App.Context.FavoriteRecipes
                .Include(c => c.Recipe)
                .Where(c => c.ClientId == client.Id)
                .Select(c => c.Recipe)
                .ToListAsync();

            if (recipes.Count == 0)
                NavController.Navigate(new NotFoundPage());
            else
                NavController.Navigate(new RecipesPage(this, recipes));
        }
        catch
        {
            NavController.Navigate(new ErrorPage());
        }
    }

    private async Task SetRecipes(string? search)
    {
        NavController.Navigate(new LoadingPage());

        try
        {
            List<Database.Recipe> recipes;

            if (string.IsNullOrWhiteSpace(search))
                recipes = await App.Context.Recipes
                    .Include(c => c.RecipeViews)
                    .ToListAsync();
            else
                recipes = await App.Context.Recipes
                    .Include(c => c.RecipeViews)
                    .Where(c => c.Header.ToLower().Contains(search.ToLower()))
                    .ToListAsync();

            if (recipes.Count == 0)
                NavController.Navigate(new NotFoundPage());
            else
                NavController.Navigate(new RecipesPage(this, recipes));
        }
        catch
        {
            NavController.Navigate(new ErrorPage());
        }
    }

    private async void QuerySubmitted()
    {
        await SetRecipes(SearchText);
    }

    private void TextChanged()
    {
        if (SearchText != null)
            LoadSuggestions(SearchText);
    }

    private async void SuggestionChosen()
    {
        await SetRecipes(SearchText);
    }

    public NavController NavController { get; set; } = new();
}