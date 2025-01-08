using Core.Builders;
using Core.Entities;
using Core.Enums;

namespace Core.Directors;

public class DataCollectorDirector(DataCollectorBuilder builder)
{
    //EXAMPLE
    public DataCollector CreatePerformanceAnalysis()
    {
        builder.Reset();
        
        builder.SetTitle("Performance Analysis");
        builder.SetDescription("An analysis of performance analysis by the CTO evaluation of the employee.");
        builder.SetDateOfCollect(DateTime.UtcNow.AddDays(5));
        builder.SetInput("Insert the employee name", InputTypeEnum.Alpha);
        builder.SetInput("Insert the employee department", InputTypeEnum.Alpha);
        builder.SetRange("Inform the grade in relation to the employee’s deliveries", 0, 10, 0.5);
        
        return builder.GetDataCollector();
    }
}