using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Cookbook.Command;
using Cookbook.Database;
using Cookbook.Pages.Recipe;
using Cookbook.UI.Sort;
using Cookbook.ViewModel.Navigation;
using Microsoft.EntityFrameworkCore;
using Xceed.Document.NET;

namespace Cookbook.ViewModel.Recipe;

public class RecipesViewModel : ViewModelBase, INavItem
{
    private bool _userLogin = false;

    private List<Database.Recipe> firstRecipes;

    public List<Category> Categories { get; set; } = new List<Category>();

    public Category SelectedCategory
    {
        get => _selectedCategory;
        set
        {
            if (Equals(value, _selectedCategory)) return;
            _selectedCategory = value;
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
        
        OnPropertyChanged("Recipes");

        LoadCategories();
    }

    public CommandHandler<Database.Recipe> CardClickCommand =>
        new CommandHandler<Database.Recipe>(OpenRecipe);

    public CommandHandler AddCommand =>
        new CommandHandler(CreateRecipe);

    private void CreateRecipe()
    {
        Host.NavController.Navigate(new EditRecipePage(Host));
    }

    public bool UserLogin
    {
        get => _userLogin;
        set
        {
            if (value == _userLogin) return;
            _userLogin = value;
            OnPropertyChanged();
        }
    }

    private void OpenRecipe(Database.Recipe recipeDomain)
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

    private async void LoadAccess()
    {
        UserLogin = false;

        try
        {
            var login = App.Settings.Email;

            var client = await App.Context.Clients.FirstOrDefaultAsync(c => c.Email == login);

            if (client?.Email != null)
                UserLogin = true;
        }
        catch (Exception e)
        {
            UserLogin = false;
        }
    }

    private SortType _selectedSortType = UI.Sort.SortTypes.Default;
    private Category _selectedCategory = new Category();

    private async void SortRecipes()
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

    public INavHost Host { get; set; }
}