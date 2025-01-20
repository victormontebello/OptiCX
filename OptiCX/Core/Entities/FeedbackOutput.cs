using Microsoft.ML.Data;
namespace Core.Entities;

public class FeedbackOutput
{
    [ColumnName(@"Text")]
    public float[] Text { get; set; }

    [ColumnName(@"Sentiment")]
    public uint Sentiment { get; set; }

    [ColumnName(@"Features")]
    public float[] Features { get; set; }

    [ColumnName(@"PredictedLabel")]
    public string PredictedLabel { get; set; }

    [ColumnName(@"Score")]
    public float[] Score { get; set; }
}