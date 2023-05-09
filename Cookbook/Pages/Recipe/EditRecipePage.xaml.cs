using System.Windows.Controls;
using Cookbook.Models.Domain.Recipe;
using Cookbook.ViewModel.Navigation;
using Cookbook.ViewModel.Recipe;

namespace Cookbook.Pages.Recipe;

public partial class EditRecipePage : Page
{
    /// <summary>
    /// Constructor for create new recipe
    /// </summary>
    /// <param name="host"></param>
    public EditRecipePage(INavHost host)
    {
        InitializeComponent();
        
        Title = "Создание рецепта";
        
        DataContext = new EditRecipeViewModel(host);
    }

    /// <summary>
    /// Constructor for edit existing recipe
    /// </summary>
    /// <param name="host"></param>
    /// <param name="recipeDomain"></param>
    public EditRecipePage(INavHost host, RecipeDomain recipeDomain)
    {
        InitializeComponent();
        
        Title = "Редактирование рецепта";
        
        DataContext = new EditRecipeViewModel(host, recipeDomain);
    }
}