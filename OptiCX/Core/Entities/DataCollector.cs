using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class DataCollector
{
    public int Id { get; set; }
    public string Title;
    public DateTime DateOfCollect;
    public string Description;
    public List<DataType> Components;
}