using Dapper;
using WebApplication1.Entity;

namespace WebApplication1.Infastructure;

public class UserService : IUserService
{
    private DbContext _conn;

    public UserService()
    {
        _conn = new DbContext();
    }

    public async Task<int> AddUserAsync(User user)
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query =
            "insert into users(fullname,birth_year,phone_number,email) values(@fullname,@birth_year,@phone_number,@email);";
        var i = await conn.ExecuteAsync(query, new { user.fullname, user.birth_year, user.phone_number, user.email });
        
        return i;
    }

    public async Task<int> UpdateUserAsync(int id, string phone_number, string email)
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query = "update users set phone_number = @phone_number,email = @email where id = @id;";
        int i = await conn.ExecuteAsync(query, new { id, phone_number, email });
        return i;
    }

    public async Task<int> DeleteUserAsync(int id)
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query = "delete from users where id = @id;";
        int i = await conn.ExecuteAsync(query, new { id });
        
        return i;
    }

    public List<User> GetUsers()
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query = "select * from users";
        var result = conn.Query<User>(query).ToList();
        return result;
    }
}