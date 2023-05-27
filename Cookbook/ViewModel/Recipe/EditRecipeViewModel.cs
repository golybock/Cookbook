using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Cookbook.Command;
using Cookbook.Database;
using Cookbook.ViewModel.ChooseDialogs;
using Cookbook.ViewModel.Navigation;
using Cookbook.Views.ChooseDialogs;
using ModernWpf.Controls;
using Xceed.Document.NET;

namespace Cookbook.ViewModel.Recipe;

public class EditRecipeViewModel : ViewModelBase, INavItem
{
    private ObservableCollection<RecipeIngredient> _ingredients =
        new ObservableCollection<RecipeIngredient>();
    
    public Database.Recipe? Recipe { get; set; }

    public string? ImageUrl { get; set; }

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

    public EditRecipeViewModel(INavHost host)
    {
        Host = host;
        Recipe = new Database.Recipe();
    }
    
    public EditRecipeViewModel(INavHost host, Database.Recipe? recipeDomain)
    {
        Host = host;
        Recipe = recipeDomain;

        ImageUrl = recipeDomain.ImagePath;
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
                .FirstOrDefault(c => c.IngredientId == context.RecipeIngredient.IngredientId);
    
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
    }
    
    private async void AddStep()
    {
    }
    
    private void DeleteStep(RecipeStep recipeStepBlank)
    {
    }
    
    private void DeleteCategory(RecipeCategory recipeCategoryBlank)
    {
    }
    
    private void DeleteIngredient(RecipeIngredient recipeIngredientDomain)
    {
        Ingredients.Remove(recipeIngredientDomain);
    
        OnPropertyChanged(nameof(Ingredients));
    }
}