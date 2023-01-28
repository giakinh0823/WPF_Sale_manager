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
        public AdminManager()
        {
            InitializeComponent();
        }

        private void Goto_AdminProduct(object sender, MouseButtonEventArgs e)
        {
            headerWelcomeAdmin.Visibility = Visibility.Hidden;
            AdminProduct adminProduct = new AdminProduct();
            frameMain.Content = adminProduct;
        }

        private void Goto_AdminMember(object sender, MouseButtonEventArgs e)
        {
            headerWelcomeAdmin.Visibility = Visibility.Hidden;
            AdminMember adminMember = new AdminMember();
            frameMain.Content = adminMember;
        }
        private void Goto_AdminOrder(object sender, MouseButtonEventArgs e)
        {
            headerWelcomeAdmin.Visibility = Visibility.Hidden;
            AdminOrder adminOrder = new AdminOrder();
            frameMain.Content = adminOrder;
        }
    }
}
