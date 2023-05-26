using System.Windows.Controls;
using Cookbook.ViewModel.Navigation;
using Cookbook.ViewModel.Recipe;

namespace Cookbook.Pages.Recipe;

public partial class RecipePage : Page
{
    
    /// <summary>
    ///  Empty page
    /// </summary>
    /// <param name="host"></param>
    public RecipePage(INavHost host)
    {
        InitializeComponent();
        DataContext = new RecipeViewModel(host);
    }
    
    /// <summary>
    /// Recipe view 
    /// </summary>
    /// <param name="host"></param>
    /// <param name="recipeDomain"></param>
    public RecipePage(INavHost host, Database.Recipe recipeDomain)
    {
        InitializeComponent();
        DataContext = new RecipeViewModel(host, recipeDomain);
    }
}