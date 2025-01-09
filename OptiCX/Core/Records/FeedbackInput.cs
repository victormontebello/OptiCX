namespace Core.Records;

public record FeedbackInput
{
    public string Comment { get; init; } 
    public  DateTime SubmissionDate { get; init; }
    public string Category { get; init; }
    public string Source { get; init; }
}