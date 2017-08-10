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
	public partial class DaysBetweenDatesPage : ContentPage
	{
		public DaysBetweenDatesPage ()
		{
			InitializeComponent ();

            // Initialize.
            this.OnDateSelected(null, null);
		}

        private void OnDateSelected(object sender, DateChangedEventArgs args)
        {
            var days = (this.toDatePicker.Date - this.fromDatePicker.Date).Days;
            this.resultLabel.Text = string.Format("{0} day{1} between dates", days, days == 1 ? string.Empty : "s");
        }
    }
}