using System.Windows.Controls;
using Cookbook.ViewModel.Navigation;

namespace Cookbook.Views.Navigation;

public partial class NavigationView : UserControl
{
    public NavigationView()
    {
        InitializeComponent();
        DataContext = new NavigationViewModel();
    }
}