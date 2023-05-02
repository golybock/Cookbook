using System.Windows.Controls;
using Cookbook.ViewModel.Recipe;

namespace Cookbook.Pages.Recipe;

public partial class RecipeListPage : Page
{
    public RecipeListPage()
    {
        InitializeComponent();
        DataContext = new RecipeListViewModel();
    }
}