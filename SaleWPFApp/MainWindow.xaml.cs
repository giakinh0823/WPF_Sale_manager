using BusinessObject.Model;
using DataAccess.Repository;
using Microsoft.Extensions.Configuration;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IProductRepository productRepository;
        private readonly IMemberRepository memberRepository;
        private readonly IOrderRepository orderRepository;
        public MainWindow(IProductRepository _productRepository, IMemberRepository _memberRepository, IOrderRepository _orderRepository)
        {
            InitializeComponent();
            this.productRepository = _productRepository;
            this.memberRepository = _memberRepository;
            this.orderRepository = _orderRepository;
        }

        public void resetFormLogin()
        {
            txtBoxUsername.Text = null;
            pwdBoxPassword.Password = null;
        }

        private void Btn_login(object sender, RoutedEventArgs e)
        {
            string username = txtBoxUsername.Text.ToString();
            string password = pwdBoxPassword.Password.ToString();
            var account = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("account");
            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
            {
                if (username.Equals(account["username"]) && password.Equals(account["password"]))
                {
                    Session.Username = username;
                    this.Hide();
                    AdminManager adminManager = new AdminManager(this, productRepository, memberRepository, orderRepository);
                    adminManager.Show();
                    resetFormLogin();
                }
                else if (memberRepository.FindByEmailAndPassword(username, password) != null)
                {
                    Session.Username = username;
                    this.Hide();
                    Home home = new Home(this, productRepository, orderRepository, memberRepository);
                    home.Show();
                    resetFormLogin();
                } 
                else
                {
                    MessageBox.Show("Please enter username and password");
                }
            } 
            else
            {
                MessageBox.Show("Please enter username and password");
            }
        }
    }
}
