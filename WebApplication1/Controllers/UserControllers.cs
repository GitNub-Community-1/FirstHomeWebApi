using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entity;
using WebApplication1.Infastructure;

namespace WebApplication1.Controllers;
[ApiController]
[Route("api/[controller]")]

public class UserController:ControllerBase
{
    private readonly UserService usService;
    public UserController()
    {
        usService = new();
    }

    [HttpPost]
    public string CreateUser(User user)
    {
        var result = usService.AddUser(user);
        return result;
    }

    [HttpPut]
    public string UpdateUser(int id,string phone_number, string email)
    {
        var result = usService.UpdateUser(id,phone_number,email);
        return result;
    }

    [HttpDelete]
    public string DeleteUser(int id)
    {
        var result = usService.DeleteUser(id);
        return result;
    }

    [HttpGet]
    public List<User> ShowAllUsers()
    {
        var result = usService.GetUsers();
        return result;
    }
}