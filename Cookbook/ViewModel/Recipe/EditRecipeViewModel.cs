using Cookbook.Command;
using Cookbook.Models.Blank.Recipe;
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

    public CommandHandler CancelCommand() =>
        new CommandHandler(CancelEdit);

    public CommandHandler SaveCommand =>
        new CommandHandler(Save);

    public RecipeBlank Recipe { get; set; }

    public INavHost Host { get; set; }

    private void CancelEdit() => Host.NavController.GoBack();

    private void Save()
    {
        
    }
}