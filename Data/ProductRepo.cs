using System.Data;
using Dapper;
using ASPNET.Models;

namespace ASPNET.Data;

public class ProductRepo : IProductRepository
{
    private readonly IDbConnection _connection;

    public ProductRepo(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public IEnumerable<Product> GetAllProducts()
    {
        return _connection.Query<Product>("SELECT * FROM products;");
    }

    public Product GetProduct(int productID)
    {
        return _connection.QuerySingle<Product>("SELECT * FROM products WHERE ProductID = @productID", new
        {
            productID
            
        });
    }

    public void UpdateProduct(Product product)
    {
        _connection.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
            new
            {
                name = product.Name, price = product.Price, id = product.ProductID 
                
            });
    }

    public void InsertProduct(Product productToInsert)
    {
        _connection.Execute("INSERT INTO products (Name, Price, CategoryID, OnSale, StockLevel) VALUES (@name, @price, @categoryID, @onSale, @stockLevel);",
            new
            {
                name = productToInsert.Name, price = productToInsert.Price, categoryID = productToInsert.CategoryID, onSale = productToInsert.OnSale,
                stockLevel = productToInsert.StockLevel
                
            });
    }

    public IEnumerable<Category> GetCategories()
    {
        return _connection.Query<Category>("SELECT * FROM categories;");
    }

    public Product AssignCategory()
    {
        var categoryList = GetCategories();
        var product = new Product();
        product.Categories = categoryList;
        return product;
    }

    public void DeleteProduct(Product product)
    {
        _connection.Execute("DELETE FROM REVIEWS WHERE ProductID = @id;", new {id = product.ProductID });
        _connection.Execute("DELETE FROM Sales WHERE ProductID = @id;",  new { id = product.ProductID });
        _connection.Execute("DELETE FROM Products WHERE ProductID = @id;", new { id = product.ProductID });
    }
}
