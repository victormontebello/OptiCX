using Core.Files;

namespace Analysis.Test
{
    public class ModelTest
    {
        [Fact]
        public async Task ModelTrainingTest()
        {
            var path = @"F:\ML\model.zip";
            var data = new Model.ModelInput { FeedBack = "this is aweasome!" };
            Model.Train(path);
            Assert.True(File.Exists(path));
        }

        [Fact]
        public async Task PredictTest()
        {
            var path = @"F:\ML\model.zip";
            var data = new Model.ModelInput { FeedBack = "this is aweasome!" };
            var s3 = new S3Service();
            await s3.GetCSV("F:\\cfg", "stock_data.csv");
            Model.Train(path, "F:\\cfg\\stock_data.csv");

            var values = Model.Predict(data).Score;
            Assert.True(values[0] > values[1]);
            Assert.True(File.Exists(path));
        }
    }
}