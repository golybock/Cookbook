using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Cookbook.Command;
using Cookbook.Database;
using Cookbook.ViewModel.ChooseDialogs;
using Cookbook.ViewModel.Navigation;
using Cookbook.Views.ChooseDialogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using ModernWpf.Controls;
using Xceed.Document.NET;

namespace Cookbook.ViewModel.Recipe;

public class EditRecipeViewModel : ViewModelBase, INavItem
{
    private ObservableCollection<RecipeIngredient> _ingredients =
        new ObservableCollection<RecipeIngredient>();

    private ObservableCollection<RecipeCategory> _categories =
        new ObservableCollection<RecipeCategory>();

    private ObservableCollection<RecipeStep> _steps =
        new ObservableCollection<RecipeStep>();

    private string? _imageUrl;
    private ObservableCollection<Category> _recipeCategories;
    private Category _selectedCategory;
    
    private string _description;
    private string _header;

    public string Description
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

    public Database.Recipe? Recipe { get; set; }

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

    public INavHost Host { get; set; }

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

    public EditRecipeViewModel(INavHost host)
    {
        Host = host;
        Recipe = new Database.Recipe();
        
        LoadCategories();
    }

    public EditRecipeViewModel(INavHost host, Database.Recipe? recipeDomain)
    {
        Host = host;
        Recipe = recipeDomain;

        ImageUrl = recipeDomain.ImagePath;
        
        LoadCategories();
    }

    private async void LoadCategories()
    {
        var categories = await App.Context.Categories.ToListAsync();

        RecipeCategories = new ObservableCollection<Category>(categories);

        SelectedCategory = RecipeCategories.FirstOrDefault();
    }

    public CommandHandler CancelCommand =>
        new CommandHandler(CancelEdit);

    public CommandHandler SaveCommand =>
        new CommandHandler(Save);

    public CommandHandler AddIngredientButton =>
        new CommandHandler(AddIngredient);

    public CommandHandler AddCategoryButton =>
        new CommandHandler(AddCategory);

    public CommandHandler AddStepButton =>
        new CommandHandler(AddStep);

    public CommandHandler ChooseImageCommand =>
        new CommandHandler(ChooseImage);

    public CommandHandler<RecipeStep> DeleteStepCommand =>
        new CommandHandler<RecipeStep>(DeleteStep);

    public CommandHandler<RecipeCategory> DeleteCategoryCommand =>
        new CommandHandler<RecipeCategory>(DeleteCategory);

    public CommandHandler<RecipeIngredient> DeleteIngredientCommand =>
        new CommandHandler<RecipeIngredient>(DeleteIngredient);

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

    private async void ChooseImage()
    {
        var path = ChooseFile();
        
        if(path == null)
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
    
    private void Save()
    {
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
                .FirstOrDefault(c => c.IngredientId == context.RecipeIngredient.Ingredient.Id);

            if (ingredient != null)
            {
                ingredient.Count += context.RecipeIngredient.Count;
                Ingredients = new(ingredients);
            }

            else
                Ingredients.Add(context.RecipeIngredient);
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

    private async void AddStep()
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
}