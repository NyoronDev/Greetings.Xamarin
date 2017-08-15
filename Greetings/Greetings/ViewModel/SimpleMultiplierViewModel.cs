using System;
using System.ComponentModel;

namespace Greetings.ViewModel
{
    public class SimpleMultiplierViewModel : INotifyPropertyChanged
    {
        private double _multiplicand;
        private double _multiplier;
        private double _product;

        public event PropertyChangedEventHandler PropertyChanged;

        public double Multiplicand
        {
            get
            {
                return this._multiplicand;
            }
            set
            {
                if (this._multiplicand != value)
                {
                    this._multiplicand = value;
                    this.OnPropertyChanged("Multiplicand");
                    this.UpdateProduct();
                }
            }
        }

        public double Multiplier
        {
            get
            {
                return this._multiplier;
            }
            set
            {
                if (this._multiplier != value)
                {
                    this._multiplier = value;
                    this.OnPropertyChanged("Multiplier");
                    this.UpdateProduct();
                }
            }
        }

        public double Product
        {
            get
            {
                return this._product;
            }
            protected set
            {
                if (this._product != value)
                {
                    this._product = value;
                    this.OnPropertyChanged("Product");
                }
            }
        }

        private void UpdateProduct()
        {
            this.Product = this.Multiplicand * this.Multiplier;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
