using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LabSysCloud.CrossCuting.S3Bucket
{
    public interface IStorageConfig
    {
        Task<S3Response> UploadImageAsync(IFormFile file);
    }
}