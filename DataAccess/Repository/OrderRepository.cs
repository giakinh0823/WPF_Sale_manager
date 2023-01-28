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
        public void AddNew(Order order)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> FindAllByStartTimeAndEndTime(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> FindByEmail(string email)
        {
            throw new NotImplementedException();
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
