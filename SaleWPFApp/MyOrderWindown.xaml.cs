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
    /// Interaction logic for MyOrderWindown.xaml
    /// </summary>
    public partial class MyOrderWindown : Window
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMemberRepository memberRepository;
        public MyOrderWindown(IOrderRepository _orderRepository, IMemberRepository _memberRepository)
        {
            InitializeComponent();
            this.orderRepository = _orderRepository;
            this.memberRepository = _memberRepository;
            Member member = memberRepository.FindByEmail(Session.Username);
            if (member == null)
            {
                MessageBox.Show("Not found user");
                this.Close();
                return;
            }
            listView.ItemsSource = orderRepository.FindByEmail(Session.Username).ToList().OrderByDescending(order => order.OrderDate).ToList();
        }

        private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView? listView = sender as ListView;
            GridView? gridView = listView != null ? listView.View as GridView : null;

            var width = listView != null ? listView.ActualWidth - SystemParameters.VerticalScrollBarWidth : this.Width;

            var column1 = 0.1;
            var column2 = 0.2;
            var column3 = 0.2;
            var column4 = 0.2;
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
    }
}
