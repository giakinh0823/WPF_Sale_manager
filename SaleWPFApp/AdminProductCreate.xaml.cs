using BusinessObject.Model;
using DataAccess.Repository;
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
using System.Windows.Shapes;

namespace SaleWPFApp
{
    /// <summary>
    /// Interaction logic for AdminProductCreate.xaml
    /// </summary>
    public partial class AdminProductCreate : Window
    {
        private readonly IProductRepository productRepository;
        private readonly AdminProduct adminProduct;

        public AdminProductCreate(AdminProduct _adminProduct, IProductRepository _productRepository)
        {
            InitializeComponent();
            this.productRepository = _productRepository;
            this.adminProduct = _adminProduct;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = txtBoxName.Text;
            int categoryId = int.Parse(txtBoxCategory.Text);
            string weight = txtBoxWeight.Text;
            decimal unitPrice = decimal.Parse(txtBoxUnitPrice.Text);
            int unitsInStock = int.Parse(txtBoxUnitInStock.Text);

            Product product= new Product();
            product.ProductName = name;
            product.CategoryId = categoryId;
            product.Weight = weight;
            product.UnitPrice = unitPrice;
            product.UnitsInStock = unitsInStock;
            productRepository.Add(product);
            this.Close();
            adminProduct.RefreshListView();
        }
    }
}
