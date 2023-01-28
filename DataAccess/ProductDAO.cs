using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }

            }
        }

        public Product FindOne(Expression<Func<Product, bool>> predicate)
        {
            Product product = null;
            try
            {
                using (var saleManagerContext = new SaleManagerContext())
                {
                    product = saleManagerContext.Products.SingleOrDefault(predicate);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return product;
        }

        public static IEnumerable<Product> FindAll(Expression<Func<Product, bool>> predicate)
        {
            List<Product> products = new List<Product>();
            try
            {
                using (var saleManagerContext = new SaleManagerContext())
                {
                    products = saleManagerContext.Products.Where(predicate).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return products;
        }

    }
}
