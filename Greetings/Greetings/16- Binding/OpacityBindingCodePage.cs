using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Greetings
{
	public class OpacityBindingCodePage : ContentPage
	{
        public OpacityBindingCodePage()
        {
            var label = new Label
            {
                Text = "Opacity Binding Demo",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };

            var slider = new Slider
            {
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Set the binding context: target is Label; source is Slider.
            label.BindingContext = slider;

            // Bind the properties: target is Opacity; source is Value.
            label.SetBinding(OpacityProperty, "Value");

            // Construct the page.
            Padding = new Thickness(10, 0);
            Content = new StackLayout
            {
                Children = { label, slider }
            };
        }
	}
}