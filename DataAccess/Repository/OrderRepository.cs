using BusinessObject.Model;
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Remove(Order order)
        {
            throw new NotImplementedException();
        }

        public void Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
