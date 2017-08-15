using Greetings.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Greetings
{
	public class TextCellListCodePage : ContentPage
	{
		public TextCellListCodePage ()
		{
            // Define the DataTemplate.
            var dataTemplate = new DataTemplate(typeof(TextCell));
            dataTemplate.SetBinding(TextCell.TextProperty, "FriendlyName");
            dataTemplate.SetBinding(TextCell.DetailProperty, new Binding(path: "RgbDisplay", stringFormat: "RGB = {0}"));

            // Build the page.
            Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 0);

            Content = new ListView
            {
                ItemsSource = NamedColor.All,
                ItemTemplate = dataTemplate
            };
		}
	}
}