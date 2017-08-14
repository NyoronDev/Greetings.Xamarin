using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Greetings
{
    public class BindingSourceCodePage : ContentPage
    {
        public BindingSourceCodePage()
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

            // Define Binding object with source object and property.
            var binding = new Binding
            {
                Source = slider,
                Path = "Value"
            };

            // Bind the Opacity property of the Label to the source.
            label.SetBinding(Label.OpacityProperty, binding);

            // Construct the page.
            Padding = new Thickness(10, 0);
            Content = new StackLayout
            {
                Children = { label, slider }
            };
        }
    }
}