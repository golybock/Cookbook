using Cookbook.Command;
using Cookbook.Models.Blank.Recipe;
using Cookbook.Models.Blank.Recipe.Category;
using Cookbook.Models.Blank.Recipe.Ingredient;
using Cookbook.Models.Domain.Recipe;
using Cookbook.ViewModel.Navigation;
using ModernWpf.Controls;

namespace Cookbook.ViewModel.Recipe;

public class EditRecipeViewModel : ViewModelBase, INavItem
{
    public RecipeBlank Recipe { get; set; }

    public INavHost Host { get; set; }

    public EditRecipeViewModel(INavHost host)
    {
        Host = host;
        Recipe = new RecipeBlank();
    }

    public EditRecipeViewModel(INavHost host, RecipeDomain recipeDomain)
    {
        Host = host;
        Recipe = new RecipeBlank(recipeDomain);
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

    public CommandHandler<RecipeIngredientBlank> DeleteIngredientCommand =>
        new CommandHandler<RecipeIngredientBlank>(DeleteIngredient);

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
        
        if(res == ContentDialogResult.Primary)
            Host.NavController.GoBack();
    }

    private void Save()
    {
        
    }

    private async void AddIngredient()
    {
        
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
    
    private void DeleteIngredient(RecipeIngredientBlank recipeIngredientBlank)
    {
        
    }
}