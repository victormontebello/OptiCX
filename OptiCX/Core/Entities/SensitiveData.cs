namespace Core.Entities;

public class SensitiveData
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string Type {get; set;}
    public string Value {get; set;}
}