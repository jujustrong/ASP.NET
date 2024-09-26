using System;
using System.Collections.Generic;
using ASPNET.Models;

namespace ASPNET.Data
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
        Product GetProduct(int productID);
        void UpdateProduct(Product product);
        public void InsertProduct(Product productToInsert);
        public IEnumerable<Category> GetCategories();
        public Product AssignCategory();
        public void DeleteProduct(Product product);
    }
}