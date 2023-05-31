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
    public INavHost Host { get; set; }

    private List<Database.Recipe> firstRecipes = new List<Database.Recipe>();

    public List<Category> Categories { get; set; } = new List<Category>();

    public Category SelectedCategory
    {
        get => _selectedCategory;
        set
        {
            if (Equals(value, _selectedCategory)) return;
            _selectedCategory = value;
            
            SortRecipesByCategories();
            
            OnPropertyChanged();
        }
    }

    public RecipesViewModel(INavHost host)
    {
        Host = host;
    }

    public RecipesViewModel(INavHost host, List<Database.Recipe> recipes)
    {
        Host = host;

        Recipes = new ObservableCollection<Database.Recipe>(recipes);

        firstRecipes = new List<Database.Recipe>(recipes);

        LoadCategories();
    }

    public CommandHandler<Database.Recipe> CardClickCommand =>
        new CommandHandler<Database.Recipe>(OpenRecipe);

    public CommandHandler AddCommand =>
        new CommandHandler(CreateRecipe);

    private void CreateRecipe()
    {
        if (IsAuth)
            Host.NavController.Navigate(new EditRecipePage(Host));
        else
            Host.NavController.Navigate(new NoAuthPage(Host));
    }

    public bool IsAuth => ClientService.IsAuth();

    private void OpenRecipe(Database.Recipe? recipeDomain)
    {
        Host.NavController.Navigate(new RecipePage(Host, recipeDomain));
    }

    private async void LoadCategories()
    {
        Categories = await App.Context.Categories.ToListAsync();
        OnPropertyChanged("Categories");

        Categories.Add(new Category() {Id = -1, Name = "Все категории"});

        SelectedCategory = Categories.LastOrDefault()!;
    }

    private SortType _selectedSortType = UI.Sort.SortTypes.Default;
    private Category _selectedCategory = new Category();

    private void SortRecipes()
    {
        if (SelectedSortType.Id == 0)
            Recipes = new ObservableCollection<Database.Recipe>(firstRecipes);

        if (SelectedSortType.Id == 1)
        {
            var sorted = Recipes.OrderBy(c => c.Header);
            Recipes = new ObservableCollection<Database.Recipe>(sorted);
        }

        if (SelectedSortType.Id == 2)
        {
            var sorted = Recipes.OrderBy(c => c.RecipeStat?.CookingTime);
            Recipes = new ObservableCollection<Database.Recipe>(sorted);
        }

        if (SelectedSortType.Id == 3)
        {
            var sorted = Recipes.OrderBy(c => c.Views)
                .Reverse()
                .ToList();
            Recipes = new ObservableCollection<Database.Recipe>(sorted);
        }

        OnPropertyChanged("Recipes");
    }

    private void SortRecipesByCategories()
    {
        if (SelectedCategory.Id == -1)
            Recipes = new ObservableCollection<Database.Recipe>(firstRecipes);

        else
        {
            var sorting = new ObservableCollection<Database.Recipe>(firstRecipes);
            
            var recipes = sorting.Where(c =>
                c.RecipeCategories.FirstOrDefault(c => c.CategoryId == SelectedCategory.Id) != null)
                .ToList();

            Recipes = new ObservableCollection<Database.Recipe>(recipes);
        }

        OnPropertyChanged("Recipes");
    }

    public ObservableCollection<Database.Recipe> Recipes { get; set; } = new ObservableCollection<Database.Recipe>();

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
}