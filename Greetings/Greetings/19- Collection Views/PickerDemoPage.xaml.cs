using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Greetings
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PickerDemoPage : ContentPage
	{
		public PickerDemoPage ()
		{
			InitializeComponent ();
		}

        private void OnPickerSelectedIndexChanged(object sender, EventArgs args)
        {
            if (entry == null)
            {
                return;
            }

            var picker = (Picker)sender;
            var selectedIndex = picker.SelectedIndex;

            if (selectedIndex == -1)
            {
                return;
            }

            var selectedItem = picker.Items[selectedIndex];
            var propertyInfo = typeof(Keyboard).GetRuntimeProperty(selectedItem);
            entry.Keyboard = (Keyboard)propertyInfo.GetValue(null);
        }
	}
}