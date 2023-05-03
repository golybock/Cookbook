using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Cookbook.Settings;
using ModernWpf;

namespace Cookbook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static AppSettings? Settings =>
            SettingsManager.AppSettings;
        
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            SettingsManager.CreateAppSettingsIfNotExists();
            SetTheme();
        }

        private void SetTheme()
        {
            var selectedTheme = Settings?.Theme;

            if (selectedTheme == null)
                return;

            if(selectedTheme.Name == UI.Theme.Themes.NightTheme.Name)
                ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark;
            
            if(selectedTheme.Name == UI.Theme.Themes.DayTheme.Name)
                ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;

            // default
            if (selectedTheme.Name == UI.Theme.Themes.Default.Name)
                ThemeManager.Current.ApplicationTheme = null;

        }
    }
}