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
    public partial class TextFadePage : ContentPage
    {
        public TextFadePage()
        {
            InitializeComponent();
        }

        public void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            AbsoluteLayout.SetLayoutBounds(this.label1,
                new Rectangle(e.NewValue, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            AbsoluteLayout.SetLayoutBounds(this.label2,
                new Rectangle(e.NewValue, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            this.label1.Opacity = 1 - e.NewValue;
            this.label2.Opacity = e.NewValue;
        }
    }
}