
using Core.Entities;
using Infraestructure.S3;

namespace Analysis.Test
{
    public class ModelTest
    {
        private readonly string Path = "F:\\ML";
        

        [Fact]
        public async Task ModelTrainingTest()
        {
            var path = @"F:\ML\model.zip";
            AnalysisModel.Train(path);
            Assert.True(File.Exists(path));
        }

        [Fact]
        public async Task PredictTest()
        {
            var path = @"F:\ML\model.zip";
            var data = new FeedbackInput { Text = "this is aweasome!" };
            await LoadFile(Path, "stock_data.csv");
            AnalysisModel.Train(path, $"{Path}\\stock_data.csv");

            var values = AnalysisModel.Predict(data);
            Assert.True(true);
            Assert.True(File.Exists(path));
        }

        private async Task LoadFile(string path, string v)
        {
            var s3 = new BucketService();
            await s3.GetObject(path, v);
        }
    }
}