using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Cookbook.Command;
using Cookbook.Database;
using Cookbook.Services;
using Cookbook.ViewModel.ChooseDialogs;
using Cookbook.ViewModel.Navigation;
using Cookbook.Views.ChooseDialogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using ModernWpf.Controls;

namespace Cookbook.ViewModel.Recipe;

public class EditRecipeViewModel : ViewModelBase, INavItem
{
    public EditRecipeViewModel(INavHost host)
    {
        Host = host;
        Recipe = new Database.Recipe();

        LoadCategories();
    }

    public EditRecipeViewModel(INavHost host, Database.Recipe recipe)
    {
        Host = host;
        Recipe = recipe;

        Header = recipe.Header;
        Description = recipe.Description;

        Categories = new ObservableCollection<RecipeCategory>(recipe.RecipeCategories);
        Steps = new ObservableCollection<RecipeStep>(recipe.RecipeSteps);
        Ingredients = new ObservableCollection<RecipeIngredient>(recipe.RecipeIngredients);

        ImageUrl = recipe.ImagePath;

        LoadCategories();
    }

    #region setrvices

    private readonly RecipeService _recipeService = new();
    private readonly ClientService _clientService = new();

    #endregion

    #region private members

    private ObservableCollection<RecipeIngredient> _ingredients = new();

    private ObservableCollection<RecipeCategory> _categories = new();

    private ObservableCollection<RecipeStep> _steps = new();

    private ObservableCollection<Category> _recipeCategories = new();

    private Database.Recipe _recipe = new();

    private Category _selectedCategory = null!;

    private string _header = string.Empty;

    private string? _imageUrl;

    private string? _description;

    #endregion

    #region bind members

    public ObservableCollection<RecipeIngredient> Ingredients
    {
        get => _ingredients;
        set
        {
            if (Equals(value, _ingredients)) return;
            _ingredients = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Category> RecipeCategories
    {
        get => _recipeCategories;
        set
        {
            if (Equals(value, _recipeCategories)) return;
            _recipeCategories = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<RecipeCategory> Categories
    {
        get => _categories;
        set
        {
            if (Equals(value, _categories)) return;
            _categories = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<RecipeStep> Steps
    {
        get => _steps;
        set
        {
            if (Equals(value, _steps)) return;
            _steps = value;
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
            OnPropertyChanged();
        }
    }

    public Database.Recipe Recipe
    {
        get => _recipe;
        set
        {
            if (Equals(value, _recipe)) return;
            _recipe = value;
            OnPropertyChanged();
        }
    }

    public string? Description
    {
        get => _description;
        set
        {
            if (value == _description) return;

            Recipe.Description = value;
            _description = value;

            OnPropertyChanged();
        }
    }

    public string Header
    {
        get => _header;
        set
        {
            if (value == _header) return;

            Recipe.Header = value;
            _header = value;

            OnPropertyChanged();
        }
    }

    public string? ImageUrl
    {
        get => _imageUrl;
        set
        {
            if (value == _imageUrl) return;
            _imageUrl = value;
            OnPropertyChanged();
        }
    }

    #endregion

    #region public members

    public INavHost Host { get; set; }

    #endregion

    #region command handlers

    public CommandHandler CancelCommand => new(CancelEdit);

    public CommandHandler SaveCommand => new(Save);

    public CommandHandler AddIngredientButton => new(AddIngredient);

    public CommandHandler AddCategoryButton => new(AddCategory);

    public CommandHandler AddStepButton => new(AddStep);

    public CommandHandler ChooseImageCommand => new(ChooseImage);

    public CommandHandler<RecipeStep> DeleteStepCommand => new(DeleteStep);

    public CommandHandler<RecipeCategory> DeleteCategoryCommand => new(DeleteCategory);

    public CommandHandler<RecipeIngredient> DeleteIngredientCommand => new(DeleteIngredient);

    #endregion

    #region private functions(for handlers and etc)

    private async void LoadCategories()
    {
        var categories = await App.Context.Categories.ToListAsync();

        RecipeCategories = new ObservableCollection<Category>(categories);

        SelectedCategory = RecipeCategories.FirstOrDefault()!;
    }

    private async void CancelEdit()
    {
        var dialog = new ContentDialog()
        {
            Title = "Отмена создания/рекдактирования",
            PrimaryButtonText = "Отменить",
            CloseButtonText = "Остаться",
            Content = "Вы уверены, что хотите отменить создание/редактирование рецепта?"
        };

        var res = await dialog.ShowAsync();

        if (res == ContentDialogResult.Primary)
            Host.NavController.GoBack();
    }

    private void ChooseImage()
    {
        var path = ChooseFile();

        if (path == null)
            return;

        ImageUrl = path;
    }

    private string? ChooseFile()
    {
        var openFileDialog = new OpenFileDialog
        {
            InitialDirectory = "C:\\",
            Filter = "Image files (*.png)|*.png|All files (*.*)|*.*"
        };

        if (openFileDialog.ShowDialog() == true)
            return openFileDialog.FileName;

        return null;
    }

    private async void Save()
    {
        if (Recipe.Id == 0)
            await Create();
        else
            await Update();
    }

    private async Task Create()
    {
        Recipe.RecipeCategories = Categories.ToList();
        Recipe.RecipeIngredients = Ingredients.ToList();
        Recipe.RecipeSteps = Steps.ToList();
        Recipe.ClientId = _clientService.GetCurrent()?.Id;

        await _recipeService.Create(Recipe, ImageUrl);

        Host.NavController.GoBack();
    }

    private async Task Update()
    {
        Recipe.RecipeCategories = Categories.ToList();
        Recipe.RecipeIngredients = Ingredients.ToList();
        Recipe.RecipeSteps = Steps.ToList();
        Recipe.ClientId = _clientService.GetCurrent()?.Id;

        await _recipeService.Update(Recipe, ImageUrl);

        Host.NavController.GoBack();
    }

    private async void AddIngredient()
    {
        var context = new ChooseIngredientViewModel();

        var dialog = new ContentDialog()
        {
            Title = "Выбор ингедиента",
            Content = new ChooseIngredient(),
            DataContext = context,
            PrimaryButtonText = "Выбрать",
            CloseButtonText = "Закрыть"
        };

        var res = await dialog.ShowAsync();

        if (res == ContentDialogResult.Primary)
        {
            var ingredients = new List<RecipeIngredient>(Ingredients);

            var ingredient = ingredients
                .FirstOrDefault(c => c.Ingredient.Id == context.RecipeIngredient.Ingredient.Id);

            if (ingredient != null)
            {
                ingredient.Count += context.RecipeIngredient.Count;
                Ingredients = new ObservableCollection<RecipeIngredient>(ingredients);
            }

            else
            {
                Ingredients.Add(context.RecipeIngredient);
            }
        }

        OnPropertyChanged(nameof(Ingredients));
    }

    private async void AddCategory()
    {
        var context = new ChooseCategoryViewModel();

        var dialog = new ContentDialog()
        {
            Title = "Выбор категории",
            Content = new ChooseCategory(),
            DataContext = context,
            PrimaryButtonText = "Выбрать",
            CloseButtonText = "Закрыть"
        };

        var res = await dialog.ShowAsync();

        if (res == ContentDialogResult.Primary)
        {
            var category = Categories.FirstOrDefault(c => c.CategoryId == context.SelectedCategory.Id);

            if (category == null)
                Categories.Add(
                    new RecipeCategory()
                    {
                        Category = context.SelectedCategory,
                        CategoryId = context.SelectedCategory.Id
                    }
                );
        }

        OnPropertyChanged(nameof(Categories));
    }

    private void AddStep()
    {
        Steps.Add(new RecipeStep());

        OnPropertyChanged(nameof(Steps));
    }

    private void DeleteStep(RecipeStep recipeStep)
    {
        Steps.Remove(recipeStep);

        OnPropertyChanged(nameof(Steps));
    }

    private void DeleteCategory(RecipeCategory recipeCategory)
    {
        Categories.Remove(recipeCategory);

        OnPropertyChanged(nameof(Categories));
    }

    private void DeleteIngredient(RecipeIngredient recipeIngredientDomain)
    {
        Ingredients.Remove(recipeIngredientDomain);

        OnPropertyChanged(nameof(Ingredients));
    }

    #endregion
}