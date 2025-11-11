using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entity;
using WebApplication1.Infastructure;

namespace WebApplication1.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly CompanyService cmService;

    public CompanyController()
    {
        cmService = new();
    }

    [HttpPost]
    public async Task<string> CreateCompany(Company company)
    {
        var result = await cmService.AddCompanyAsync((company));
        string answer = (result > 0) ? "Company Added Succefully!" : "Company not added succefully!";
        return answer;
    }

    [HttpPut]
    public async Task<string> UpdateCompany(Company company)
    {
        var result = await cmService.UpdateCompanyAsync(company);
        string answer = (result > 0) ? "Company Update Succefully!" : "Company not update succefully!";
        return answer;
    }

    [HttpDelete]
    public async Task<string> DeleteCompany(string name)
    {
        var result = await cmService.DeleteCompany(name);
        string answer = (result > 0) ? "Company Delete Succefully!" : "Company not delete succefully!";
        return answer;
    }

    [HttpGet]
    public List<Company> ShowCompanies()
    {
        var result = cmService.GetCompanies();
        return result;
    }
}