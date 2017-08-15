using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Greetings.Toolkit
{
    public class NamedColorGroup : List<NamedColor>
    {
        // Instance members.
        private NamedColorGroup(string title, string shortName, Color colorShade)
        {
            this.Title = title;
            this.ShortName = shortName;
            this.ColorShade = colorShade;
        }

        public string Title { get; private set; }
        public string ShortName { get; private set; }
        public Color ColorShade { get; private set; }

        // Static members.
        static NamedColorGroup()
        {
            // Create all the groups.
            var groups = new List<NamedColorGroup>
            {
                new NamedColorGroup("Grays", "Gry", new Color(0.75, 0.75, 0.75)),
                new NamedColorGroup("Reds", "Red", new Color(1, 0.75, 0.75)),
                new NamedColorGroup("Yellows", "Yel", new Color(1, 1, 0.75)),
                new NamedColorGroup("Greens", "Grn", new Color(0.75, 1, 1)),
                new NamedColorGroup("Blues", "Blue", new Color(0.75, 0.75, 1))
            };

            foreach (var namedColor in NamedColor.All)
            {
                var color = namedColor.Color;
                var index = 0;

                if (color.Saturation != 0)
                {
                    index = 1 + (int)((12 * color.Hue + 1) / 2) % 6;
                }

                groups[index].Add(namedColor);
            }

            foreach (NamedColorGroup group in groups)
            {
                group.TrimExcess();
            }

            All = groups;
        }

        public static IList<NamedColorGroup> All { get; private set; }
    }
}
