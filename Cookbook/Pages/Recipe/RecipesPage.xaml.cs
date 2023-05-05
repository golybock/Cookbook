using System.Windows.Controls;
using Cookbook.ViewModel.Navigation;
using Cookbook.ViewModel.Recipe;

namespace Cookbook.Pages.Recipe;

public partial class RecipesPage : Page
{
    public RecipesPage(INavHost host)
    {
        InitializeComponent();
        DataContext = new RecipesViewModel(host);
    }
}