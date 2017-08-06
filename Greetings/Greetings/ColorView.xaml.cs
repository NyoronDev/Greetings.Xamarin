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
    public partial class ColorView : ContentView
    {
        private string _colorName;
        ColorTypeConverter colorTypeConverter = new ColorTypeConverter();

        public ColorView()
        {
            InitializeComponent();
        }

        public string ColorName {
            get
            {
                return _colorName;
            }
            set
            {
                // Set the name.
                this._colorName = value;
                this.colorNameLabel.Text = value;

                // Get the actual Color and set the other views.
                var color = (Color)this.colorTypeConverter.ConvertFromInvariantString(this._colorName);
                this.boxView.Color = color;
                colorValueLabel.Text = string.Format("{0:X2}-{1:X2}-{2:X2}", (int)(255 * color.R),
                                                                             (int)(255 * color.G),
                                                                             (int)(255 * color.B));
            }
        }
    }
}