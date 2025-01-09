namespace Core.Entities;

public class SentimentPrediction
{
    public bool Prediction { get; set; }

    public float Probability { get; set; }

    public float Score { get; set; }
}