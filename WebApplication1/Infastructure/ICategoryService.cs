using WebApplication1.Entity;

namespace WebApplication1.Infastructure;

public interface ICategoryService
{
    public string AddCategory(Category category);
    public string UpdateCategory(Category category);
    public string DeleteCategory(int id);
    public List<Category> GetCategories();
}