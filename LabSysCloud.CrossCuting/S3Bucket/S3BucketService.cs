using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using LabSysCloud.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace LabSysCloud.CrossCuting.S3Bucket
{
    public class S3BucketService
    {
        public Arquivo UploadImagem(IFormFile arquivo)
        {
            var accessKeyId = "AKIAQCRGND2VC4EC5LOP";
            var accessKeySecret = "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";
            var bucketName = "labsyscloudnew";
          
            var credenciais = new BasicAWSCredentials(accessKeyId, accessKeySecret);

            var config = new AmazonS3Config()
            {
                RegionEndpoint = Amazon.RegionEndpoint.USEast1
            };

            var response = new Arquivo();

            string key = "fotos-pacientes/" + Guid.NewGuid() + "/" + arquivo.FileName;

            try
            {
                using(var newMemoryStream = new MemoryStream())
                {
                    arquivo.CopyTo(newMemoryStream);

                    var uploadRequest = new TransferUtilityUploadRequest()
                    {
                        InputStream = newMemoryStream,
                        Key = key,
                        BucketName = bucketName,
                        ContentType = arquivo.ContentType,
                        CannedACL = S3CannedACL.NoACL
                    };

                    using var client = new AmazonS3Client(credenciais, config);
                    var transferUtility = new TransferUtility(client);
                    transferUtility.Upload(uploadRequest);
                   
                    response.Key = key;
                    response.NomeArquivo = arquivo.FileName;
                }
            }
            catch(AmazonS3Exception ex)
            {
                var StatusCode = (int)ex.StatusCode;
                var Message = ex.Message;
            }     
            catch(Exception ex)
            {                
                var Message = ex.Message;
            }

            return response;
        }
    }
}