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
	public partial class SetTimerPage : ContentPage
	{
        private DateTime _triggerTime;

		public SetTimerPage ()
		{
			InitializeComponent ();
            Device.StartTimer(TimeSpan.FromSeconds(1), this.OnTimerTick);
		}

        private void OnTimePickerPropertyChanged(object sender, PropertyChangingEventArgs args)
        {
            if (args.PropertyName == "Time")
            {
                this.SetTriggerTime();
            }
        }

        private void OnSwitchToggled(object sender, EventArgs args)
        {
            this.SetTriggerTime();
        }

        private bool OnTimerTick()
        {
            if (@switch.IsToggled && DateTime.Now >= this._triggerTime)
            {
                @switch.IsToggled = false;
                this.DisplayAlert("Time Alert", "The '" + entry.Text + "' timer has elapsed", "OK");
            }

            return true;
        }

        private void SetTriggerTime()
        {
            if (@switch.IsToggled)
            {
                this._triggerTime = DateTime.Today + this.timePicker.Time;

                if (this._triggerTime < DateTime.Now)
                {
                    this._triggerTime += TimeSpan.FromDays(1);
                }
            }
        }
    }
}