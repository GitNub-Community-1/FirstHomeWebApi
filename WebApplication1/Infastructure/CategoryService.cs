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
    public string AddCategory(Category category)
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query = "insert into categories(name,description) values (@name,@description)";
        int i = conn.Execute(query, new { category.name, category.description });
        if (i > 0)
        {
            return "Category added successfully";
        }
        else
        {
            return "Category not added successfully";
        }
    }

    public string UpdateCategory(Category category)
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query = "update categories set name=@name,description=@description where id=@id";
        int i = conn.Execute(query, new { category.name, category.description,category.id });
        if (i > 0)
        {
            return "Category update successfully";
        }
        else
        {
            return "Category not update successfully";
        }
    }

    public string DeleteCategory(int id)
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query = "delete from categories where id = @id";
        int i = conn.Execute(query, new { id });
        if (i > 0)
        {
            return "Category delete successfully";
        }
        else
        {
            return "Category not delete successfully";
        }
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