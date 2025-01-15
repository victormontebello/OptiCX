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
            Model.Train(path);

            var values = Model.Predict(data).Score;
            Assert.True(values[0] > values[1]);
            Assert.True(File.Exists(path));
        }
    }
}