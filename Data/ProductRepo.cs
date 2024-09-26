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
}
