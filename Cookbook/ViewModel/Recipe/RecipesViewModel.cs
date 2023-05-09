using System.Collections.Generic;
using System.Collections.ObjectModel;
using Cookbook.Command;
using Cookbook.Models.Domain.Recipe;
using Cookbook.Pages.Recipe;
using Cookbook.UI.Sort;
using Cookbook.ViewModel.Navigation;
using Xceed.Document.NET;

namespace Cookbook.ViewModel.Recipe;

public class RecipesViewModel : ViewModelBase, INavItem
{
    public RecipesViewModel(INavHost host)
    {
        Host = host;
    }
    
    public RecipesViewModel(INavHost host, List<RecipeDomain> recipeDomains)
    {
        Host = host;

        Recipes = new ObservableCollection<RecipeDomain>(recipeDomains);
        OnPropertyChanged("Recipes");
    }
    
    public CommandHandler<RecipeDomain> CardClickCommand =>
        new CommandHandler<RecipeDomain>(OpenRecipe);

    private void OpenRecipe(RecipeDomain recipeDomain)
    {
        Host.NavController.Navigate(new RecipePage(Host, recipeDomain));
    }
    
    private SortType _selectedSortType = UI.Sort.SortTypes.Default;
    
    private RecipeTypeDomain _selectedRecipeType = new RecipeTypeDomain();

    public ObservableCollection<RecipeDomain> Recipes { get; set; } = new ObservableCollection<RecipeDomain>();

    public List<SortType> SortTypes => 
        UI.Sort.SortTypes.SortTypesList;

    public ObservableCollection<RecipeTypeDomain> RecipeTypes { get; set; } =
        new ObservableCollection<RecipeTypeDomain>();

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
        
    }
    
    public INavHost Host { get; set; }
}