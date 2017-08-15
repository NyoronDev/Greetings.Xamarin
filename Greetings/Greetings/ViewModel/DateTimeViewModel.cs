using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Greetings.ViewModel
{
    public class DateTimeViewModel : INotifyPropertyChanged
    {
        private DateTime _dateTime = DateTime.Now;

        public event PropertyChangedEventHandler PropertyChanged;

        public DateTimeViewModel()
        {
            Device.StartTimer(TimeSpan.FromMilliseconds(15), OnTimerTick);
        }

        public DateTime DateTime
        {
            get
            {
                return this._dateTime;
            }

            private set
            {
                if (this._dateTime != value)
                {
                    this._dateTime = value;

                    // Fire the event. (Using a variable to prevent the multithread environment)
                    var handler = this.PropertyChanged;
                    handler?.Invoke(this, new PropertyChangedEventArgs("DateTime"));
                }
            }
        }

        private bool OnTimerTick()
        {
            DateTime = DateTime.Now;
            return true;
        }
    }
}
