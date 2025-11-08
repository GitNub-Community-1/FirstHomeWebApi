namespace WebApplication1.Entity;

public class Product
{
    public int id { get; set; }
    public string name { get; set; }
    public string brand { get; set; }
    public decimal price { get; set; }
    public int year { get; set; }
    public int company_id { get; set; }
}