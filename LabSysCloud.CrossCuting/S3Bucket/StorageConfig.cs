using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace LabSysCloud.CrossCuting.S3Bucket
{
    public class StorageConfig : IStorageConfig
    {
        private readonly IConfiguration _configuration;

        public StorageConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<S3Response> UploadImageAsync(IFormFile file)
        {
            var accessKeyId = _configuration["AWSConfiguration:AccessKeyId"];
            var accessKeySecret = _configuration["AWSConfiguration:AccessKeySecret"];
            var bucketName = _configuration["AWSConfiguration:BucketName"];

            var credenciais = new BasicAWSCredentials(accessKeyId, accessKeySecret);

            var config = new AmazonS3Config()
            {
                RegionEndpoint = Amazon.RegionEndpoint.USWest2
            };

            var response = new S3Response();

            string key = "labsyscloud/" + Guid.NewGuid() + "/" + file.FileName;

            try
            {
                using (var newMemoryStream = new MemoryStream())
                {
                    file.CopyTo(newMemoryStream);

                    var uploadRequest = new TransferUtilityUploadRequest()
                    {
                        InputStream = newMemoryStream,
                        Key = key,
                        BucketName = bucketName,
                        ContentType = file.ContentType,
                        CannedACL = S3CannedACL.NoACL
                    };

                    using var client = new AmazonS3Client(credenciais, config);
                    var transferUtility = new TransferUtility(client);
                    await transferUtility.UploadAsync(uploadRequest);

                    response.StatusCode = 200;
                    response.Message = $"{file.FileName} foi enviado com sucesso!";
                    response.Key = key;
                }
            }
            catch (AmazonS3Exception ex)
            {
                response.StatusCode = (int)ex.StatusCode;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}