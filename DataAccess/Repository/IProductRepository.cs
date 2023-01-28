﻿using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> List();
        void AddNew(Product product);
        void Update(Product product);
        void Remove(Product product);
        Product FindById(int id);
        IEnumerable<Product> FindByPrice(decimal price);
        IEnumerable<Product> FindByStock(int stock);
    }
}
