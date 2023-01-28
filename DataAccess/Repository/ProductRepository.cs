using BusinessObject.Model;
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
            throw new NotImplementedException();
        }

        public Product FindById(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Remove(Product product)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
