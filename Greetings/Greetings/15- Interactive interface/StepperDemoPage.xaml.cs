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
    public partial class StepperDemoPage : ContentPage
    {
        public StepperDemoPage()
        {
            InitializeComponent();

            // Initialize display.
            this.OnStepperValueChanged(this.stepper, null);
        }

        private void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            var stepper = (Stepper)sender;
            this.button.BorderWidth = stepper.Value;
            this.label.Text = stepper.Value.ToString("F0");
        }
    }
}