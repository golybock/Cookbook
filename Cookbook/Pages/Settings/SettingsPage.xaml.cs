using System.Windows.Controls;
using Cookbook.ViewModel.Settings;
using Cookbook.Views.Settings;

namespace Cookbook.Pages.Settings;

public partial class SettingsPage : Page
{
    public SettingsPage()
    {
        InitializeComponent();
        SettingsView.DataContext = new SettingsViewModel();
    }
}