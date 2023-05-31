using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using Cookbook.Command;
using Cookbook.Settings;
using Cookbook.UI.Theme;
using ModernWpf;

namespace Cookbook.ViewModel.Settings;

public class SettingsViewModel : ViewModelBase
{
    public SettingsViewModel()
    {
        SelectedTheme = AppSettings?.Theme;
    }

    public List<Theme> Themes => UI.Theme.Themes.SystemThemes;

    private Theme? _selectedTheme;
    public AppSettings? AppSettings { get; set; } = App.Settings;

    public Theme? SelectedTheme
    {
        get => _selectedTheme;
        set
        {
            if (value == _selectedTheme) return;
            _selectedTheme = value;
            OnPropertyChanged();

            if (SelectedTheme != null)
            {
                if (SelectedTheme.Name == UI.Theme.Themes.NightTheme.Name)
                    ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark;

                if (SelectedTheme.Name == UI.Theme.Themes.DayTheme.Name)
                    ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;

                // default
                if (SelectedTheme.Name == UI.Theme.Themes.Default.Name)
                    ThemeManager.Current.ApplicationTheme = null;
            }

            // save settings
            if (AppSettings != null)
            {
                AppSettings.Theme = value;
                SettingsManager.SaveSettings(AppSettings);
            }
        }
    }

    public CommandHandler OpenGitHubCommand => new(OpenGitHub);

    private void OpenGitHub()
    {
        if (AppSettings?.Github != null)
            Process.Start(
                new ProcessStartInfo
                {
                    FileName = AppSettings.Github,
                    UseShellExecute = true
                }
            );
    }
}