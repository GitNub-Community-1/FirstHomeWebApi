using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entity;
using WebApplication1.Infastructure;
namespace WebApplication1.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductController:ControllerBase
{
    private readonly ProductService prService;
    public ProductController()
    {
        prService = new();
    }

    [HttpPost]
    public string CreateProduct(Product product)
    {
        var result = prService.AddProduct(product);
        return result;
    }

    [HttpPut]
    public string UpdateProduct(int id,string name,decimal price)
    {
        var result = prService.UpdateProduct(id,name,price);
        return result;
    }

    [HttpDelete]
    public string DeleteProduct(int id)
    {
        var result = prService.DeleteProduct(id);
        return result;
    }

    [HttpGet]
    public List<Product> ShowCompanies()
    {
        var result = prService.GetProducts();
        return result;
    }
}