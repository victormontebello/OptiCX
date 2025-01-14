using Microsoft.ML.Data;

namespace Core.Entities;

public class SentimentData
{
    [LoadColumn(0)]
    public string Text { get; set; }

    [LoadColumn(1)]
    public bool Sentiment { get; set; }
}