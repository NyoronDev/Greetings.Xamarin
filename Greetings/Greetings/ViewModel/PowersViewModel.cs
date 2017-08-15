using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Greetings.ViewModel
{
    public class PowersViewModel : ViewModelBase
    {
        private double _exponent;
        private double _power;

        public PowersViewModel(double baseValue)
        {
            // Initialize properties.
            BaseValue = baseValue;
            Exponent = 0;

            // Initialize ICommand properties.
            IncreaseExponentCommand = new Command(ExecuteIncreaseExponent);
            DecreaseExponentCommand = new Command(ExecuteDecreaseExponent);

            //// You can use the lambda functions
            // IncreaseExponentCommand = new Command(() => { Exponent += 1; });
            // DecreaseExponentCommand = new Command(() => { Exponent -= 1; });
        }

        public ICommand IncreaseExponentCommand { get; private set; }
        public ICommand DecreaseExponentCommand { get; private set; }

        public double BaseValue { private set; get; }

        public double Exponent
        {
            get
            {
                return _exponent;
            }
            private set
            {
                if (SetProperty(ref _exponent, value))
                {
                    Power = Math.Pow(BaseValue, _exponent);
                }
            }
        }

        public double Power
        {
            get
            {
                return _power;
            }
            private set
            {
                SetProperty(ref _power, value);
            }
        }

        private void ExecuteIncreaseExponent()
        {
            Exponent += 1;
        }

        private void ExecuteDecreaseExponent()
        {
            Exponent -= 1;
        }
    }
}
