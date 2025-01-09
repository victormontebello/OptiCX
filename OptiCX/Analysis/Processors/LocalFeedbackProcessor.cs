using System.Collections.Concurrent;
using Core.Entities;
using Core.Records;
using Microsoft.Extensions.Logging;
using Microsoft.ML;

namespace Analysis.Processors;

public class LocalFeedbackProcessor
{
    private readonly MLContext _mlContext;
    private readonly PredictionEngine<SentimentData, SentimentPrediction> _predictionEngine;
    private readonly ILogger<LocalFeedbackProcessor> _logger;
    private readonly Dictionary<string, HashSet<string>> _aspectKeywords;

    public LocalFeedbackProcessor(ILogger<LocalFeedbackProcessor> logger)
    {
        _mlContext = new MLContext();
        _predictionEngine = CreateAndTrainModel();
        _logger = logger;

        // Initialize aspect keywords for different categories
        _aspectKeywords = new Dictionary<string, HashSet<string>>
        {
            ["product"] = new HashSet<string>
            {
                "quality", "durability", "features", "design", "performance",
                "reliability", "functionality", "usability"
            },
            ["service"] = new HashSet<string>
            {
                "support", "response", "assistance", "staff", "help",
                "communication", "resolution", "representative"
            },
            ["price"] = new HashSet<string>
            {
                "cost", "value", "expensive", "cheap", "affordable",
                "pricing", "worth", "discount"
            }
        };
    }

    private PredictionEngine<SentimentData, SentimentPrediction> CreateAndTrainModel()
    {
        // Create sample training data
        var trainData = new List<SentimentData>
        {
            new() { Text = "great excellent awesome", Sentiment = true },
            new() { Text = "terrible horrible bad", Sentiment = false },
            // Add more training data here
        };

        // Create and train the model
        var pipeline = _mlContext.Transforms.Text
            .FeaturizeText("Features", nameof(SentimentData.Text))
            .Append(_mlContext.BinaryClassification.Trainers.SdcaLogisticRegression());

        var trainingData = _mlContext.Data.LoadFromEnumerable(trainData);
        var model = pipeline.Fit(trainingData);

        return _mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(model);
    }

    public async Task<ProcessedFeedback> ProcessFeedbackAsync(FeedbackInput feedback)
    {
        try
        {
            // Sentiment Analysis
            var sentimentPrediction = _predictionEngine.Predict(
                new SentimentData { Text = feedback.Comment });
            var sentimentScore = sentimentPrediction.Score;

            // Extract Keywords
            var keywords = ExtractKeywords(feedback.Comment);

            // Categorize
            var categories = CategorizeText(feedback.Comment);

            // Analyze aspects
            var aspects = AnalyzeAspects(feedback.Comment);

            // Generate suggestions
            var suggestions = GenerateSuggestions(sentimentScore, aspects);

            return new ProcessedFeedback(
                feedback.Comment,
                sentimentScore,
                keywords,
                categories,
                aspects,
                suggestions
            );
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing feedback: {Comment}", feedback.Comment);
            throw;
        }
    }

    public async Task<IEnumerable<ProcessedFeedback>> ProcessBatchAsync(IEnumerable<FeedbackInput> feedbackBatch)
    {
        var results = new ConcurrentBag<ProcessedFeedback>();

        await Parallel.ForEachAsync(feedbackBatch, async (feedback, ct) =>
        {
            var result = await ProcessFeedbackAsync(feedback);
            results.Add(result);
        });

        return results;
    }

    private IEnumerable<string> ExtractKeywords(string text)
    {
        // Simple keyword extraction based on word frequency and importance
        var words = text.ToLower()
            .Split(new[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
            .Where(w => w.Length > 3) // Filter out short words
            .GroupBy(w => w)
            .OrderByDescending(g => g.Count())
            .Take(5)
            .Select(g => g.Key);

        return words;
    }

    private IEnumerable<string> CategorizeText(string text)
    {
        var categories = new HashSet<string>();
        var lowercaseText = text.ToLower();

        foreach (var category in _aspectKeywords.Keys)
        {
            if (_aspectKeywords[category].Any(keyword =>
                    lowercaseText.Contains(keyword)))
            {
                categories.Add(category);
            }
        }

        return categories;
    }

    private Dictionary<string, float> AnalyzeAspects(string text)
    {
        var aspects = new Dictionary<string, float>();
        var words = text.ToLower().Split(' ');
        var positiveWords = new HashSet<string>
        {
            "good", "great", "excellent", "amazing", "fantastic",
            "wonderful", "best", "perfect", "awesome"
        };
        var negativeWords = new HashSet<string>
        {
            "bad", "poor", "terrible", "horrible", "worst",
            "awful", "disappointing", "frustrating"
        };

        foreach (var category in _aspectKeywords.Keys)
        {
            var aspectMentions = 0;
            var aspectScore = 0f;

            foreach (var keyword in _aspectKeywords[category])
            {
                var index = Array.IndexOf(words, keyword);
                if (index != -1)
                {
                    aspectMentions++;

                    // Look at surrounding words for sentiment
                    var start = Math.Max(0, index - 3);
                    var end = Math.Min(words.Length, index + 4);
                    var context = words[start..end];

                    if (context.Any(w => positiveWords.Contains(w)))
                        aspectScore += 1.0f;
                    else if (context.Any(w => negativeWords.Contains(w)))
                        aspectScore += 0.0f;
                    else
                        aspectScore += 0.5f;
                }
            }

            if (aspectMentions > 0)
            {
                aspects[category] = aspectScore / aspectMentions;
            }
        }

        return aspects;
    }

    private IEnumerable<string> GenerateSuggestions(float sentimentScore, Dictionary<string, float> aspects)
    {
        var suggestions = new List<string>();

        if (sentimentScore < 0.4f)
        {
            suggestions.Add("Overall feedback is negative - review required");
        }

        foreach (var aspect in aspects)
        {
            if (aspect.Value < 0.4f)
            {
                suggestions.Add($"Improvement needed in {aspect.Key} area");

                switch (aspect.Key.ToLower())
                {
                    case "product":
                        suggestions.Add("Consider product quality review and enhancement");
                        break;
                    case "service":
                        suggestions.Add("Review service delivery processes and staff training");
                        break;
                    case "price":
                        suggestions.Add("Evaluate pricing strategy and value proposition");
                        break;
                }
            }
        }

        return suggestions;
    }
}