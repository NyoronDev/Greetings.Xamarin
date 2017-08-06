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
    public partial class TwoButtonsPage : ContentPage
    {
        public TwoButtonsPage()
        {
            InitializeComponent();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;

            if (button.Text.Equals("Add"))
            {
                this.loggerLayout.Children.Add(new Label
                {
                    Text = $"Button clicked at {DateTime.Now.ToString("T")}"
                });
            }
            else
            {
                this.loggerLayout.Children.RemoveAt(0);
            }

            this.removeButton.IsEnabled = this.loggerLayout.Children.Count > 0;
        }
    }
}