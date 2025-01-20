using Microsoft.ML.Data;

namespace Core.Entities;

public class FeedbackInput
{
    [LoadColumn(0)]
    [ColumnName(@"Text")]
    public string Text { get; set; }

    [LoadColumn(1)]
    [ColumnName(@"Sentiment")]
    public string Sentiment { get; set; }
}