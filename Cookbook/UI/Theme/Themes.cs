using System.Collections.Generic;

namespace Cookbook.UI.Theme;

public class Themes
{
    public static Theme DayTheme => new() {Id = 1, Name = "Light"};
    public static Theme NightTheme => new() {Id = 2, Name = "Dark"};
    public static Theme Default => new() {Id = 0, Name = "Default"};

    public static List<Theme> SystemThemes => new()
    {
        DayTheme, NightTheme, Default
    };
}