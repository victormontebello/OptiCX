namespace Core.Entities.Components;

public class Range : ComponentBase
{
    public double MinValue { get; set; }
    public double MaxValue { get; set; }
    public double GrowthFactor { get; set; }
}