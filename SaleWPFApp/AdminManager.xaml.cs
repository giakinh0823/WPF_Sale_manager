using DataAccess.Repository;
using System.Windows;
using System.Windows.Input;

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
