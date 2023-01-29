using DataAccess.Repository;
using Microsoft.EntityFrameworkCore.Metadata;
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

namespace SaleWPFApp
{
    /// <summary>
    /// Interaction logic for AdminProduct.xaml
    /// </summary>
    public partial class AdminProduct : Page
    {
        private readonly IProductRepository productRepository;
        public AdminProduct(IProductRepository _productRepository)
        {
            InitializeComponent();
            this.productRepository = _productRepository;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = productRepository.List();
        }

        public void RefreshListView()
        {
            listView.ItemsSource = productRepository.List();
        }

        private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView? listView = sender as ListView;
            GridView? gridView = listView !=null ? listView.View as GridView : null;

            var width = listView !=null ? listView.ActualWidth - SystemParameters.VerticalScrollBarWidth : this.Width;

            var column1 = 0.1;
            var column2 = 0.2;
            var column3 = 0.1;
            var column4 = 0.1;
            var column5 = 0.1;
            var column6 = 0.2;

            if (gridView != null && width >= 0)
            {
                gridView.Columns[0].Width = width * column1;
                gridView.Columns[1].Width = width * column2;
                gridView.Columns[2].Width = width * column3;
                gridView.Columns[3].Width = width * column4;
                gridView.Columns[4].Width = width * column5;
                gridView.Columns[5].Width = width * column6;
            }
        }

        private void Button_OpenProductCreate(object sender, RoutedEventArgs e)
        {
            AdminProductCreate adminProductCreate = new AdminProductCreate(this, productRepository);
            adminProductCreate.Show();
        }

        private void Button_ReloadProduct(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = productRepository.List();
        }

        private void Button_DeleteProduct(object sender, RoutedEventArgs e)
        {

        }

        private void Button_EditProduct(object sender, RoutedEventArgs e)
        {

        }
    }
}
