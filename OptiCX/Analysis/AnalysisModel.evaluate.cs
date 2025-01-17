using Microsoft.ML;

namespace Analysis
{
    public partial class AnalysisModel
    {
        public static List<Tuple<string, double>> CalculatePFI(MLContext mlContext, IDataView trainData, ITransformer model, string labelColumnName)
        {
            var preprocessedTrainData = model.Transform(trainData);

            var permutationFeatureImportance =
         mlContext.MulticlassClassification
         .PermutationFeatureImportance(
                 model,
                 preprocessedTrainData,
                 labelColumnName: labelColumnName);

            var featureImportanceMetrics =
                 permutationFeatureImportance
                 .Select((kvp) => new { kvp.Key, kvp.Value.MicroAccuracy })
                 .OrderByDescending(myFeatures => Math.Abs(myFeatures.MicroAccuracy.Mean));

            var featurePFI = new List<Tuple<string, double>>();
            foreach (var feature in featureImportanceMetrics)
            {
                var pfiValue = Math.Abs(feature.MicroAccuracy.Mean);
                featurePFI.Add(new Tuple<string, double>(feature.Key, pfiValue));
            }

            return featurePFI;
        }
    }
}


