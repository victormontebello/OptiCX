using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Core.Interfaces;

namespace Infraestructure.S3;

public class BucketService : AmazonResource 
{
    public async Task GetObject(string pathToSave, string key)
    {
        basePath = "S3_OPTICX_";
        var client = new AmazonS3Client(Credentials, RegionEndpoint.USEast2);
        var request = new GetObjectRequest()
        {
            BucketName = Environment.GetEnvironmentVariable($"{basePath}BUCKET_NAME"),
            Key = key,
        };
        
        using GetObjectResponse response = await client.GetObjectAsync(request);
        
        try
        {
            await response.WriteResponseStreamToFileAsync($"{pathToSave}\\{key}", true, CancellationToken.None);
            Console.WriteLine(response.HttpStatusCode == System.Net.HttpStatusCode.OK);
        }
        catch (AmazonS3Exception ex)
        {
            Console.WriteLine($"Error saving {"csv"}: {ex.Message}");
        }
    }
    
    public override BasicAWSCredentials GetCredentials()
    {
        var secretKey = Environment.GetEnvironmentVariable($"{basePath}SECRET_KEY");
        var accessKeyId = Environment.GetEnvironmentVariable($"{basePath}ACCESS_KEY");
        return new BasicAWSCredentials(accessKeyId, secretKey);
    }
}

