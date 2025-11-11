using Dapper;
using WebApplication1.Entity;

namespace WebApplication1.Infastructure;

public class CategoryService:ICategoryService
{
    private DbContext _conn;

    public CategoryService()
    {
        _conn = new DbContext();
    }
    public async Task<int> AddCategoryAsync(Category category)
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query = "insert into categories(name,description) values (@name,@description)";
        var i = await conn.ExecuteAsync(query, new { category.name, category.description });
        
        return i;
    }

    public async Task<int> UpdateCategoryAsync(Category category)
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query = "update categories set name=@name,description=@description where id=@id";
        var i = await conn.ExecuteAsync(query, new { category.name, category.description,category.id });
        
        return i;
    }

    public async Task<int> DeleteCategoryAsync(int id)
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query = "delete from categories where id = @id";
        var i = await conn.ExecuteAsync(query, new { id });
        
        return i;
    }

    public List<Category> GetCategories()
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query = "select * from categories";
        var result = conn.Query<Category>(query).ToList();
        return result;
    }
}