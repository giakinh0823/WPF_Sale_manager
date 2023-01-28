using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace DataAccess
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();

        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }

            }
        }

        public Order FindOne(Expression<Func<Order, bool>> predicate)
        {
            Order order = null;
            try
            {
                using (var saleManagerContext = new SaleManagerContext())
                {
                    order = saleManagerContext.Orders.SingleOrDefault(predicate);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return order;
        }

        public IEnumerable<Order> FindAll(Expression<Func<Order, bool>> predicate)
        {
            List<Order> orders = new List<Order>();
            try
            {
                using (var saleManagerContext = new SaleManagerContext())
                {
                    orders = saleManagerContext.Orders.Where(predicate).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orders;
        }

    }
}
