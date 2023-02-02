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
    /// Interaction logic for CartWindown.xaml
    /// </summary>
    public partial class CartWindown : Window
    {
        private readonly Home home;
        private readonly IOrderRepository orderRepository;
        private readonly IMemberRepository memberRepository;
        public CartWindown(Home home, IOrderRepository _orderRepository, IMemberRepository _memberRepository)
        {
            InitializeComponent();
            this.orderRepository = _orderRepository;
            this.memberRepository = _memberRepository;
            this.home = home;
            if(Session.carts ==null)
            {
                Session.carts = new List<OrderDetail>();
            }
            updateCarts();
        }

        private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView? listView = sender as ListView;
            GridView? gridView = listView != null ? listView.View as GridView : null;

            var width = listView != null ? listView.ActualWidth - SystemParameters.VerticalScrollBarWidth : this.Width;

            var column1 = 0.2;
            var column2 = 0.2;
            var column3 = 0.2;
            var column4 = 0.1;
            var column5 = 0.2;
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

        private void updateCarts()
        {
            listView.ItemsSource = Session.carts.ToList();
            TxtBoxTotalPrice.Text = Session.carts.Sum(cart => (cart.Quantity * cart.UnitPrice) - (cart.Quantity * cart.UnitPrice * (decimal)cart.Discount)).ToString();
            home.UpdateCartQuantity();
        }

        private void Button_Plus(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            if (button != null)
            {
                var tag = button.Tag;
                if (!string.IsNullOrEmpty(tag.ToString()))
                {
                    int id = int.Parse(tag.ToString());
                    int index = Session.carts.FindIndex(cart => cart.ProductId == id);
                    if(index != -1)
                    {
                        Session.carts[index].Quantity += 1;
                        updateCarts();
                    }
                }
            }
        }

        private void Button_Minus(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            if (button != null)
            {
                var tag = button.Tag;
                if (!string.IsNullOrEmpty(tag.ToString()))
                {
                    int id = int.Parse(tag.ToString());
                    int index = Session.carts.FindIndex(cart => cart.ProductId == id);
                    if (index != -1)
                    {
                        Session.carts[index].Quantity -= 1;
                        if(Session.carts[index].Quantity <= 0)
                        {
                            Session.carts.RemoveAt(index);
                        }
                        updateCarts();
                    }
                }
            }
        }

        private void Button_Remove(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            if (button != null)
            {
                var tag = button.Tag;
                if (!string.IsNullOrEmpty(tag.ToString()))
                {
                    int id = int.Parse(tag.ToString());
                    int index = Session.carts.FindIndex(cart => cart.ProductId == id);
                    if (index != -1)
                    {
                        Session.carts.RemoveAt(index);
                        updateCarts();
                    }
                }
            }
        }

        private void Button_Checkout(object sender, RoutedEventArgs e)
        {
            DateTime? requiredDate = RequiredDate.SelectedDate == null ? null : RequiredDate.SelectedDate.Value.Date;
            DateTime? shippedDate = ShippedDate.SelectedDate == null ? null : ShippedDate.SelectedDate.Value.Date;
            Member member = memberRepository.FindByEmail(Session.Username);
            if(member == null)
            {
                MessageBox.Show("Not found user");
                this.Close();
                home.Close();
                return;
            }
            List<OrderDetail> orderDetails = Session.carts.Select(cart =>
            {
                cart.Product = null;
                return cart;
            }).ToList();
            Order order = new Order();
            order.OrderDate = DateTime.Now;
            order.OrderDetails = orderDetails;
            order.MemberId = member.MemberId;
            order.Freight = Config.Freight;
            order.RequiredDate = requiredDate;
            order.ShippedDate = shippedDate;
            orderRepository.Add(order);
            Session.carts = new List<OrderDetail>();
            updateCarts();
        }
    }
}
