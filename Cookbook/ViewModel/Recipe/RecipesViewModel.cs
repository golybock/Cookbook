using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Cookbook.Command;
using Cookbook.Database;
using Cookbook.Pages.Auth;
using Cookbook.Pages.Recipe;
using Cookbook.Services;
using Cookbook.UI.Sort;
using Cookbook.ViewModel.Navigation;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.ViewModel.Recipe;

public class RecipesViewModel : ViewModelBase, INavItem
{
    public RecipesViewModel(INavHost host)
    {
        Host = host;
        Host.NavController.Clear();
    }
    
    public RecipesViewModel(INavHost host, List<Database.Recipe> recipes)
    {
        Host = host;

        Recipes = new ObservableCollection<Database.Recipe>(recipes);

        _firstRecipes = new List<Database.Recipe>(recipes);

        LoadCategories();
    }
    
    #region private members

    private readonly List<Database.Recipe> _firstRecipes = new List<Database.Recipe>();

    private SortType _selectedSortType = UI.Sort.SortTypes.Default;
    
    private Category _selectedCategory = new Category();
    
    #endregion

    #region public members

    public INavHost Host { get; set; }

    #endregion
    
    #region public bind members

    public ObservableCollection<Database.Recipe> Recipes { get; set; } = new ObservableCollection<Database.Recipe>();
    
    public List<Category> Categories { get; set; } = new List<Category>();

    public List<SortType> SortTypes =>
        UI.Sort.SortTypes.SortTypesList;

    public SortType SelectedSortType
    {
        get => _selectedSortType;
        set
        {
            if (Equals(value, _selectedSortType)) return;
            _selectedSortType = value;

            SortRecipes();

            OnPropertyChanged();
        }
    }
    
    public Category SelectedCategory
    {
        get => _selectedCategory;
        set
        {
            if (Equals(value, _selectedCategory)) return;
            _selectedCategory = value;

            SortRecipes();

            OnPropertyChanged();
        }
    }
    
    public bool IsAuth => ClientService.IsAuth();
    
    #endregion

    #region command handlers

    public CommandHandler<Database.Recipe> CardClickCommand =>
        new CommandHandler<Database.Recipe>(OpenRecipe);

    public CommandHandler AddCommand =>
        new CommandHandler(CreateRecipe);

    #endregion

    #region private functions

    private void CreateRecipe()
    {
        if (IsAuth)
            Host.NavController.Navigate(new EditRecipePage(Host));
        else
            Host.NavController.Navigate(new NoAuthPage(Host));
    }
    
    private void OpenRecipe(Database.Recipe? recipeDomain)
    {
        Host.NavController.Navigate(new RecipePage(Host, recipeDomain));
    }

    #endregion

    #region load and render data

    private async void LoadCategories()
    {
        // get categories
        Categories = await App.Context.Categories.ToListAsync();
        OnPropertyChanged(nameof(Categories));

        // set default value
        Categories.Add(new Category() {Id = -1, Name = "Все категории"});
        SelectedCategory = Categories.LastOrDefault()!;
    }

    #region sorting

    private void SortRecipes()
    {
        var sortingStart = new List<Database.Recipe>(_firstRecipes);
        
        // sort
        if (SelectedCategory.Id == -1)
        {
            var sorted = OrderByRecipes(sortingStart);
            
            Recipes = new ObservableCollection<Database.Recipe>(sorted);
        }
        // order by category (and sort)
        else
        {
            var recipes = sortingStart
                .Where(ContainsInCategory)
                .ToList();

            var sorted = OrderByRecipes(recipes);

            Recipes = new ObservableCollection<Database.Recipe>(sorted);
        }
    }

    private List<Database.Recipe> OrderByRecipes(List<Database.Recipe> recipes)
    {
        if (SelectedSortType.Id == 1)
        {
            return recipes
                .OrderBy(c => c.Header)
                .ToList();
        }

        if (SelectedSortType.Id == 2)
        {
            return recipes
                .OrderBy(c => c.RecipeStat.CookingTime)
                .ToList();
        }

        if (SelectedSortType.Id == 3)
        {
            return recipes
                .OrderBy(c => c.Views)
                .Reverse()
                .ToList();
        }

        return recipes;
    }

    private bool ContainsInCategory(Database.Recipe c)
    {
        return c.RecipeCategories.FirstOrDefault(category => category.CategoryId == SelectedCategory.Id) != null;
    }

    #endregion

    #endregion
}