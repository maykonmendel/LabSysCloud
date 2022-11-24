using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSysCloud.CrossCuting.S3Bucket
{
    public class S3Response
    {
        public int StatusCode { get; set; } = 200;
        public string Message { get; set; } = "";
        public string Key { get; set; }
    }
}