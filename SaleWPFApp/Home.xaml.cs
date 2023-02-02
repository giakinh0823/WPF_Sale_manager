using BusinessObject.Model;
using DataAccess.Model;
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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private readonly IProductRepository productRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IMemberRepository memberRepository;
        private readonly MainWindow mainWindow;
        public Home(MainWindow _mainWindow, IProductRepository _productRepository, IOrderRepository _orderRepository, IMemberRepository _memberRepository)
        {
            InitializeComponent();
            Closing += Home_Closing;
            this.mainWindow = _mainWindow;
            this.productRepository = _productRepository;
            this.orderRepository = _orderRepository;
            this.memberRepository = _memberRepository;
            ListProduct.ItemsSource = productRepository.List();
            Session.carts = new List<OrderDetail>();
            UpdateCartQuantity();
        }

        private void Home_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainWindow.Show();
        }

        private void Button_Search(object sender, RoutedEventArgs e)
        {
            int? id = !String.IsNullOrEmpty(searchById.Text) ? int.Parse(searchById.Text) : null;
            string? name = searchByName.Text;
            decimal? unitPrice = !String.IsNullOrEmpty(searchByUnitPrice.Text) ? decimal.Parse(searchByUnitPrice.Text) : null;
            int? unitsInStock = !String.IsNullOrEmpty(searchByUnitsInStock.Text) ? int.Parse(searchByUnitsInStock.Text) : null;

            ProductFilter productFilter = new ProductFilter();
            productFilter.ProductId = id;
            productFilter.ProductName = name;
            productFilter.UnitPrice = unitPrice;
            productFilter.UnitsInStock = unitsInStock;

            ListProduct.ItemsSource = productRepository.FindAllBy(productFilter);
        }

        private void AddToCart(object sender, RoutedEventArgs e)
        {
            Button? button = (Button)sender;
            if (button != null)
            {
                var tag = button.Tag;
                if(!string.IsNullOrEmpty(tag.ToString()))
                {
                    int id = int.Parse(tag.ToString());
                    Product product = productRepository.FindById(id);
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.ProductId = product.ProductId;
                    orderDetail.UnitPrice = product.UnitPrice;
                    orderDetail.Quantity = 1;
                    orderDetail.Product = product;
                    orderDetail.Discount = Config.Discount;
                    if (Session.carts == null)
                    {
                        Session.carts = new List<OrderDetail> { orderDetail };
                    }
                    else
                    {
                        int index = Session.carts.FindIndex(cart => cart.ProductId == orderDetail.ProductId);
                        if(index == -1)
                        {
                            Session.carts.Add(orderDetail);
                        } else
                        {
                            Session.carts[index].Quantity++;
                        }
                    }
                }
            }
            UpdateCartQuantity();
        }

        private void Button_OpenOrder(object sender, RoutedEventArgs e)
        {
            CartWindown cartWindown = new CartWindown(this, orderRepository, memberRepository);
            cartWindown.Show();
        }

        public void UpdateCartQuantity()
        {
            CartCount.Text = Session.carts.Sum(product => product.Quantity).ToString();
        }

        private void Button_OpenMyOrder(object sender, RoutedEventArgs e)
        {
            MyOrderWindown myOrderWindown = new MyOrderWindown(orderRepository, memberRepository);
            myOrderWindown.Show();
        }
    }
}
