using ProductPd.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPd.ViewModel
{
    /// <summary>
    /// This ViewModel is for a single product
    /// To implement SaleLineItem
    /// </summary>
    public class ProductItemViewModel : ViewModelBase
    {
        private Product _model;

        public ProductItemViewModel(Product model)
        {
            this._model = model;
        }

        public int Id => _model.Id;//make Id readonly


        /// <summary>
        /// Wrap the property of the model to raise 
        /// PropertyChanged event
        /// </summary>
        public string? Name
        {
            get => _model.Name;
            set
            {
                _model.Name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }

        public string? PriceDisplay
        {
            get => _model.PriceDisplay;
            set
            {
                _model.PriceDisplay = value;
                NotifyPropertyChanged(nameof(PriceDisplay));
            }
        }

        public double PriceAmount
        {
            get => _model.PriceAmount;
            set
            {
                _model.PriceAmount = value;
                NotifyPropertyChanged(nameof(PriceAmount));
            }
        }

        public int Qty
        {
            get => _model.Qty;
            set
            {
                _model.Qty = value;
                NotifyPropertyChanged(nameof(Qty));
            }
        }

        public double PriceTotal
        {
            get
            {
                return _model.PriceTotal= PriceAmount * Qty;
            }


        }

    }
}
