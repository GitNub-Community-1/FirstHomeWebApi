namespace WebApplication1.Infastructure;
using Entity;
public interface ICompanyService
{
    public Task<int> AddCompanyAsync(Company company);   
    public Task<int> UpdateCompanyAsync(Company company);
    public Task<int> DeleteCompany(string name);
    public List<Company> GetCompanies();
}