using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace Greetings.Toolkit
{
    public class NamedColor
    {
        // Instance members.
        private NamedColor()
        {

        }

        public string Name { get; private set; }
        public string FriendlyName { get; private set; }
        public Color Color { get; private set; }
        public string RgbDisplay { get; private set; }

        // Static members.
        static NamedColor()
        {
            var all = new List<NamedColor>();
            var stringBuilder = new StringBuilder();

            // Loop throungh the public static fields of type Color.
            foreach (FieldInfo fieldInfo in typeof(NamedColor).GetRuntimeFields())
            {
                if (fieldInfo.IsPublic && fieldInfo.IsStatic && fieldInfo.FieldType == typeof(Color))
                {
                    // Convert the name to a friendly name.
                    var name = fieldInfo.Name;
                    stringBuilder.Clear();
                    var index = 0;

                    foreach (var ch in name)
                    {
                        if (index != 0 && Char.IsUpper(ch))
                        {
                            stringBuilder.Append(' ');
                        }

                        stringBuilder.Append(ch);
                        index++;
                    }

                    var color = ((Color)fieldInfo.GetValue(null));

                    var namedColor = new NamedColor
                    {
                        Name = name,
                        FriendlyName = stringBuilder.ToString(),
                        Color = color,
                        RgbDisplay = String.Format("{0:X2}-{1:X2}-{2:X2}", (int)(255 * color.R), (int)(255 * color.G), (int)(255 * color.B))
                    };

                    // Add it to the collection.
                    all.Add(namedColor);
                }
            }

            all.TrimExcess();
            All = all;
        }

        public static IList<NamedColor> All { get; private set; }

        public static readonly Color AliceBlue = Color.FromRgb(240, 248, 255);
        public static readonly Color AntiqueWhite = Color.FromRgb(250, 235, 215);
        public static readonly Color Aqua = Color.FromRgb(0, 255, 255);
        public static readonly Color Yellow = Color.FromRgb(255, 255, 0);
        public static readonly Color YellowGreen = Color.FromRgb(154, 205, 50);

        public override string ToString()
        {
            return FriendlyName;
        }
    }
}
