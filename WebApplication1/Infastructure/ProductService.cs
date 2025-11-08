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

    public string AddProduct(Product product)
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query = "INSERT INTO products(name, brand,price,year,company_id) VALUES (@name, @brand,@price,@year,@company_id)";
        int i = conn.Execute(query,new{product.name,product.brand,product.price,product.year,product.company_id});
        if(i>0)
        {
            return ("Product added successfully");
        }
        else
        {
            return ("Product not added successfully");
        }
    }

    public string UpdateProduct(int id,string name,decimal price)
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query = "update products set name = @name,price=@price where id = @id;";
        int i = conn.Execute(query,new{id,name,price});
        if(i>0)
        {
            return ("Product update successfully");
        }
        else
        {
            return ("Product not update successfully");
        }
    }

    public string DeleteProduct(int id)
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query = "delete from products where id = @id";
        int i = conn.Execute(query,new{id});
        if(i>0)
        {
            return ("Product delete successfully");
        }
        else
        {
            return ("Product not delete successfully");
        }
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