namespace WebApplication1.Infastructure;
using Entity;
public interface IProductService
{
    public string AddProduct(Product product);
    public string UpdateProduct(int id,string a,decimal b);
    public string DeleteProduct(int id);
    public List<Product> GetProducts();
}