using Amazon.Runtime;

namespace Core.Abstract
{
    public abstract class AmazonResource
    {
        public string BASE_PATH;
        protected AWSCredentials Credentials => GetCredentials();
        
        private BasicAWSCredentials GetCredentials()
        {
            var secretKey = Environment.GetEnvironmentVariable($"{BASE_PATH}SECRET_KEY");
            var accessKeyId = Environment.GetEnvironmentVariable($"{BASE_PATH}ACCESS_KEY");
            return new BasicAWSCredentials(accessKeyId, secretKey);
        }
    }
}
