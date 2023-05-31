using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Cookbook.UI.Theme;

namespace Cookbook.Settings;

public class SettingsManager
{
    public SettingsManager()
    {
        CreateAppSettingsIfNotExists();
    }

    private static string _appSettings =>
        "appsettings.json";

    public static AppSettings AppSettings =>
        ReadAppSettings();

    private static bool SettingsExists()
    {
        return File.Exists(_appSettings);
    }

    public static void SaveSettings(AppSettings appSettings)
    {
        WriteAppSettings(appSettings);
    }

    private static AppSettings DefaultSettings => new()
    {
        Theme = Themes.Default,
        Github = "https://github.com/golybock",
        Version = "1.0"
    };

    private static AppSettings ReadAppSettings()
    {
        using var sr = new StreamReader(_appSettings);

        var json = sr.ReadToEnd();

        return JsonSerializer.Deserialize<AppSettings>(json) ?? DefaultSettings;
    }

    private static void WriteAppSettings(AppSettings appSettings)
    {
        using var sw = new StreamWriter(_appSettings);

        var options = new JsonSerializerOptions
        {
            Encoder =
                JavaScriptEncoder.Create(
                    UnicodeRanges.BasicLatin,
                    UnicodeRanges.Cyrillic
                ),
            WriteIndented = true
        };

        var json = JsonSerializer.Serialize(appSettings, options);

        sw.WriteAsync(json);
    }

    public static void CreateAppSettingsIfNotExists()
    {
        if (!SettingsExists())
            SaveSettings(DefaultSettings);
    }
}