namespace WebApplication1.Infastructure;
using Entity;
using Dapper;
using Npgsql;

public class CompanyService:ICompanyService
{
    private DbContext _conn;

    public CompanyService()
    {
        _conn = new DbContext();
    }

    public string AddCompany(Company company)
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query = "insert into companies(name,description) values(@name,@description)";
        int i = conn.Execute(query,new{company.name,company.description});
        if (i > 0)
        {
            return "Company added successfully";
        }
        else
        {
            return "Company not added successfully";
        }
    }

    public string UpdateCompany(Company company)
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query = "update companies set name=@name,description=@description where id=@id";
        int i = conn.Execute(query,new{company.id,company.name,company.description});
        if (i > 0)
        {
            return "Company update successfully";
        }
        else
        {
            return "Company not update successfully";
        }
    }

    public string DeleteCompany(string name)
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query = "delete from companies where name=@name";
        int i = conn.Execute(query,new{name});
        if (i > 0)
        {
            return "Company delete successfully";
        }
        else
        {
            return "Company not delete successfully";
        }
    }

    public List<Company> GetCompanies()
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query = "select * from companies";
        var result = conn.Query<Company>(query).ToList();
        return result;
    }
}