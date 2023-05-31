using Cookbook.ViewModel.Navigation;

namespace Cookbook.Views.Navigation;

public partial class NavigationView
{
    public NavigationView()
    {
        InitializeComponent();
        DataContext = new NavigationViewModel();
    }
}