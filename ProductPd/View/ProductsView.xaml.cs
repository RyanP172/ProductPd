using ProductPd.Data;
using ProductPd.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductPd.View
{

    public partial class ProductsView : UserControl
    {
        private ProductsViewModel _viewModel;

        public ProductsView()
        {
            InitializeComponent();
            _viewModel = new ProductsViewModel(new ProductImported());
            DataContext = _viewModel;
            Loaded += ProductsView_Loaded;
        }

        private void ProductsView_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.LoadData();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {

        }



        private void ButtonAddToTrolley_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddToTrolley();
            btnDeleteOrder.Background = Brushes.LightBlue;
        }

        private void ButtonDeleteSelectedProduct_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.RemoveSelectedProduct();
            btnSaveOrder.Background = Brushes.LightBlue;
            btnDeleteOrder.Background = Brushes.Yellow;
        }

        private void ButtonSaveOrder_Click(object sender, RoutedEventArgs e)
        {

            btnSaveOrder.Background = Brushes.Red;
            _viewModel.IsProductsOrdered = true;
        }

        private void ButtonEmptyTrolley_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.EmptyTrolley();
            btnSaveOrder.Background = Brushes.LightBlue;
            Total.Text = "0";
        }

        private void ButtonPrintReceipt_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.PrintReceipt();
            if (_viewModel.IsProductsOrdered)
            {
                Total.Text = _viewModel.Total.ToString();
            }


        }
    }
}
