using Core.Entities;
using Core.Entities.Components;
using Core.Enums;
using Range = Core.Entities.Components.Range;

namespace Core.Builders;

public class DataCollectorBuilder
{
    private DataCollector _dataCollector;
    
    public void Reset() => _dataCollector = new DataCollector();
    public DataCollector GetDataCollector() => _dataCollector;
    
    public void SetTitle(string title) => _dataCollector.Title = title;
    public void SetDescription(string description) => _dataCollector.Description = description;
    public void SetDateOfCollect(DateTime dateOfCollect) => _dataCollector.DateOfCollect = dateOfCollect;

    public void SetInput(Input input) => _dataCollector.Components.Add(input);
    public void SetInput(string label, InputTypeEnum inputType)
    {
        _dataCollector.Components.Add(new Input
        {
            Label = label,
            InputType = inputType
        });
    }

    public void SetMultipleOptions(MultipleOptions multipleOptions) => _dataCollector.Components.Add(multipleOptions);
    public void SetMultipleOptions(string label, List<string> options, MultipleComponentEnum multipleComponent)
    {
        _dataCollector.Components.Add(new MultipleOptions
        {
            Label = label,
            MultipleComponent = multipleComponent,
            Options = options
        });
    }

    public void SetRange(Range range) => _dataCollector.Components.Add(range);
    public void SetRange(string label, double minValue, double maxValue, double growthFactor)
    {
        _dataCollector.Components.Add(new Range
        {
            Label = label,
            GrowthFactor = growthFactor,
            MaxValue = maxValue,
            MinValue = minValue
        });
    }
}