using System.Windows.Controls;
using Cookbook.ViewModel.Navigation;
using Cookbook.ViewModel.Recipe;

namespace Cookbook.Pages.Recipe;

public partial class RecipePage : Page
{
    public RecipePage(INavHost host)
    {
        InitializeComponent();
        DataContext = new RecipeViewModel(host);
    }
}