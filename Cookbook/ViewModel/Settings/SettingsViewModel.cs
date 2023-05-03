using System.Collections.Generic;
using System.Diagnostics;
using Cookbook.Command;
using Cookbook.Settings;
using Cookbook.UI.Theme;

namespace Cookbook.ViewModel.Settings;

public class SettingsViewModel : ViewModelBase
{
    public List<Theme> Themes => UI.Theme.Themes.SystemThemes;

    private string _selectedTheme = string.Empty;
    public AppSettings? AppSettings { get; set; } = App.Settings;

    public string SelectedTheme
    {
        get => _selectedTheme;
        set
        {
            if (value == _selectedTheme) return;
            _selectedTheme = value;
            OnPropertyChanged();
        }
    }

    public CommandHandler OpenGitHubCommand =>
        new CommandHandler(OpenGitHub);

    private async void OpenGitHub()
    {
        if (AppSettings?.Github != null)
            Process.Start(new ProcessStartInfo() {FileName = AppSettings.Github, UseShellExecute = true});
    }
}