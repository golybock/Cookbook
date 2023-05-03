using System.Collections.Generic;
using System.Collections.ObjectModel;
using Cookbook.UI.Sort;
using Domain.Recipe;
using Xceed.Document.NET;

namespace Cookbook.ViewModel.Recipe;

public class RecipesViewModel : ViewModelBase
{
    private SortType _selectedSortType = UI.Sort.SortTypes.Default;
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

    public RecipeTypeDomain SelectedRecipeType { get; set; } = new RecipeTypeDomain();
    
    public RecipesViewModel()
    {
        Recipes.Add(new RecipeDomain() { Header = "Beba"});
        Recipes.Add(new RecipeDomain() { Header = "Boba"});
        Recipes.Add(new RecipeDomain() { Header = "Biba"});
        Recipes.Add(new RecipeDomain() { Header = "Biba"});
        Recipes.Add(new RecipeDomain() { Header = "Biba"});
        Recipes.Add(new RecipeDomain() { Header = "Biba"});
        Recipes.Add(new RecipeDomain() { Header = "Biba"});
        OnPropertyChanged("Recipes");
    }
}