using System.Collections.Generic;
using System.Windows.Controls;
using Cookbook.ViewModel.Navigation;
using Cookbook.ViewModel.Recipe;

namespace Cookbook.Pages.Recipe;

public partial class RecipesPage : Page
{
    /// <summary>
    /// Empty view
    /// </summary>
    /// <param name="host"></param>
    public RecipesPage(INavHost host)
    {
        InitializeComponent();
        DataContext = new RecipesViewModel(host);
    }

    /// <summary>
    /// Show given recipes (find and loading on the navigationView)
    /// </summary>
    /// <param name="host"></param>
    /// <param name="recipeDomains"></param>
    public RecipesPage(INavHost host, List<Database.Recipe> recipeDomains)
    {
        InitializeComponent();
        DataContext = new RecipesViewModel(host, recipeDomains);
    }
}