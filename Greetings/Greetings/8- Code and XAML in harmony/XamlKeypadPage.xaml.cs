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
    public partial class XamlKeypadPage : ContentPage
    {
        App app = Application.Current as App;

        public XamlKeypadPage()
        {
            InitializeComponent();

            this.displayLabel.Text = this.app.DisplayLabelText;
            this.backspaceButton.IsEnabled = this.displayLabel.Text != null && this.displayLabel.Text.Length > 0;
        }

        private void OnBakspaceButtonClicked(object sender, EventArgs e)
        {
            var text = this.displayLabel.Text;
            this.displayLabel.Text = text.Substring(0, text.Length - 1);
            this.backspaceButton.IsEnabled = this.displayLabel.Text.Length > 0;

            this.app.DisplayLabelText = this.displayLabel.Text;
        }

        private void OnDigitButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            this.displayLabel.Text += (string)button.StyleId;
            this.backspaceButton.IsEnabled = true;

            this.app.DisplayLabelText = displayLabel.Text;
        }
    }
}