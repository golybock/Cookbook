using Cookbook.Models.Domain.Recipe;
using Cookbook.ViewModel.Navigation;

namespace Cookbook.ViewModel.Recipe;

public class RecipeViewModel : ViewModelBase, INavItem
{
    public RecipeViewModel(INavHost host)
    {
        Host = host;
    }

    public RecipeViewModel(INavHost host, RecipeDomain recipe)
    {
        Host = host;
        Recipe = recipe;
    }
    
    public INavHost Host { get; set; }
    
    public RecipeDomain Recipe { get; set; }
}