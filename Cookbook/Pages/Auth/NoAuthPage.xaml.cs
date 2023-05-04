using System.Windows.Controls;
using Cookbook.ViewModel.Auth;

namespace Cookbook.Pages.Auth;

public partial class NoAuthPage : Page
{
    public NoAuthPage()
    {
        InitializeComponent();
        NoAuthView.DataContext = new NoAuthViewModel();
    }
}