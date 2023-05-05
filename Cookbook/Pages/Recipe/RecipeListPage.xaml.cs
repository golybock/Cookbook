using System.Windows.Controls;
using Cookbook.ViewModel.Navigation;
using Cookbook.ViewModel.Recipe;

namespace Cookbook.Pages.Recipe;

public partial class RecipeListPage : Page
{
    public RecipeListPage(INavHost host)
    {
        InitializeComponent();
        DataContext = new RecipesViewModel(host);
    }
}