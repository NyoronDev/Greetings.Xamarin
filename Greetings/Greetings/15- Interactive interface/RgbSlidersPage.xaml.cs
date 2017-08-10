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
    public partial class RgbSlidersPage : ContentPage
    {
        public RgbSlidersPage()
        {
            InitializeComponent();

            this.redSlider.Value = 128;
            this.greenSlider.Value = 128;
            this.blueSlider.Value = 128;
        }

        public void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender == this.redSlider)
            {
                this.redLabel.Text = $"Red = {(int)redSlider.Value:X2}";
            }
            else if (sender == this.greenSlider)
            {
                this.greenLabel.Text = $"Green = {(int)greenSlider.Value:X2}";
            }
            else if (sender == this.blueSlider)
            {
                this.blueLabel.Text = $"Blue = {(int)blueSlider.Value:X2}";
            }

            this.boxView.Color = Color.FromRgb((int)redSlider.Value,
                                               (int)greenSlider.Value,
                                               (int)blueSlider.Value);
        }
    }
}