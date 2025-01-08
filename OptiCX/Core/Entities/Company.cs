namespace Core.Entities;

public class Company
{
    public int Id { get; set; }
    public string FantasyName { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }   
    public List<Branch> Branches { get; set; } = [];
    public List<Customer> Customers { get; set; } = [];
    public string CpfCnpj { get; set; }
}