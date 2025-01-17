namespace Analysis.Test
{
    public class ModelTest
    {
        [Fact]
        public async Task ModelTrainingTest()
        {
            var path = @"F:\ML\model.zip";
            var data = new AnalysisModel.ModelInput { Text = "this is aweasome!" };
            AnalysisModel.Train(path);
            Assert.True(File.Exists(path));
        }

        [Fact]
        public async Task PredictTest()
        {
            var path = @"F:\ML\model.zip";
            var data = new AnalysisModel.ModelInput { Text = "this is aweasome!" };
            AnalysisModel.Train(path, "F:\\cfg\\stock_data.csv");

            var values = AnalysisModel.Predict(data).Score;
            Assert.True(values[0] > values[1]);
            Assert.True(File.Exists(path));
        }
    }
}