using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Cookbook.Api.Client;
using Cookbook.Command;
using Cookbook.Models.Domain.Recipe;
using Cookbook.Pages.Recipe;
using Cookbook.Services;
using Cookbook.UI.Sort;
using Cookbook.ViewModel.Navigation;
using Xceed.Document.NET;

namespace Cookbook.ViewModel.Recipe;

public class RecipesViewModel : ViewModelBase, INavItem
{
    private readonly ClientApi _clientApi = new ClientApi();
    private bool _userLogin = false;
    
    public RecipesViewModel(INavHost host)
    {
        Host = host;
    }
    
    public RecipesViewModel(INavHost host, List<RecipeDomain> recipeDomains)
    {
        Host = host;

        Recipes = new ObservableCollection<RecipeDomain>(recipeDomains);
        OnPropertyChanged("Recipes");
        
        LoadRecipeTypes();
    }
    
    public CommandHandler<RecipeDomain> CardClickCommand =>
        new CommandHandler<RecipeDomain>(OpenRecipe);

    public CommandHandler AddCommand =>
        new CommandHandler(CreateRecipe);

    private void CreateRecipe()
    {
        Host.NavController.Navigate(new EditRecipePage(Host));
    }
    
    public bool UserLogin
    {
        get => _userLogin ;
        set
        {
            if (value == _userLogin ) return;
            _userLogin  = value;
            OnPropertyChanged();
        }
    }
    
    private void OpenRecipe(RecipeDomain recipeDomain)
    {
        Host.NavController.Navigate(new RecipePage(Host, recipeDomain));
    }
    
    private async void LoadAccess()
    {
        UserLogin = false;

        try
        {
            var client = await _clientApi.GetClientAsync();

            if (client?.Login != null)
                UserLogin = true;
        }
        catch (Exception e)
        {
            UserLogin = false;
        }
    }
    
    private SortType _selectedSortType = UI.Sort.SortTypes.Default;
    
    private RecipeTypeDomain _selectedRecipeType = new RecipeTypeDomain();

    public ObservableCollection<RecipeDomain> Recipes { get; set; } = new ObservableCollection<RecipeDomain>();

    public List<SortType> SortTypes => 
        UI.Sort.SortTypes.SortTypesList;

    public ObservableCollection<RecipeTypeDomain> RecipeTypes { get; set; } =
        new ObservableCollection<RecipeTypeDomain>();

    private readonly RecipeService _recipeService = new RecipeService();
    
    public SortType SelectedSortType
    {
        get => _selectedSortType;
        set
        {
            if (Equals(value, _selectedSortType)) return;
            _selectedSortType = value;
            OnPropertyChanged();
        }
    }

    public RecipeTypeDomain SelectedRecipeType
    {
        get => _selectedRecipeType;
        set
        {
            if (Equals(value, _selectedRecipeType)) return;
            _selectedRecipeType = value;
            OnPropertyChanged();
        }
    }

    public async void LoadRecipeTypes()
    {
        RecipeTypes = new((await _recipeService.RecipeType.Get())!);
        
        RecipeTypes.Add(new RecipeTypeDomain()
        {
            Id = 0, Name = "Все типы"
        });

        SelectedRecipeType = RecipeTypes.LastOrDefault();
        
        OnPropertyChanged("RecipeTypes");
    }
    
    public INavHost Host { get; set; }
}