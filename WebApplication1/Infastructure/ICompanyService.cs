namespace WebApplication1.Infastructure;
using Entity;
public interface ICompanyService
{
    public string AddCompany(Company company);   
    public string UpdateCompany(Company company);
    public string DeleteCompany(string name);
    public List<Company> GetCompanies();
}