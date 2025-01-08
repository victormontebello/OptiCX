using Core.Enums;

namespace Core.Entities.Components;

public class MultipleOptions : ComponentBase
{
    public List<string> Options { get; set; }
    public MultipleComponentEnum MultipleComponent { get; set; }
}