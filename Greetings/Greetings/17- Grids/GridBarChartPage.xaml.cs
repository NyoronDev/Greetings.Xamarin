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
    public partial class GridBarChartPage : ContentPage
    {
        private const int COUNT = 50;
        private Random random = new Random();

        // Arrays for Random Name Generator.
        private string[] vowels = { "a", "e", "i", "o", "u", "ai", "ei", "ie", "ou", "oo" };
        private string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r" };

        public GridBarChartPage()
        {
            InitializeComponent();

            var views = new List<View>();
            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += OnBoxViewTapped;

            // Create BoxView elements and add to List.
            for (var i = 0; i < COUNT; i++)
            {
                var boxView = new BoxView
                {
                    Color = Color.Accent,
                    HeightRequest = 300 * this.random.NextDouble(),
                    VerticalOptions = LayoutOptions.End,
                    StyleId = this.RandomNameGenerator()
                };

                boxView.GestureRecognizers.Add(tapGesture);
                views.Add(boxView);
            }

            // Add whole List of BoxView elements to Grid.
            this.grid.Children.AddHorizontal(views);

            // Start a timer at the frame rate.
            Device.StartTimer(TimeSpan.FromMilliseconds(15), OnTimerTick);
        }

        private string RandomNameGenerator()
        {
            var numPieces = 1 + 2 * this.random.Next(1, 4);
            var name = new StringBuilder();

            for (int i = 0; i < numPieces; i++)
            {
                name.Append(i % 2 == 0 ? this.consonants[random.Next(consonants.Length)] :
                                         this.vowels[random.Next(vowels.Length)]);
            }

            name[0] = Char.ToUpper(name[0]);
            return name.ToString();
        }

        // Set text to overlay Label and make it visible.
        private void OnBoxViewTapped(object sender, EventArgs args)
        {
            var boxView = (BoxView)sender;
            this.label.Text = String.Format("The individual known as {0} has a height of {1} centimeters.",
                boxView.StyleId, (int)boxView.HeightRequest);

            overlay.Opacity = 1;
        }

        // Decrease visibility of overlay.
        private bool OnTimerTick()
        {
            overlay.Opacity = Math.Max(0, overlay.Opacity - 0.0025);
            return true;
        }
    }
}