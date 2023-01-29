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
        private Product? product;

        public AdminProductCreate(AdminProduct _adminProduct, Product? product,  IProductRepository _productRepository)
        {
            InitializeComponent();
            this.productRepository = _productRepository;
            this.adminProduct = _adminProduct;
            this.product = product;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(product != null)
            {
                txtBoxName.Text = product.ProductName;
                txtBoxCategory.Text = product.CategoryId.ToString();
                txtBoxUnitPrice.Text = product.UnitPrice.ToString();
                txtBoxWeight.Text = product.Weight;
                txtBoxUnitInStock.Text = product.UnitsInStock.ToString();
                txtBoxId.Text = product.ProductId.ToString();
                txtBoxId.Visibility= Visibility.Visible;
                labelId.Visibility = Visibility.Visible;
                btn.Content = "Update";
                this.Height = 550;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = txtBoxName.Text;
            int categoryId = int.Parse(txtBoxCategory.Text);
            string weight = txtBoxWeight.Text;
            decimal unitPrice = decimal.Parse(txtBoxUnitPrice.Text);
            int unitsInStock = int.Parse(txtBoxUnitInStock.Text);

            Product? p = null;
            if (product != null) {
                p = product;
            } 
            else
            {
                p = new Product();
            }
            p.ProductName = name;
            p.CategoryId = categoryId;
            p.Weight = weight;
            p.UnitPrice = unitPrice;
            p.UnitsInStock = unitsInStock;
            if (product != null)
            {
                productRepository.Update(p);
            } else
            {
                productRepository.Add(p);
            }
            this.Close();
            adminProduct.RefreshListView();
        }
    }
}
