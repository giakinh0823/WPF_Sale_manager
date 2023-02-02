using BusinessObject.Model;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void Add(Order order)
        {
            OrderDAO.Instance.Add(order);
        }

        public IEnumerable<Order> FindAllByStartTimeAndEndTime(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> FindByEmail(string email)
        {
            return OrderDAO.Instance.FindAll(order => order.Member.Email == email);
        }

        public Order FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> List()
        {
            return OrderDAO.Instance.List();
        }

        public void Remove(Order order)
        {
            throw new NotImplementedException();
        }

        public void Update(Order order)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Order> IOrderRepository.FindAllBy(OrderFilter filter)
        {
            if(filter != null)
            {
                return OrderDAO.Instance.FindAll(order => (filter.StartDate == null || order.OrderDate >= filter.StartDate) &&
                                                              (filter.EndDate == null || order.OrderDate <= filter.EndDate) ||
                                                              (filter.StartDate != null && filter.EndDate != null && order.OrderDate >= filter.StartDate && order.OrderDate <= filter.EndDate)).OrderByDescending(order => order.OrderDate).ToList();
            }
            return List();
        }

    }
}
