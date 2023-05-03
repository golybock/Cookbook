using System.Collections.Generic;

namespace Cookbook.UI.Theme;

public class Themes
{
    public static Theme DayTheme => new Theme() {Id = 1, Name = "Light"};
    public static Theme NightTheme => new Theme() {Id = 2, Name = "Dark"};
    public static Theme Default => new Theme() {Id = 0, Name = "Default"};

    public static List<Theme> SystemThemes => new List<Theme>()
    {
        DayTheme, NightTheme, Default
    };
}