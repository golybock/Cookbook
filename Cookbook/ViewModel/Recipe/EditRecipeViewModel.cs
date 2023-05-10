using System.Collections.ObjectModel;
using System.Linq;
using Cookbook.Api.Recipe;
using Cookbook.Command;
using Cookbook.Models.Blank.Recipe;
using Cookbook.Models.Blank.Recipe.Category;
using Cookbook.Models.Blank.Recipe.Ingredient;
using Cookbook.Models.Domain.Recipe;
using Cookbook.Services;
using Cookbook.ViewModel.ChooseDialogs;
using Cookbook.ViewModel.Navigation;
using Cookbook.Views.ChooseDialogs;
using ModernWpf.Controls;

namespace Cookbook.ViewModel.Recipe;

public class EditRecipeViewModel : ViewModelBase, INavItem
{
    private ObservableCollection<RecipeTypeDomain> _recipeTypeDomains = new ObservableCollection<RecipeTypeDomain>();
    private RecipeService _recipeService = new RecipeService();
    private RecipeTypeDomain _selectedRecipeTypeDomain = new RecipeTypeDomain();

    private ObservableCollection<RecipeIngredientDomain> _ingredients =
        new ObservableCollection<RecipeIngredientDomain>();

    public RecipeBlank Recipe { get; set; }

    public string? ImageUrl { get; set; }

    public INavHost Host { get; set; }

    public ObservableCollection<RecipeTypeDomain> RecipeTypeDomains
    {
        get => _recipeTypeDomains;
        set
        {
            if (Equals(value, _recipeTypeDomains)) return;
            _recipeTypeDomains = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<RecipeIngredientDomain> Ingredients
    {
        get => _ingredients;
        set
        {
            if (Equals(value, _ingredients)) return;
            _ingredients = value;
            OnPropertyChanged();
        }
    }

    public RecipeTypeDomain SelectedRecipeTypeDomain
    {
        get => _selectedRecipeTypeDomain;
        set
        {
            if (Equals(value, _selectedRecipeTypeDomain)) return;
            _selectedRecipeTypeDomain = value;

            Recipe.TypeId = value.Id;

            OnPropertyChanged();
        }
    }

    public EditRecipeViewModel(INavHost host)
    {
        Host = host;
        Recipe = new RecipeBlank();
        GetRecipeTypes();
    }

    public EditRecipeViewModel(INavHost host, RecipeDomain recipeDomain)
    {
        Host = host;
        Recipe = new RecipeBlank(recipeDomain);
        GetRecipeTypes();

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

    public CommandHandler<RecipeStepBlank> DeleteStepCommand =>
        new CommandHandler<RecipeStepBlank>(DeleteStep);

    public CommandHandler<RecipeCategoryBlank> DeleteCategoryCommand =>
        new CommandHandler<RecipeCategoryBlank>(DeleteCategory);

    public CommandHandler<RecipeIngredientDomain> DeleteIngredientCommand =>
        new CommandHandler<RecipeIngredientDomain>(DeleteIngredient);

    public async void GetRecipeTypes()
    {
        var types = await _recipeService.RecipeType.Get();

        if (types != null)
            RecipeTypeDomains = new(types);

        RecipeTypeDomains.Add(new RecipeTypeDomain()
        {
            Id = 0,
            Name = "Не выбрано"
        });

        SelectedRecipeTypeDomain = RecipeTypeDomains.LastOrDefault()!;

        OnPropertyChanged("RecipeTypeDomains");
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
            var ingredient = Ingredients
                .FirstOrDefault(c => c.IngredientId == context.RecipeIngredientDomain.IngredientId);

            if (ingredient != null)
                ingredient.Count += context.RecipeIngredientDomain.Count;

            else
                Ingredients.Add(context.RecipeIngredientDomain);
        }

        OnPropertyChanged(nameof(Ingredients));
    }

    private async void AddCategory()
    {
    }

    private async void AddStep()
    {
    }

    private void DeleteStep(RecipeStepBlank recipeStepBlank)
    {
    }

    private void DeleteCategory(RecipeCategoryBlank recipeCategoryBlank)
    {
    }

    private void DeleteIngredient(RecipeIngredientDomain recipeIngredientDomain)
    {
        Ingredients.Remove(recipeIngredientDomain);

        OnPropertyChanged(nameof(Ingredients));
    }
}