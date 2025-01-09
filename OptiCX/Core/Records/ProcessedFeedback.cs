namespace Core.Records;

public class ProcessedFeedback
{
    public string Comment { get; init; }
    public float SentimentScore { get; init; }
    public IEnumerable<string> Keywords { get; init; }
    public IEnumerable<string> Categories { get; init; }
    public Dictionary<string, float> AspectScores { get; init; }
    public IEnumerable<string> Suggestions { get; init; }
    
    public ProcessedFeedback(string comment, float sentimentScore, IEnumerable<string> keywords, IEnumerable<string> categories, Dictionary<string, float> aspectScores, IEnumerable<string> suggestions)
    {
        Comment = comment;
        SentimentScore = sentimentScore;
        Keywords = keywords;
        Categories = categories;
        AspectScores = aspectScores;
        Suggestions = suggestions;
    }
}