using Dapper;
using WebApplication1.Entity;

namespace WebApplication1.Infastructure;

public class ProductService:IProductService
{
    private DbContext _conn;

    public ProductService()
    {
        _conn = new DbContext();
    }

    public async Task<int> AddProductAsync(Product product)
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query = "INSERT INTO products(name, brand,price,year,company_id) VALUES (@name, @brand,@price,@year,@company_id)";
        var i = await conn.ExecuteAsync(query,new{product.name,product.brand,product.price,product.year,product.company_id});
        
        return i;
    }

    public async Task<int> UpdateProductAsync(int id,string name,decimal price)
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query = "update products set name = @name,price=@price where id = @id;";
        var i = await conn.ExecuteAsync(query,new{id,name,price});
        
        return i;
    }

    public async Task<int> DeleteProductAsync(int id)
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query = "delete from products where id = @id";
        var i = await conn.ExecuteAsync(query,new{id});
       
        return i;
    }

    public List<Product> GetProducts()
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query = "select * from products";
        var result = conn.Query<Product>(query).ToList();
        return result;
    }
}