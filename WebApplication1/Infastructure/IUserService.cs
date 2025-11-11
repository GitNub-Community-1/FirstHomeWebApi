using WebApplication1.Entity;

namespace WebApplication1.Infastructure;

public interface IUserService
{
    public Task<int> AddUserAsync(User user);
    public Task<int> UpdateUserAsync(int id,string phone_number,string email);
    public Task<int> DeleteUserAsync(int id);
    public List<User> GetUsers();
}