using Npgsql;
using Dapper;
namespace WebApplication1.Infastructure;
using Entity;
using System;

public class CompanyService:ICompanyService
{
    private DbContext _conn;

    public CompanyService()
    {
        _conn = new DbContext();
    }

    public async Task<int> AddCompanyAsync(Company company)
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query = "insert into companies(name,description) values(@name,@description)";
        var i = await conn.ExecuteAsync(query,new{company.name,company.description});
        
        return i;
    }

    public async Task<int> UpdateCompanyAsync(Company company)
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query = "update companies set name=@name,description=@description where id=@id";
        var i = await conn.ExecuteAsync(query,new{company.id,company.name,company.description});
        
        return i;
    }

    public async Task<int> DeleteCompany(string name)
    {
        using var conn = _conn.GetConnect();
        conn.Open();
        string query = "delete from companies where name=@name";
        var i = await conn.ExecuteAsync(query,new{name});
        ;
        return i;
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