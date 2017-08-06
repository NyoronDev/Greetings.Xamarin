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
    public partial class MonkeyTapPage : ContentPage
    {
        // In msec.
        private const int SequenceTime = 750;
        protected const int FlashDuration = 250;

        // Somewhat dimmer.
        private const double OffLuminosity = 0.4;

        // Much brighter.
        private const double OnLuminosity = 0.75;

        private BoxView[] _boxViews;
        private Color[] _colors = { Color.Red, Color.Blue, Color.Yellow, Color.Green };
        private List<int> _sequence = new List<int>();

        private int _sequenceIndex;
        private bool _awaitingTaps;
        private bool _gameEnded;

        private Random _random = new Random();

        public MonkeyTapPage()
        {
            InitializeComponent();
            this._boxViews = new BoxView[] { this.boxview0, this.boxview1, this.boxview2, this.boxview3 };
            this.InitializeBoxViewColors();
        }

        private void InitializeBoxViewColors()
        {
            for (var index = 0; index < 4; index++)
            {
                this._boxViews[index].Color = this._colors[index].WithLuminosity(OffLuminosity);
            }
        }

        public void OnBoxViewTapped(object sender, EventArgs e)
        {
            if (this._gameEnded)
            {
                return;
            }

            if (!this._awaitingTaps)
            {
                this.EndGame();
                return;
            }

            var tappedBoxView = (BoxView)sender;
            var index = Array.IndexOf(this._boxViews, tappedBoxView);

            if (index != this._sequence[this._sequenceIndex])
            {
                this.EndGame();
                return;
            }

            this.FlashBoxView(index);

            this._sequenceIndex++;
            this._awaitingTaps = this._sequenceIndex < this._sequence.Count;

            if (!this._awaitingTaps)
            {
                this.StartSequence();
            }
        }

        public void OnStartGameButtonClicked(object sender, EventArgs e)
        {
            this._gameEnded = false;
            this.startGameButton.IsVisible = false;
            this.InitializeBoxViewColors();
            this._sequence.Clear();
            this.StartSequence();
        }

        protected virtual void FlashBoxView(int index)
        {
            this._boxViews[index].Color = this._colors[index].WithLuminosity(OnLuminosity);
            Device.StartTimer(TimeSpan.FromMilliseconds(FlashDuration), () =>
            {
                if (this._gameEnded)
                {
                    return false;
                }

                this._boxViews[index].Color = this._colors[index].WithLuminosity(OffLuminosity);
                return false;
            });
        }

        protected virtual void EndGame()
        {
            this._gameEnded = true;

            for (var index = 0; index < 4; index++)
            {
                this._boxViews[index].Color = Color.Gray;
            }

            this.startGameButton.Text = "Try again?";
            this.startGameButton.IsVisible = true;
        }

        private void StartSequence()
        {
            this._sequence.Add(this._random.Next(4));
            this._sequenceIndex = 0;
            Device.StartTimer(TimeSpan.FromMilliseconds(SequenceTime), this.OnTimerTick);
        }

        private bool OnTimerTick()
        {
            if (this._gameEnded)
            {
                return false;
            }

            this.FlashBoxView(this._sequence[this._sequenceIndex]);
            this._sequenceIndex++;
            this._awaitingTaps = this._sequenceIndex == this._sequence.Count;
            this._sequenceIndex = this._awaitingTaps ? 0 : this._sequenceIndex;

            return !this._awaitingTaps;
        }
    }
}