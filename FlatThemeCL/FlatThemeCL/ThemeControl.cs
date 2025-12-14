using System.Collections.Generic;

namespace FlatThemeCL
{
    public static class ThemeManager
    {
        public static List<ThemeControl> Controls { get; set; } = new List<ThemeControl>()
        {
            new ThemeControl()
            {
                Name = "btnStart",
                Text = "PLAY NOW",
                Width = 0,
                Height = 0,
            },
            new ThemeControl()
            {
                Name = "btnSettings",
                Text = "CONFIG",
                Width = 0,
                Height = 0,
            }
        };
    }
    public class ThemeControl
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
