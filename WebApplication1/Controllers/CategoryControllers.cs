using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entity;
using WebApplication1.Infastructure;
namespace WebApplication1.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoryController
{
    private readonly CategoryService ctService;

    public CategoryController()
    {
        ctService = new();
    }

    [HttpPost]
    public string CreateCategory(Category category)
    {
        var result = ctService.AddCategory((category));
        return result;
    }

    [HttpPut]
    public string UpdateCategory(Category category)
    {
        var result = ctService.UpdateCategory(category);
        return result;
    }

    [HttpDelete]
    public string DeleteCategory(int id)
    {
        var result = ctService.DeleteCategory(id);
        return result;
    }

    [HttpGet]
    public List<Category> ShowCategory()
    {
        var result = ctService.GetCategories();
        return result;
    }
}