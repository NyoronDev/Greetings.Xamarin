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
    public partial class XamlClockPage : ContentPage
    {
        public XamlClockPage()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(1), this.OnTimerTick);
        }

        private bool OnTimerTick()
        {
            var dateTime = DateTime.Now;
            timeLabel.Text = dateTime.ToString("T");
            dateLabel.Text = dateTime.ToString("D");

            return true;
        }
    }
}