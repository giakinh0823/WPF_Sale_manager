using BusinessObject.Model;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void Add(Product product)
        {
            ProductDAO.Instance.Add(product);
        }

        public IEnumerable<Product> FindAllBy(ProductFilter filter)
        {
            if(filter !=null)
            {
                return ProductDAO.Instance.FindAll(product => (filter.ProductId == null || product.ProductId.Equals(filter.ProductId)) &&
                                                              (filter.ProductName == null || product.ProductName.ToLower().Contains(filter.ProductName.ToLower())) &&
                                                              (filter.UnitPrice == null || product.UnitPrice.Equals(filter.UnitPrice)) &&
                                                              (filter.UnitsInStock == null || product.UnitsInStock.Equals(filter.UnitsInStock)));
            }
            return List();
        }

        public Product FindById(int id)
        {
            return ProductDAO.Instance.FindOne(product => product.ProductId == id);
        }

        public IEnumerable<Product> FindByPrice(decimal price)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> FindByStock(int stock)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Product> List()
        {
            return ProductDAO.Instance.List();
        }

        public void Remove(Product product)
        {
            ProductDAO.Instance.Delete(product);
        }

        public void Update(Product product)
        {
            ProductDAO.Instance.Update(product);
        }
    }
}
