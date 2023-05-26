using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Command;
using Cookbook.Pages.Auth;
using Cookbook.Pages.Client;
using Cookbook.Pages.Notify;
using Cookbook.Pages.Recipe;
using Cookbook.Pages.Settings;
using Microsoft.EntityFrameworkCore;
using ModernWpf.Controls;


namespace Cookbook.ViewModel.Navigation;

public class NavigationViewModel : ViewModelBase, INavHost
{
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
        SetRecipes();
    }

    public string? SearchText
    {
        get => _searchText;
        set
        {
            if (value == _searchText) return;
            _searchText = value;
            SetRecipes(_searchText);
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
            SetRecipes();

        if (selected?.Tag.ToString() == "Liked")
            NavController.Navigate(new RecipesPage(this));

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
                var client = await App.Context.Clients.FirstOrDefaultAsync(c => c.Email == login);

                NavController.Navigate(new NoAuthPage(this));
                return;
            }
        }
        catch (Exception e)
        {
            NavController.Navigate(new ErrorPage());
        }

        NavController.Navigate(new ClientPage(this));
    }

    private async void SetRecipes()
    {
        NavController.Navigate(new LoadingPage());

        try
        {
            var recipes = await App.Context.Recipes
                .Include(c => c.RecipeIngredients)
                .Include(c => c.RecipeSteps)
                .Include(c => c.RecipeStat)
                .Include(c => c.RecipeViews)
                .ToListAsync();

            NavController.Navigate(new RecipesPage(this, recipes));
        }
        catch (Exception e)
        {
            NavController.Navigate(new ErrorPage());
        }
    }

    private async void SetRecipes(string? search)
    {
        NavController.Navigate(new LoadingPage());

        try
        {
            List<Database.Recipe> recipes;

            if (string.IsNullOrWhiteSpace(search))
            {
                recipes = await App.Context.Recipes
                    .Include(c => c.RecipeIngredients)
                    .Include(c => c.RecipeSteps)
                    .Include(c => c.RecipeStat)
                    .Include(c => c.RecipeViews)
                    .ToListAsync();
            }
            else
            {
                recipes = await App.Context.Recipes
                    .Include(c => c.RecipeIngredients)
                    .Include(c => c.RecipeSteps)
                    .Include(c => c.RecipeStat)
                    .Include(c => c.RecipeViews)
                    .Where(c => c.Description != null && (c.Header.ToLower().Contains(search) ||
                                                          c.Description.ToLower().Contains(search)))
                    .ToListAsync();    
            }
            
            if(recipes.Count == 0)
                NavController.Navigate(new NotFoundPage());
            else
                NavController.Navigate(new RecipesPage(this, recipes));
            
        }
        catch (Exception e)
        {
            NavController.Navigate(new ErrorPage());
        }
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