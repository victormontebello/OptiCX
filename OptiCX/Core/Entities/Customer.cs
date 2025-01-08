namespace Core.Entities;

public class Customer
{
    public int Id { get; set; }
    public List<Company> Companies { get; set; } = [];
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Address Address { get; set; }
    public string Occupation { get; set; }
    public DateTime DateOfBirth { get; set; } 
    public List<SensitiveData> SensitiveData { get; set; } = [];
}