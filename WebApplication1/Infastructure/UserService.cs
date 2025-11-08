using Dapper;
using WebApplication1.Entity;

namespace WebApplication1.Infastructure;

public class UserService:IUserService
{
    private DbContext _conn;

    public UserService()
    {
        _conn = new DbContext();
    }

    public string AddUser(User user)
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query = "insert into users(fullname,birth_year,phone_number,email) values(@fullname,@birth_year,@phone_number,@email);";
        int i = conn.Execute(query,new{user.fullname,user.birth_year,user.phone_number,user.email});
        if (i > 0)
        {
            return "User added successfully";
        }
        else
        {
            return "User not added successfully";
        }
    }

    public string UpdateUser(int id,string phone_number, string email)
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query = "update users set phone_number = @phone_number,email = @email where id = @id;";
        int i = conn.Execute(query,new{id,phone_number,email});
        if (i > 0)
        {
            return "User update successfully";
        }
        else
        {
            return "User not update successfully";
        }
    }

    public string DeleteUser(int id)
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query = "delete from users where id = @id;";
        int i = conn.Execute(query,new{id});
        if (i > 0)
        {
            return "User delete successfully";
        }
        else
        {
            return "User not delete successfully";
        }
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