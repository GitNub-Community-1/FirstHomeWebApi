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
    public async Task<string> CreateUser(User user)
    {
        var result = await usService.AddUserAsync(user);
        string answer = (result > 0) ? "User Added Succefully!" : "Product not added sussefully!"; 
        return answer;
    }

    [HttpPut]
    public async Task<string> UpdateUser(int id,string phone_number, string email)
    {
        var result = await usService.UpdateUserAsync(id,phone_number,email);
        string answer = (result > 0) ? "User Update Succefully!" : "User not update sussefully!"; 
        return answer;
    }

    [HttpDelete]
    public async Task<string> DeleteUser(int id)
    {
        var result = await usService.DeleteUserAsync(id);
        string answer = (result > 0) ? "User Delete Succefully!" : "User not delete sussefully!"; 
        return answer;
    }

    [HttpGet]
    public List<User> ShowAllUsers()
    {
        var result = usService.GetUsers();
        return result;
    }
}