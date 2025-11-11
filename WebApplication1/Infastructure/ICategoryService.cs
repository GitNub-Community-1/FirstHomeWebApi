using WebApplication1.Entity;

namespace WebApplication1.Infastructure;

public interface ICategoryService
{
    public Task<int> AddCategoryAsync(Category category);
    public Task<int> UpdateCategoryAsync(Category category);
    public Task<int> DeleteCategoryAsync(int id);
    public List<Category> GetCategories();
}