namespace WebApplication1.Infastructure;
using Entity;
public interface IProductService
{
    public Task<int> AddProductAsync(Product product);
    public Task<int> UpdateProductAsync(int id,string a,decimal b);
    public Task<int> DeleteProductAsync(int id);
    public List<Product> GetProducts();
}