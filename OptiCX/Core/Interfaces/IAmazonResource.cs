using Amazon.Runtime;

namespace Core.Interfaces
{
    public abstract class AmazonResource
    {
        public string basePath;
        protected AWSCredentials Credentials => GetCredentials();
        
        private BasicAWSCredentials GetCredentials()
        {
            var secretKey = Environment.GetEnvironmentVariable($"{basePath}SECRET_KEY");
            var accessKeyId = Environment.GetEnvironmentVariable($"{basePath}ACCESS_KEY");
            return new BasicAWSCredentials(accessKeyId, secretKey);
        }
    }
}
