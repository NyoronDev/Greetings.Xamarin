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
    public partial class SimpleOverlayPage : ContentPage
    {
        public SimpleOverlayPage()
        {
            InitializeComponent();
        }

        public void OnButtonClicked(Object sender, EventArgs e)
        {
            // Show overlay with ProgressBar.
            this.overlay.IsVisible = true;

            var duration = TimeSpan.FromSeconds(5);
            var startTime = DateTime.Now;

            // Start timer.
            Device.StartTimer(TimeSpan.FromSeconds(0.1), () =>
            {
                var progress = (DateTime.Now - startTime).TotalMilliseconds / duration.TotalMilliseconds;
                this.progressBar.Progress = progress;
                var continueTimer = progress < 1;

                if (!continueTimer)
                {
                    // Hide overlay.
                    this.overlay.IsVisible = false;
                }

                return continueTimer;
            });
        }
    }
}