using Npgsql;

namespace WebApplication1.Infastructure;

public class DbContext
{
    string connstring = "Host = localhost;Port = 5432;Database = mini_shop;Username = postgres;Password = maradona@$$34;";

    public NpgsqlConnection GetConnect()
    {
        return new NpgsqlConnection(connstring);
    }
    
    
    
}