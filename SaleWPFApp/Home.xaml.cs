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
        private readonly MainWindow mainWindow;
        public Home(MainWindow _mainWindow, IProductRepository _productRepository, IOrderRepository _orderRepository)
        {
            InitializeComponent();
            Closing += Home_Closing;
            this.mainWindow = _mainWindow;
            this.productRepository = _productRepository;
            this.orderRepository = _orderRepository;
        }

        private void Home_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainWindow.Show();
        }
    }
}
