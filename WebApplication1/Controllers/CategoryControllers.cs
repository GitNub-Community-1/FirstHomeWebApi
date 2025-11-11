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
    public async Task<string> CreateCategory(Category category)
    {
        var result = await ctService.AddCategoryAsync((category));
        string answer = (result > 0) ? "Category Added Succefully!" : "Category not added sussefully!"; 
        return answer;
    }

    [HttpPut]
    public async Task<string> UpdateCategory(Category category)
    {
        var result = await ctService.UpdateCategoryAsync(category);
        string answer = (result > 0) ? "Category Update Succefully!" : "Category not update sussefully!"; 
        return answer;
    }

    [HttpDelete]
    public async Task<string> DeleteCategory(int id)
    {
        var result = await ctService.DeleteCategoryAsync(id);
        string answer = (result > 0) ? "Category Delete Succefully!" : "Category not delete sussefully!"; 
        return answer;
    }

    [HttpGet]
    public List<Category> ShowCategory()
    {
        var result = ctService.GetCategories();
        return result;
    }
}