using System.Collections.Generic;

namespace Cookbook.UI.Theme;

public class Themes
{
    public static List<Theme> SystemThemes => new List<Theme>()
    {
        new Theme() { Id = 0, Name = "Default" },
        new Theme() { Id = 1, Name = "Light" },
        new Theme() { Id = 2, Name = "Dark" }
    };
}