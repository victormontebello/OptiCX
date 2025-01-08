using System.ComponentModel.DataAnnotations;
using Core.Entities.Components;

namespace Core.Entities;

public class DataCollector
{
    public int Id { get; set; }
    public string Title;
    public DateTime DateOfCollect;
    public string Description;
    public List<ComponentBase> Components;
}