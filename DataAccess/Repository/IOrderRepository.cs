using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> List();
        void AddNew(Order order);
        void Update(Order order);
        void Remove(Order order);
        Order FindById(int id);
        IEnumerable<Order> FindByEmail(string email);
        IEnumerable<Order> FindAllByStartTimeAndEndTime(DateTime start,DateTime end);

    }
}
