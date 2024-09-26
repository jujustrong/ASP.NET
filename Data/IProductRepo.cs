using System;
using System.Collections.Generic;
using ASPNET.Models;

namespace ASPNET.Data
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
    }
}