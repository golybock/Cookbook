using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Cookbook.Settings;

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
        }
    }
}