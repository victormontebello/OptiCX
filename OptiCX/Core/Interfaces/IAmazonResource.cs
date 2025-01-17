using Amazon.Runtime;

namespace Core.Interfaces
{
    public abstract class AmazonResource
    {
        public string basePath;
        protected AWSCredentials Credentials => GetCredentials();
        
        public abstract BasicAWSCredentials GetCredentials();
    }
}
