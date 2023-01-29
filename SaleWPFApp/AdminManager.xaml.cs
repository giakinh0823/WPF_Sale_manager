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
    /// Interaction logic for AdminManager.xaml
    /// </summary>
    public partial class AdminManager : Window
    {
        private readonly IProductRepository productRepository;
        private readonly IMemberRepository memberRepository;
        private readonly IOrderRepository orderRepository;
        public AdminManager(IProductRepository _productRepository, IMemberRepository _memberRepository, IOrderRepository _orderRepository)
        {
            InitializeComponent();
            this.productRepository = _productRepository;
            this.memberRepository = _memberRepository;
            this.orderRepository = _orderRepository;
        }

        private void Goto_AdminProduct(object sender, MouseButtonEventArgs e)
        {
            logo.Visibility = Visibility.Hidden;
            AdminProduct adminProduct = new AdminProduct(productRepository);
            frameMain.Content = adminProduct;
        }


        private void Goto_AdminCategory(object sender, MouseButtonEventArgs e)
        {
            logo.Visibility = Visibility.Hidden;
            AdminCategory adminCategory = new AdminCategory();
            frameMain.Content = adminCategory;
        }

        private void Goto_AdminMember(object sender, MouseButtonEventArgs e)
        {
            logo.Visibility = Visibility.Hidden;
            AdminMember adminMember = new AdminMember(memberRepository);
            frameMain.Content = adminMember;
        }
        private void Goto_AdminOrder(object sender, MouseButtonEventArgs e)
        {
            logo.Visibility = Visibility.Hidden;
            AdminOrder adminOrder = new AdminOrder();
            frameMain.Content = adminOrder;
        }
    }
}
