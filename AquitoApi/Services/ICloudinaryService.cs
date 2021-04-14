using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AquitoApi.Services
{
    public interface ICloudinaryService
    {
        public Task<string> FileUpload(String filename, Stream file);
    }
}
