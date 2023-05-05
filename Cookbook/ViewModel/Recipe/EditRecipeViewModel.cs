using Cookbook.Command;
using Cookbook.Models.Blank.Recipe;
using Cookbook.Models.Blank.Recipe.Category;
using Cookbook.Models.Blank.Recipe.Ingredient;
using Cookbook.Models.Domain.Recipe;
using Cookbook.ViewModel.Navigation;

namespace Cookbook.ViewModel.Recipe;

public class EditRecipeViewModel : ViewModelBase, INavItem
{
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

    public CommandHandler<RecipeStepBlank> DeleteStepCommand =>
        new CommandHandler<RecipeStepBlank>(DeleteStep);

    public CommandHandler<RecipeCategoryBlank> DeleteCategoryCommand =>
        new CommandHandler<RecipeCategoryBlank>(DeleteCategory);

    public CommandHandler<RecipeIngredientBlank> DeleteIngredientCommand =>
        new CommandHandler<RecipeIngredientBlank>(DeleteIngredient);

    public RecipeBlank Recipe { get; set; }

    public INavHost Host { get; set; }

    private void CancelEdit() => Host.NavController.GoBack();

    private void Save()
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