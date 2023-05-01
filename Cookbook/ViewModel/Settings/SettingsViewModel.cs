using Cookbook.Settings;

namespace Cookbook.ViewModel.Settings;

public class SettingsViewModel : ViewModelBase
{
    public AppSettings? AppSettings { get; set; } = App.Settings;
}