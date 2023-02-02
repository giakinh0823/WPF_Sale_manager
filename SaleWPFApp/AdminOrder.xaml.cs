using DataAccess.Model;
using DataAccess.Repository;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SaleWPFApp
{
    /// <summary>
    /// Interaction logic for AdminOrder.xaml
    /// </summary>
    public partial class AdminOrder : Page
    {
        private readonly IOrderRepository orderRepository;
        public AdminOrder(IOrderRepository _orderRepository)
        {
            InitializeComponent();
            this.orderRepository = _orderRepository;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = orderRepository.List();
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

        private void Button_Search(object sender, RoutedEventArgs e)
        {
            DateTime? startDate = StartDate.SelectedDate == null ? null : StartDate.SelectedDate.Value.Date;
            DateTime? endDate = EndDate.SelectedDate == null ? null : EndDate.SelectedDate.Value.Date;
            OrderFilter orderFilter = new OrderFilter();
            orderFilter.StartDate = startDate;
            orderFilter.EndDate = endDate;
            listView.ItemsSource = orderRepository.FindAllBy(orderFilter);
        }
    }
}
