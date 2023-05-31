using System.Windows;
using Cookbook.Database;
using Cookbook.Settings;
using ModernWpf;

namespace Cookbook;

public partial class App
{
    public static AppSettings Settings =>
        SettingsManager.AppSettings;

    public static readonly CookbookDbContext Context = new CookbookDbContext();
        
    private void App_OnStartup(object sender, StartupEventArgs e)
    {
        SettingsManager.CreateAppSettingsIfNotExists();
        SetTheme();
    }

    private void SetTheme()
    {
        var selectedTheme = Settings.Theme;

        if(selectedTheme.Name == UI.Theme.Themes.NightTheme.Name)
            ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark;
            
        if(selectedTheme.Name == UI.Theme.Themes.DayTheme.Name)
            ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;

        // default
        if (selectedTheme.Name == UI.Theme.Themes.Default.Name)
            ThemeManager.Current.ApplicationTheme = null;
            
    }
}