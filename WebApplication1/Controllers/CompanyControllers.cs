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
    public string CreateCompany(Company company)
    {
        var result = cmService.AddCompany((company));
        return result;
    }

    [HttpPut]
    public string UpdateCompany(Company company)
    {
        var result = cmService.UpdateCompany(company);
        return result;
    }

    [HttpDelete]
    public string DeleteCompany(string name)
    {
        var result = cmService.DeleteCompany(name);
        return result;
    }

    [HttpGet]
    public List<Company> ShowCompanies()
    {
        var result = cmService.GetCompanies();
        return result;
    }
}