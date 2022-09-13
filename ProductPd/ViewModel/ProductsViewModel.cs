using ProductPd.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPd.ViewModel
{
    public class ProductsViewModel : ViewModelBase
    {
        private readonly IProductDataImported _productDataImported;
        private ProductItemViewModel? _selectedProduct;

        public ProductsViewModel(IProductDataImported productDataImported)
        {
            _productDataImported = productDataImported;
        }
        public ObservableCollection<ProductItemViewModel> Products { get; } = new();
        public ObservableCollection<ProductItemViewModel> SelectedProducts { get; } = new();
        public ObservableCollection<ProductItemViewModel> OrderedProducts { get; } = new();
        public string Total
        {
            get
            {
                double total = 0;
                foreach (var p in SelectedProducts)
                {
                    total += p.PriceTotal;
                }
                return string.Format("${0:C}", total.ToString());
            }

        }

        public bool IsProductSelected => SelectedProduct != null;
        public bool IsProductsOrdered { get; set; }

        public ProductItemViewModel? SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                NotifyPropertyChanged(nameof(SelectedProduct));
                NotifyPropertyChanged(nameof(IsProductSelected));
            }
        }



        public void LoadData()
        {
            var products = _productDataImported.ImportProducts();

            if (Products.Any())
            {
                return;//check if data is not load yet
            }

            if (products != null)
            {
                foreach (var p in products)
                {
                    Products.Add(new ProductItemViewModel(p));
                }
            }

        }
        public void AddToTrolley()
        {
            var product = SelectedProduct;


            if (product != null)
            {
                foreach (var p in SelectedProducts)
                {
                    if (product == p)
                    {
                        return;
                    }
                }

                SelectedProducts.Add(product);
            }

        }
        public void RemoveSelectedProduct()
        {
            var product = SelectedProduct;
            if (product != null)
            {
                SelectedProducts.Remove(product);
            }
        }
        public void PrintReceipt()
        {

            if (IsProductsOrdered)
            {
                foreach (var p in SelectedProducts)
                {
                    if (p != null)
                    {
                        if (p.Qty != 0)
                        {
                            foreach (var orderProduct in OrderedProducts)
                                if (orderProduct == p)
                                {
                                    return;
                                }
                            OrderedProducts.Add(p);
                        }

                    }
                }

            }

        }

        public void EmptyTrolley()
        {
            OrderedProducts.Clear();
            IsProductsOrdered = false;
        }










    }
}
