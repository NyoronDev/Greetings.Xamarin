using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Greetings.ViewModel
{
    public class ColorViewModel : INotifyPropertyChanged
    {
        private Color _color;
        public event PropertyChangedEventHandler PropertyChanged;

        public double Red
        {
            get
            {
                return Round(this._color.R);
            }
            set
            {
                if (this.Round(this._color.R) != value)
                {
                    this.Color = Color.FromRgba(value, _color.G, _color.B, _color.A);
                }
            }
        }

        public double Green
        {
            get
            {
                return Round(_color.G);
            }
            set
            {
                if (Round(_color.G) != value)
                {
                    Color = Color.FromRgba(_color.R, value, Color.B, Color.A);
                }
            }
        }

        public double Blue
        {
            get
            {
                return Round(_color.B);
            }
            set
            {
                if (Round(_color.B) != value)
                {
                    Color = Color.FromRgba(_color.R, _color.G, _color.B, value);
                }
            }
        }

        public double Alpha
        {
            get
            {
                return Round(_color.A);
            }
            set
            {
                if (Round(_color.A) != value)
                {
                    Color = Color.FromRgba(_color.R, _color.G, _color.B, value);
                }
            }
        }

        public double Hue
        {
            get
            {
                return Round(_color.Hue);
            }
            set
            {
                if (Round(_color.Hue) != value)
                {
                    Color = Color.FromHsla(value, _color.Saturation, _color.Luminosity, _color.A);
                }
            }
        }

        public double Saturation
        {
            get
            {
                return Round(_color.Saturation);
            }
            set
            {
                if (Round(_color.Saturation) != value)
                {
                    Color = Color.FromHsla(_color.Hue, value, _color.Luminosity, _color.A);
                }
            }
        }

        public double Luminosity
        {
            get
            {
                return Round(_color.Luminosity);
            }
            set
            {
                if (Round(_color.Luminosity) != value)
                {
                    Color = Color.FromHsla(_color.Hue, _color.Saturation, value, _color.A);
                }
            }
        }

        public Color Color
        {
            get
            {
                return this._color;
            }
            set
            {
                var oldColor = this._color;

                if (this._color != value)
                {
                    this._color = value;
                    this.OnPropertyChanged();
                }

                if (this._color.R != oldColor.R)
                {
                    this.OnPropertyChanged();
                }

                if (this._color.G != oldColor.G)
                {
                    this.OnPropertyChanged();
                }

                if (this._color.B != oldColor.B)
                {
                    this.OnPropertyChanged();
                }

                if (this._color.A != oldColor.A)
                {
                    this.OnPropertyChanged();
                }

                if (this._color.Hue != oldColor.Hue)
                {
                    this.OnPropertyChanged();
                }

                if (this._color.Saturation != oldColor.Saturation)
                {
                    this.OnPropertyChanged();
                }

                if (this._color.Luminosity != oldColor.Luminosity)
                {
                    this.OnPropertyChanged();
                }
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = this.PropertyChanged;

            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private double Round(double value)
        {
            return Device.OnPlatform(value, Math.Round(value, 3), value);
        }
    }
}
