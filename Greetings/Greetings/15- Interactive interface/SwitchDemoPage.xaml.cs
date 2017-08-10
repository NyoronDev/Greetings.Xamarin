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
    public partial class SwitchDemoPage : ContentPage
    {
        public SwitchDemoPage()
        {
            InitializeComponent();
        }

        public void OnItalicSwitchToggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                this.label.FontAttributes |= FontAttributes.Italic;
            }
            else
            {
                this.label.FontAttributes &= ~FontAttributes.Bold;
            }
        }

        public void OnBoldSwitchToggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                this.label.FontAttributes |= FontAttributes.Bold;
            }
            else
            {
                this.label.FontAttributes &= ~FontAttributes.Bold;
            }
        }
    }
}