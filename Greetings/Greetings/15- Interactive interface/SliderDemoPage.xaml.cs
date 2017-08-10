using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Greetings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SliderDemoPage : ContentPage
    {
        public SliderDemoPage()
        {
            InitializeComponent();
        }

        public void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (this.label != null)
            {
                // First way.
                this.label.Text = $"Slider = {e.NewValue}";

                // Second way.
                var slider = (Slider)sender;
                this.label.Text = $"Slider = {slider.Value}";
            }
        }
    }
}