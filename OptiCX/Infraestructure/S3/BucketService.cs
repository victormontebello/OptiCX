using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Core.Abstract;

namespace Infraestructure.S3;

public class BucketService : AmazonResource 
{
    public async Task<bool> GetObject(string pathToSave, string key)
    {
        BASE_PATH = "S3_OPTICX_";
        var client = new AmazonS3Client(Credentials, RegionEndpoint.USEast2);
        var request = new GetObjectRequest()
        {
            BucketName = Environment.GetEnvironmentVariable($"{BASE_PATH}BUCKET_NAME"),
            Key = key,
        };
        
        using var response = await client.GetObjectAsync(request);
        
        try
        {
            await response.WriteResponseStreamToFileAsync($"{pathToSave}\\{key}", true, CancellationToken.None);
            return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
        }
        catch (AmazonS3Exception ex)
        {
            Console.WriteLine($"Error saving {"csv"}: {ex.Message}");
            return false;
        }
    }
}

