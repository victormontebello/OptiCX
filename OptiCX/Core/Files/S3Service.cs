using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;

namespace Core.Files;

public class S3Service
{
    public async Task GetCSV(string pathToSave, string key)
    {
        const string basePath = "S3_OPTICX_";
        var secretKey = Environment.GetEnvironmentVariable($"{basePath}SECRET_KEY");
        var accessKeyId = Environment.GetEnvironmentVariable($"{basePath}ACCESS_KEY");
        var credentials = new BasicAWSCredentials(accessKeyId, secretKey);
        var client = new AmazonS3Client(credentials, RegionEndpoint.USEast2);
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
}