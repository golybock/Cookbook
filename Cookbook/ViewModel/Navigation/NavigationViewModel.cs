using System;
using System.Collections.Generic;
using System.Net.Http;
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
    private readonly ClientService _clientService = new ClientService();
    


    private string? _searchText;
    
    private bool _backVisible = false;
    private Page? _currentPage;

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
        CurrentPage = new RecipeListPage();
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
            CurrentPage = new SettingsPage();
            return;
        }

        var selected = args.InvokedItemContainer as NavigationViewItem;

        if (ReferenceEquals(selected?.Tag.ToString(), CurrentPage?.Tag))
            return;
        
        if (selected?.Tag.ToString() == "Recipes")
            CurrentPage = new RecipeListPage();
        
        if (selected?.Tag.ToString() == "Liked")
            CurrentPage = new RecipeListPage();

        if (selected?.Tag.ToString() == "Profile")
            ShowProfile();
    }

    private async void ShowProfile()
    {
        CurrentPage = new LoadingPage();

        try
        {
            var client = await _clientService.GetClientDomain();

            if (client == null)
            {
                CurrentPage = new NoAuthPage(this);
                return;
            }
        }
        catch (HttpRequestException e)
        {
            CurrentPage = new ConnectionErrorPage();
            return;
        }
        catch (Exception e)
        {
            CurrentPage = new ErrorPage();
        }
        
        CurrentPage = new ClientPage(this);
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

    public Page? CurrentPage
    {
        get => _currentPage;
        set
        {
            if (Equals(value, _currentPage)) return;
            _currentPage = value;
            OnPropertyChanged();
        }
    }

    public int CurrentPageIndex { get; set; }
    public List<Page> Items { get; set; }
}