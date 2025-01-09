using Core.Records;

namespace Core.Interfaces;

public interface IFeedbackProcessor
{
    Task<ProcessedFeedback> ProcessFeedbackAsync(FeedbackInput feedback);
    Task<IEnumerable<ProcessedFeedback>> ProcessBatchAsync(IEnumerable<FeedbackInput> feedbackBatch);
}