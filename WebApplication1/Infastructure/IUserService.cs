using WebApplication1.Entity;

namespace WebApplication1.Infastructure;

public interface IUserService
{
    public string AddUser(User user);
    public string UpdateUser(int id,string phone_number,string email);
    public string DeleteUser(int id);
    public List<User> GetUsers();
}