﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Greetings.Toolkit
{
    public class ColorToContrastColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ColorToContrastColor((Color)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ColorToContrastColor((Color)value);
        }

        private Color ColorToContrastColor(Color color)
        {
            // Standard luminance calculation.
            var luminance = 0.30 * color.R + 0.59 * color.G + 0.11 * color.B;
            return luminance > 0.5 ? Color.Black : Color.White;
        }
    }
}
