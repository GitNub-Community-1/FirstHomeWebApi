using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entity;
using WebApplication1.Infastructure;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService prService;

    public ProductController()
    {
        prService = new();
    }

    [HttpPost]
    public async Task<string> CreateProduct(Product product)
    {
        var result = await prService.AddProductAsync(product);
        string answer = (result > 0) ? "Product Added Succefully!" : "Product not added succefully!";
        return answer;
    }

    [HttpPut]
    public async Task<string> UpdateProduct(int id, string name, decimal price)
    {
        var result = await prService.UpdateProductAsync(id, name, price);
        string answer = (result > 0) ? "Product Update Succefully!" : "Product not update sussefully!";
        return answer;
    }

    [HttpDelete]
    public async Task<string> DeleteProduct(int id)
    {
        var result = await prService.DeleteProductAsync(id);
        string answer = (result > 0) ? "Product Delete Succefully!" : "Product not delete sussefully!";
        return answer;
    }

    [HttpGet]
    public List<Product> ShowCompanies()
    {
        var result = prService.GetProducts();
        return result;
    }
}